using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mahalak;

[Authorize(Roles = "Manager")]
public class ScategoryController : Controller
{
  private readonly ISCategoriesManager categoriesManager;

  public ScategoryController(ISCategoriesManager categoriesManager)
  {
    this.categoriesManager = categoriesManager;
  }


  public async Task<IActionResult> Index(CancellationToken ct)
  {

    return Json(new { scategories = new SelectList(await categoriesManager.GetAllAsync(ct), "Id", "Name") });

  }

  [Authorize(Roles = "Manager")]
  public IActionResult Management()
  {
    return PartialView("_Management");
  }


  public async Task<IActionResult> Create(SCategoryAddViewModel categoryViewModel, CancellationToken ct)
  {
    if (categoryViewModel?.Name != null && categoryViewModel?.Name != "")
    {
      var categories = await categoriesManager.GetAllAsync(ct);
      categoryViewModel!.Id = categories.Last().Id + 1;
      await categoriesManager.AddAsync(new SCategoryAddDTO
      {
        Id = categoryViewModel.Id,
        Name = categoryViewModel.Name.Trim()
      });
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await categoriesManager.DeleteAsync(id);
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }


}
