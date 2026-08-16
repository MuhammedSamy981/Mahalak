using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mahalak;

[Authorize(Roles = "Manager")]
public class SareaController : Controller
{
  private readonly ISAreasManager areasManager;
  private readonly ISCitiesManager citiesManager;

  public SareaController(ISCitiesManager citiesManager, ISAreasManager areasManager)
  {
    this.citiesManager = citiesManager;
    this.areasManager = areasManager;
  }


  public async Task<IActionResult> Index(CancellationToken ct)
  {
    //ViewBag.cities = new SelectList(await citiesManager.GetAllAsync(), "Id", "Name", 0);

    return Json(new { sareas = new SelectList(await areasManager.GetAllAsync(ct), "Id", "Name") });

  }

  [Authorize(Roles = "Manager")]
  public IActionResult Management()
  {
    return PartialView("_Management");
  }


  public async Task<IActionResult> Create(SAreaAddViewModel areaViewModel, CancellationToken ct)
  {
    if (areaViewModel?.Name != null && areaViewModel?.Name != ""
    && areaViewModel?.CityId != null && areaViewModel?.CityId != 0)
    {
      var areas = await areasManager.GetAllAsync(ct);
      areaViewModel!.Id = areas.Last().Id + 1;
      await areasManager.AddAsync(new SAreaAddDTO
      {
        Id = areaViewModel.Id,
        Name = areaViewModel.Name.Trim(),
        CityId = areaViewModel.CityId
      });
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await areasManager.DeleteAsync(id);
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

}
