using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mahalak;

public class ScityController : Controller
{
  private readonly ISCountriesManager countriesManager;
  private readonly ISCitiesManager citiesManager;

  public ScityController(ISCountriesManager countriesManager, ISCitiesManager citiesManager)
  {
    this.countriesManager = countriesManager;
    this.citiesManager = citiesManager;
  }

  [Authorize(Roles = "Manager,Admin")]
  public async Task<IActionResult> Index(CancellationToken ct)
  {
    return Json(new { scities = new SelectList(await citiesManager.GetAllAsync(ct), "Id", "Name") });

  }

  [Authorize(Roles = "Manager")]
  public IActionResult Management()
  {
    return PartialView("_Management");
  }

  public async Task<IActionResult> Create(SCityAddViewModel cityViewModel, CancellationToken ct)
  {
    if (cityViewModel?.Name != null && cityViewModel?.Name != ""
    && cityViewModel?.CountryId != null && cityViewModel?.CountryId != 0)
    {
      var cities = await citiesManager.GetAllAsync(ct);
      cityViewModel!.Id = cities.Last().Id + 1;
      await citiesManager.AddAsync(new SCityAddDTO
      {
        Id = cityViewModel.Id,
        Name = cityViewModel.Name.Trim(),
        CountryId = cityViewModel.CountryId
      });
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await citiesManager.DeleteAsync(id);
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }


}
