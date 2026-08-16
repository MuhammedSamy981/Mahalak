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
public class PcategoryController : Controller
{
    private readonly IPCategoriesManager categoriesManager;

    public PcategoryController(IPCategoriesManager categoriesManager)
    {
        this.categoriesManager = categoriesManager;
    }

    
    public async Task<IActionResult> Index(CancellationToken ct)
    {

       return Json(new { pcategories = new SelectList(await categoriesManager.GetAllAsync(ct), "Id", "Name") });

    }
    
    [Authorize(Roles = "Manager")]
      public IActionResult Management()
    {
        return PartialView("_Management");
    }


      public async Task<IActionResult> Create(PCategoryAddViewModel categoryViewModel, CancellationToken ct)
  {
    if (categoryViewModel?.Name != null && categoryViewModel?.Name != ""
    && categoryViewModel?.SCategoryId != null && categoryViewModel?.SCategoryId != 0)
    {
      var categories = await categoriesManager.GetAllAsync(ct);
      categoryViewModel!.Id = categories.Last().Id + 1;
      await categoriesManager.AddAsync(new PCategoryAddDTO
    {
      Id = categoryViewModel.Id,
      Name = categoryViewModel.Name.Trim(),
      SCategoryId = categoryViewModel.SCategoryId
    });
      return Json(new { success = true});
    }
      return Json(new { success = false});
  }

  public async Task<IActionResult> Delete(int id)
  {
    if (id != 0)
    {
      await categoriesManager.DeleteAsync(id);
      return Json(new { success = true});
    }
    return Json(new { success = false});
  }


}
