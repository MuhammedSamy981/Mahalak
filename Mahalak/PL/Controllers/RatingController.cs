using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;


namespace Mahalak;

public class RatingController : Controller
{
    private readonly IRatingsManager ratingsManager;

    public RatingController(IRatingsManager ratingsManager)
    {
        this.ratingsManager = ratingsManager;
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> Index(CancellationToken ct)
    {

        var ratings = await ratingsManager.GetAllWithCommentsInWaiting(ct);

        return PartialView("_Table", ratings.Select(r => new RatingViewModel
        {
            Id = r.Id,
            Value = r.Value,
            UserName = r.UserFirstName + " " + r.UserLastName,
            Comment = r.Comment,
            Status = r.Status,
            ShopId = r.ShopId,
            UserId = r.UserId
        }).ToList());

    }


    public async Task<IActionResult> GetSection(int shopId, string userName)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
        {
            ViewBag.AddingRating = await ratingsManager.CheckExistenceAsync(
               userId, shopId);
        }
        return PartialView("_Section", userName);

    }
    public async Task<IActionResult> GetAllByShopId(int id, CancellationToken ct)
    {

        var ratings = await ratingsManager.GetAllByShopIdAsync(id, ct);

        return PartialView("_List", ratings.Select(r => new RatingViewModel
        {
            Id = r.Id,
            Value = r.Value,
            UserName = r.UserFirstName + " " + r.UserLastName,
            Comment = r.Comment,
            Status = r.Status,
            ShopId = r.ShopId,
            UserId = r.UserId
        }).ToList());

    }

    [Authorize(Roles = "User")]
    public IActionResult Create()
    {
        return PartialView("_Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int shopId, RatingAddViewModel ratingViewModel)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_Create");
        }
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        if (userId == null)
        {
            return Json(new { success = false });
        }
        if (ratingViewModel?.Value != null)
        {
            var rating = new RatingAddDTO
            {
                ShopId = shopId,
                UserId = userId,
                Value = ratingViewModel.Value,
                Comment = ratingViewModel.Comment
            };
            await ratingsManager.AddAsync(rating);
            return Json(new { success = true });
        }

        return Json(new { success = false });
    }

    [Authorize(Roles = "User")]
    public async Task<IActionResult> Delete(int id)
    {
        var rating = await ratingsManager.GetByIdAsync(id);
        if (rating == null)
        {
            return Json(new { success = false });
        }
        if (rating.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
        {
            return Json(new { success = false });
        }
        await ratingsManager.DeleteAsync(id);
        return Json(new { success = true });
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> AcceptClientComment(int id)
    {
        await ratingsManager.EditCommentStatusAsync(id, "مقبول");
        var ratings = await ratingsManager.GetAllWithCommentsInWaiting();

        return PartialView("_Table", ratings.Select(r => new RatingViewModel
        {
            Id = r.Id,
            Value = r.Value,
            UserName = r.UserFirstName + " " + r.UserLastName,
            Comment = r.Comment,
            ShopId = r.ShopId,
            UserId = r.UserId
        }).ToList());
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> RemoveClientComment(int id, CancellationToken ct)
    {
        await ratingsManager.EditCommentStatusAsync(id, "مرفوض");
        var ratings = await ratingsManager.GetAllWithCommentsInWaiting(ct);

        return PartialView("_Table", ratings.Select(r => new RatingViewModel
        {
            Id = r.Id,
            Value = r.Value,
            UserName = r.UserFirstName + " " + r.UserLastName,
            Comment = r.Comment,
            ShopId = r.ShopId,
            UserId = r.UserId
        }).ToList());
    }
}
