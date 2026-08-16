using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mahalak;

public class ScountryController : Controller
{
  private readonly ISCountriesManager countriesManager;

  public ScountryController(ISCountriesManager countriesManager)
  {
    this.countriesManager = countriesManager;
  }

  [Authorize(Roles = "Manager,Admin")]
  public async Task<IActionResult> Index(CancellationToken ct)
  {
    var countries = await countriesManager.GetAllAsync(ct);
    return Json(new
    {
      scountries = new SelectList(countries.Select(c => new SCountryViewModel
      {
        Id = c.Id,
        NameWithCurrency = c.Name + "," + c.Currency
      }).ToList(), "Id", "NameWithCurrency")
    });

  }

  [Authorize(Roles = "Manager")]
  public IActionResult Management()
  {
    return PartialView("_Management");
  }
  public async Task<IActionResult> Create(SCountryAddViewModel countryViewModel, CancellationToken ct)
  {
    if (countryViewModel?.Name != null && countryViewModel?.Name != "")
    {
      var countries = await countriesManager.GetAllAsync(ct);
      countryViewModel!.Id = countries.Last().Id + 1;
      await countriesManager.AddAsync(new SCountryAddDTO
      {
        Id = countryViewModel.Id,
        Name = countryViewModel.Name,
        Currency = countryViewModel.Currency
      });
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await countriesManager.DeleteAsync(id);
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }


}
