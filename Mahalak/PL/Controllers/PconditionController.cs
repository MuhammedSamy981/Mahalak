using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using System.Text;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mahalak;

[Authorize(Roles = "Manager")]
public class PconditionController : Controller
{
  private readonly IPConditionsManager conditionsManager;

  public PconditionController(IPConditionsManager conditionsManager)
  {
    this.conditionsManager = conditionsManager;
  }


  public async Task<IActionResult> Index(CancellationToken ct)
  {

    return Json(new { pconditions = new SelectList(await conditionsManager.GetAllAsync(ct), "Id", "Name") });

  }

  [Authorize(Roles = "Manager")]
  public IActionResult Management()
  {
    return PartialView("_Management");
  }

  public async Task<IActionResult> Create(PConditionAddViewModel conditionViewModel, CancellationToken ct)
  {
    if (conditionViewModel?.Name != null && conditionViewModel?.Name != "")
    {
      var conditions = await conditionsManager.GetAllAsync(ct);
      conditionViewModel!.Id = conditions.Last().Id + 1;
      await conditionsManager.AddAsync(new PConditionAddDTO
      {
        Id = conditionViewModel.Id,
        Name = conditionViewModel.Name.Trim()
      });
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await conditionsManager.DeleteAsync(id);
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }


}
