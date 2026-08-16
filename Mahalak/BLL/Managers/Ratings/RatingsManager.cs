
using Microsoft.AspNetCore.Identity;

namespace Mahalak;

public class RatingsManager : IRatingsManager
{
  private readonly UserManager<User> userManager;
  private readonly IUnitOfWork unitOfWork;
  
  public RatingsManager(UserManager<User> userManager,IUnitOfWork unitOfWork)
  {
    this.userManager = userManager;
    this.unitOfWork = unitOfWork;
  }
  public async Task<List<RatingDTO>> GetAllWithCommentsInWaiting(CancellationToken ct=default)
  {
    var ratings = await unitOfWork.RatingsRepository.GetAllWithCommentsInWaitingAsync(ct);
    return ratings.Select(r => new RatingDTO
    {
      Id = r.Id,
      Value = r.Value,
      UserFirstName = r.User!.FirstName,
      UserLastName = r.User!.LastName,
      Comment = r.Comment,
      ShopId = r.ShopId,
      UserId = r.UserId
    }).ToList();
  }

  public async Task<RatingDTO?> GetByIdAsync(int id)
  {
    var rating = await unitOfWork.RatingsRepository.GetByIdAsync(id);
    if (rating == null)
      return null;
    return new RatingDTO
    {
      Id = rating.Id,
      Value = rating.Value,
      Comment = rating.Comment,
      ShopId = rating.ShopId,
      UserId = rating.UserId
    };
  }

  public async Task AddAsync(RatingAddDTO ratingDTO)
  {
    unitOfWork.RatingsRepository.Add(new Rating
    {
      Value = ratingDTO.Value,
      Comment = ratingDTO.Comment.Trim(),
      CommentDatetime = DateTime.Now,
      ShopId = ratingDTO.ShopId,
      UserId = ratingDTO.UserId
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(RatingUpdateDTO ratingDTO)
  {
    var rating = await unitOfWork.RatingsRepository.GetByIdAsync(ratingDTO.Id);
    if (rating == null)
      return false;
    rating.Value = ratingDTO.Value;
    rating.ShopId = ratingDTO.ShopId;
    rating.UserId = ratingDTO.UserId;
    unitOfWork.RatingsRepository.Update(rating);
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.RatingsRepository.IsExistedAsync(id))
      return false;
    unitOfWork.RatingsRepository.DeleteById(id);
    int num = await unitOfWork.SaveChangesAsync();
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> CheckExistenceAsync(string userId, int shopId)
  {
    return await unitOfWork.RatingsRepository.GetSpecificAsync(userId, shopId) == null;
  }

  public async Task<bool> EditCommentStatusAsync(int id, string status)
  {
    var rating = await unitOfWork.RatingsRepository.GetByIdAsync(id);
    if (rating != null)
    {
      if (status.Trim() == "مرفوض")
      {
        rating.Comment = "تم حذف هذا التعليق لأنه يحتوى على أساءة";
        var user = await userManager.FindByIdAsync(rating.UserId);
        if (user != null)
        {
          user.ViolationsCount += 1;
          user.BanExpiryDate = DateTime.Now.AddDays(user.ViolationsCount);
          var result = await userManager.UpdateAsync(user!);
          if (result == null)
          {
            return false;
          }
        }
      }
        rating.Status = status.Trim();
        unitOfWork.RatingsRepository.Update(rating);
        return await unitOfWork.SaveChangesAsync() == 1;
    }  
    return false;
  }

    public async Task<List<RatingDTO>> GetAllByShopIdAsync(int id, CancellationToken ct=default)
    {
      var ratings = await unitOfWork.RatingsRepository.GetAllByShopIdAsync(id,ct);
  
      return ratings.Select(r => new RatingDTO
      {
        Id = r.Id,
        UserFirstName = r.User!.FirstName,
        UserLastName = r.User!.LastName,
        Value = r.Value,
        Comment = r.Comment,
        Status = r.Status!,
        CommentDatetime = r.CommentDatetime,
        ShopId = r.ShopId,
        UserId = r.UserId
      }).ToList();
    }
}    