using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Mahalak;

public class UserController : Controller
{
  public int adminsPageSize = 9;
  public int usersPageSize = 9;
  public int shopsPageSize = 9;
  public int productsPageSize = 9;
  // public static int clickCount = 0;
  private readonly IUsersManager usersManager;
  private readonly IShopsManager shopsManager;
  private readonly ISCategoriesManager sCategoriesManager;
  private readonly ISCountriesManager countriesManager;
  private readonly ISCitiesManager citiesManager;
  private readonly ISAreasManager areasManager;
  private readonly IProductsManager productsManager;
  private readonly IProductImagesManager productImagesManager;
  private readonly IPCategoriesManager pCategoriesManager;
  private readonly IPConditionsManager conditionsManager;
  private readonly IRatingsManager ratingsManager;
  private readonly IMailManager mailManager;
  private readonly IIpApiService ipApiService;

  public UserController(
    IUsersManager usersManager,
    IShopsManager shopsManager,
    ISCategoriesManager sCategoriesManager,
    ISCountriesManager countriesManager,
    ISCitiesManager citiesManager,
    ISAreasManager areasManager,
    IProductsManager productsManager,
    IPCategoriesManager pCategoriesManager,
    IProductImagesManager productImagesManager,
    IPConditionsManager conditionsManager,
    IRatingsManager ratingsManager,
    IMailManager mailManager,
    IIpApiService ipApiService)
  {
    this.usersManager = usersManager;
    this.shopsManager = shopsManager;
    this.sCategoriesManager = sCategoriesManager;
    this.countriesManager = countriesManager;
    this.citiesManager = citiesManager;
    this.areasManager = areasManager;
    this.productsManager = productsManager;
    this.productImagesManager = productImagesManager;
    this.pCategoriesManager = pCategoriesManager;
    this.conditionsManager = conditionsManager;
    this.ratingsManager = ratingsManager;
    this.mailManager = mailManager;
    this.ipApiService = ipApiService;
  }

  [Authorize(Roles = "Manager,Admin")]
  [HttpGet]
  public IActionResult Management()
  {
    //await usersManager.RemoveAllInactive();
    return View();
  }

  public async Task<IActionResult> GetPaginatedAdminManagementTable(string? adminEmailOrAdminPhoneNumber, CancellationToken ct)
  {
    HttpContext.Session.SetString("AdminEmailOrAdminPhoneNumber", adminEmailOrAdminPhoneNumber ?? "");
    ViewBag.AdminsPageSize = adminsPageSize;
    if (adminEmailOrAdminPhoneNumber != null && adminEmailOrAdminPhoneNumber != "")
    {
      ViewBag.AdminsCount = await usersManager.GetSearchResultCountAsync("Admin", adminEmailOrAdminPhoneNumber, ct);
    }
    else
    {
      ViewBag.AdminsCount = await usersManager
  .GetCountByRoleAsync("Admin");
    }
    return PartialView("_PaginatedAdminManagementTable");

  }


  public async Task<IActionResult> GetAdminManagementTable(int? id, CancellationToken ct)
  {
    //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
    int currentTablePage = id ?? 1;

    string? adminEmailOrAdminPhoneNumber = HttpContext.Session.GetString("AdminEmailOrAdminPhoneNumber");

    if (adminEmailOrAdminPhoneNumber != null && adminEmailOrAdminPhoneNumber != "")
    {
      var admins = await usersManager.GetPaginatedByEmailOrPhoneNumberAsync(currentTablePage,
       adminsPageSize, "Admin", adminEmailOrAdminPhoneNumber, ct);
      return PartialView("_AdminManagementTable", admins.Select(u => new UserViewModel
      {
        Id = u.Id,
        FullName = u.FirstName + " " + u.LastName,
        PhoneNumber = u.PhoneNumber!,
        Email = u.Email!,
        EmailConfirmed = u.EmailConfirmed,
        RoleName = u.RoleName,
        MaxShopNum = u.MaxShopNum,
        AddedShopsExpiryDate = u.AddedShopsExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        LoginTime = u.LoginTime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        IsBlocked = u.IsBlocked,
        ViolationsCount = u.ViolationsCount,
      }).ToList());
    }
    else
    {
      var admins = await usersManager
    .GetPaginatedByRoleAsync(currentTablePage, adminsPageSize, "Admin", ct);


      return PartialView("_AdminManagementTable", admins.Select(u => new UserViewModel
      {
        Id = u.Id,
        FullName = u.FirstName + " " + u.LastName,
        PhoneNumber = u.PhoneNumber!,
        Email = u.Email!,
        EmailConfirmed = u.EmailConfirmed,
        RoleName = u.RoleName,
        MaxShopNum = u.MaxShopNum,
        AddedShopsExpiryDate = u.AddedShopsExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        LoginTime = u.LoginTime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        IsBlocked = u.IsBlocked,
        ViolationsCount = u.ViolationsCount,
      }).ToList());
    }

  }


  //[Route("PaginatedUsers/{table}/{role}/{id}")]
  public async Task<IActionResult> GetPaginatedUserManagementTable(string? userEmailOrUserPhoneNumber, CancellationToken ct)
  {
    //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
    HttpContext.Session.SetString("UserEmailOrUserPhoneNumber", userEmailOrUserPhoneNumber ?? "");
    ViewBag.UsersPageSize = usersPageSize;
    if (userEmailOrUserPhoneNumber != null && userEmailOrUserPhoneNumber != "")
    {
      ViewBag.UsersCount = await usersManager.GetSearchResultCountAsync("User", userEmailOrUserPhoneNumber, ct);
    }
    else
    {

      ViewBag.UsersCount = await usersManager
  .GetCountByRoleAsync("User", ct);
    }
    return PartialView("_PaginatedUserManagementTable");

  }

  public async Task<IActionResult> GetUserManagementTable(int? id, CancellationToken ct)
  {
    //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
    int currentTablePage = id ?? 1;

    string? userEmailOrUserPhoneNumber = HttpContext.Session.GetString("UserEmailOrUserPhoneNumber");

    if (userEmailOrUserPhoneNumber != null && userEmailOrUserPhoneNumber != "")
    {
      var users = await usersManager.GetPaginatedByEmailOrPhoneNumberAsync(currentTablePage,
       usersPageSize, "User", userEmailOrUserPhoneNumber, ct);
      return PartialView("_UserManagementTable", users.Select(u => new UserViewModel
      {
        Id = u.Id,
        FullName = u.FirstName + " " + u.LastName,
        PhoneNumber = u.PhoneNumber!,
        Email = u.Email!,
        EmailConfirmed = u.EmailConfirmed,
        RoleName = u.RoleName,
        MaxShopNum = u.MaxShopNum,
        AddedShopsExpiryDate = u.AddedShopsExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        LoginTime = u.LoginTime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        IsBlocked = u.IsBlocked,
        ViolationsCount = u.ViolationsCount,
      }).ToList());
    }
    else
    {
      var users = await usersManager
    .GetPaginatedByRoleAsync(currentTablePage, usersPageSize, "User", ct);


      return PartialView("_UserManagementTable", users.Select(u => new UserViewModel
      {
        Id = u.Id,
        FullName = u.FirstName + " " + u.LastName,
        PhoneNumber = u.PhoneNumber!,
        Email = u.Email!,
        EmailConfirmed = u.EmailConfirmed,
        RoleName = u.RoleName,
        MaxShopNum = u.MaxShopNum,
        AddedShopsExpiryDate = u.AddedShopsExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        LoginTime = u.LoginTime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        IsBlocked = u.IsBlocked,
        ViolationsCount = u.ViolationsCount,
      }).ToList());
    }

    //return Json(new { data = "id:"+id+",table:"+table+",role:"+role});
  }


  public async Task<IActionResult> ChangeCountShopsLimit(string addingShopsCount, int addingShopsPeriod)
  {

    if (addingShopsCount != null && addingShopsCount != "0"
    && addingShopsPeriod != 0)
    {
      string[] addingShops = addingShopsCount.Split("~");
      string userId = addingShops[0];
      int shopsCount = int.Parse(addingShops[1]);
      int period = addingShopsPeriod;
      bool result = await usersManager.EditAddingShopsAsync(userId, shopsCount, period);

      if (result)
      {
        return Json(new { success = true });
      }
    }
    return Json(new { success = false });
  }





  public async Task<IActionResult> LogIn(CancellationToken ct)
  {

    #region Get current user's country
    var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
    HttpContext.Connection.RemoteIpAddress?.ToString();
    var ipApiResponse = await ipApiService.Get(ipAddress, ct);
    #endregion

    int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      countryId = 1;
    }
    if (countryId != null && countryId != 0)
    {
      var schemes = await usersManager.GetExternalAuthenticationSchemesAsync();
      if (schemes != null)
      {
        var getUserLoginViewModel = new UserLoginViewModel()
        {
          Schemes = await usersManager.GetExternalAuthenticationSchemesAsync()
        };
        return View(getUserLoginViewModel);
      }
      return View();
    }

    return NotFound();

  }

  [HttpPost]
  public async Task<IActionResult> LogIn(UserLoginViewModel userLoginViewModel)
  {

    userLoginViewModel.Schemes = await usersManager.GetExternalAuthenticationSchemesAsync();

    var isEmailExists = await usersManager.CheckEmailExistsAsync(userLoginViewModel.Email);

    if (!isEmailExists)
    {
      ModelState.AddModelError("", "هذا البريد الألكترونى غير مسجل لدينا");
      return View(userLoginViewModel);
    }

    var emailConfirmed = await usersManager.CheckEmailConfirmedAsync(userLoginViewModel.Email);
    if (emailConfirmed == false)
    {
      TempData["UserEmailConfirmed"] = emailConfirmed;

      var token = await usersManager.GenerateConfirmationTokenAsync(userLoginViewModel.Email);

      var confirmationLink = Url.Action("ActiveAccount", "User",
     new { email = userLoginViewModel.Email, token = token }, Request.Scheme);

      await mailManager.SendVerificationLinkAsync(userLoginViewModel.Email, confirmationLink!);
      return View(userLoginViewModel);
    }

    var user = await usersManager.GetLogInAsync(userLoginViewModel.Email, userLoginViewModel.Password);

    if (user == null || !ModelState.IsValid)
    {
      Console.WriteLine("\n\nkkkkkk" + "user" + "\n\n");
      ModelState.AddModelError("", "برجاء التأكد من صحة البريد الألكترونى أو رقم الهاتف أو التأكد من صحة كلمة المرور");
      return View(userLoginViewModel);
    }

    //HttpContext.Session.SetString("BanExpiryDate", user.BanExpiryDate);

    Console.WriteLine("\n\nkkkkkk" + user.IsBlocked + "\n\n");
    if (user.IsBlocked == true)
    {
      TempData["UserIsBlocked"] = user.IsBlocked;
      Console.WriteLine("/n/n" + user.BanExpiryDate + "/n/n");
      if (user.BanExpiryDate != null)
      {
        TempData["BanExpiryDate"] = Convert.ToDateTime(user.BanExpiryDate).DayOfYear - DateTime.Now.DayOfYear;
      }
      return View(userLoginViewModel);
    }

    //await HttpContext.SignInAsync();

    //var id=Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    //HttpContext.Session.SetInt32("UserId", user.UserId);

    //TempData["UserId"]=user.UserId;

    if (User.IsInRole("Manager") || User.IsInRole("Admin"))
    {
      return RedirectToAction("Management", "User");
    }

    return RedirectToAction("Index", "Home");


  }

  public IActionResult ExternalLogin()
  {
    var provider = "Google";
    var redirectUrl = Url.Action("ExternalLoginCallback", "User");
    return usersManager.GetExternalLogin(provider, redirectUrl!);
  }


  public async Task<IActionResult> ExternalLoginCallback(string remoteError = "")
  {
    var userLoginViewModel = new UserLoginViewModel()
    {
      Schemes = await usersManager.GetExternalAuthenticationSchemesAsync()
    };

    if (!string.IsNullOrEmpty(remoteError))
    {
      //ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
      TempData["ExternalLoginCallbackError"] = true;
      return RedirectToAction("login");
    }

    //Get login info
    var user = await usersManager.GetExternalLoginCallback();
    if (user == null)
    {
      //ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
      TempData["ExternalLoginCallbackError"] = true;
      return RedirectToAction("login");
    }

    if (user.IsBlocked == true)
    {
      await usersManager.GetLogOutAsync();
      TempData["UserIsBlocked"] = user.IsBlocked;
      Console.WriteLine("/n/n" + user.BanExpiryDate + "/n/n");
      if (user.BanExpiryDate != null)
      {
        TempData["BanExpiryDate"] = Convert.ToDateTime(user.BanExpiryDate).DayOfYear - DateTime.Now.DayOfYear;
      }
      return RedirectToAction("login");
    }
    //await HttpContext.SignInAsync(user.CP!);
    return RedirectToAction("Index", "Home");
  }


  public async Task<IActionResult> LogOut()
  {
    await usersManager.GetLogOutAsync();
    //await HttpContext.SignOutAsync();
    //HttpContext.Session.SetInt32("UserId", 0);
    //TempData["UserId"]=0;

    return RedirectToAction("Index", "Home");
  }


  [AcceptVerbs("GET", "POST")]
  public async Task<IActionResult> VerifyName(string name)
  {
    if (!await usersManager.VerifyFieldAsync(name, "Name"))
    {
      return Json($"أسم المستخدم {name} مستخدم مسبقا برجاء أدخال أسم مستخدم أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public async Task<IActionResult> VerifyEmail(string email)
  {
    if (!await usersManager.VerifyFieldAsync(email, "Email"))
    {

      return Json($"البريد الألكترونى {email} مستخدم مسبقا برجاء أدخال بريد إلكترونى أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public async Task<IActionResult> VerifyPhoneNumber(string PhoneNumber)
  {
    if (!await usersManager.VerifyFieldAsync(PhoneNumber, "PhoneNumber"))
    {

      return Json($"رقم الهاتف {PhoneNumber} مستخدم مسبقا برجاء أدخال رقم هاتف أخر");
    }

    return Json(true);
  }

  public async Task<IActionResult> Register(CancellationToken ct)
  {
    #region Get current user's country
    var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
    HttpContext.Connection.RemoteIpAddress?.ToString();
    var ipApiResponse = await ipApiService.Get(ipAddress, ct);
    #endregion

    int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      countryId = 1;
    }

    if (countryId != null && countryId != 0)
    {
      return View();
    }
    else
    {
      return NotFound();
    }
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Register(UserRegisterViewModel userViewModel)
  {
    if (ModelState.IsValid)
    {

      bool result = await usersManager.AddAsync(new UserRegisterDTO
      {
        FirstName = userViewModel.FirstName,
        LastName = userViewModel.LastName,
        Email = userViewModel.Email,
        PhoneNumber = userViewModel.PhoneNumber,
        Password = userViewModel.Password
      });
      if (!result)
      {
        return View();
      }

      var token = await usersManager.GenerateConfirmationTokenAsync(userViewModel.Email);

      var confirmationLink = Url.Action("ActiveAccount", "User",
new { email = userViewModel.Email, token = token }, Request.Scheme);

      await mailManager.SendVerificationLinkAsync(userViewModel.Email, confirmationLink!);

      return RedirectToAction("Index", "Home");
    }
    return View();
  }


  /*  [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifyEditName(string name)
    {
      if (!await usersManager.VerifyEditFieldAsync(name, "Name", await usersManager.GetIdByNameAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!)))
      {

        return Json($"أسم المستخدم {name} مستخدم مسبقا برجاء أدخال أسم مستخدم أخر");
      }

      return Json(true);
    }*/

  [AcceptVerbs("GET", "POST")]
  public async Task<IActionResult> VerifyEditEmail(string email)
  {
    if (!await usersManager.VerifyEditFieldAsync(email, "Email", User.FindFirstValue(ClaimTypes.NameIdentifier)!))
    {
      return Json($"البريد الألكترونى {email} مستخدم مسبقا برجاء أدخال بريد إلكترونى أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public async Task<IActionResult> VerifyEditPhoneNumber(string PhoneNumber)
  {
    if (!await usersManager.VerifyEditFieldAsync(PhoneNumber, "PhoneNumber", User.FindFirstValue(ClaimTypes.NameIdentifier)!))
    {
      return Json($"رقم الهاتف {PhoneNumber} مستخدم مسبقا برجاء أدخال رقم هاتف أخر");
    }

    return Json(true);
  }

  [Authorize(Roles = "User")]
  [HttpGet]
  public async Task<IActionResult> Edit()
  {
    string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (id == null)
    {
      return BadRequest();
    }
    var user = await usersManager.GetByIdAsync(id);
    if (user == null)
    {
      return NotFound();
    }

    return View(new UserUpdateViewModel
    {
      FirstName = user.FirstName,
      LastName = user.LastName,
      PhoneNumber = user.PhoneNumber,
      Email = user.Email
    });
  }


  [HttpPost]
  public async Task<IActionResult> Edit(UserUpdateViewModel userViewModel)
  {
    if (ModelState.IsValid)
    {
      if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
      {
        return BadRequest();
      }
      userViewModel.Id = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
      Console.WriteLine("\n" + userViewModel.Id + "\n");
      bool result = await usersManager.UpdateAsync(new UserUpdateDTO
      {
        Id = userViewModel.Id,
        FirstName = userViewModel.FirstName,
        LastName = userViewModel.LastName,
        PhoneNumber = userViewModel.PhoneNumber,
        Email = userViewModel.Email
      });
      if (!result)
      {
        return View(userViewModel);
      }
      var accessToken = HttpContext.Session.GetString("AccessToken");

      //await mailManager.SendVerificationLinkAsync(userViewModel.Email, accessToken);
      await usersManager.GetLogOutAsync();
      await HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");

    }
    return View();
  }

  [Authorize(Roles = "Manager,Admin")]
  public async Task<IActionResult> Delete(string id, string role)
  {
    await usersManager.DeleteAsync(id);

    if (role == "admin")
    {
      ViewBag.AdminsPageSize = adminsPageSize;
      ViewBag.AdminsCount = await usersManager
  .GetCountByRoleAsync("Admin");
      return PartialView("_PaginatedAdminManagementTable");
    }
    else
    {
      ViewBag.UsersPageSize = usersPageSize;
      ViewBag.UsersCount = await usersManager
  .GetCountByRoleAsync("User");
      return PartialView("_PaginatedUserManagementTable");
    }
  }

  public async Task<IActionResult> ActiveAccount(string email, string token)
  {
    var result = await usersManager.EditEmailConfirmedAsync(email!, token);
    if (result)
    {
      await usersManager.GetLogInAsync(email);
    }

    return RedirectToAction("Index", "Home");
  }


  [Authorize(Roles = "Manager,Admin")]
  public async Task<IActionResult> BlockUser(string id)
  {
    bool result = await usersManager.EditIsBlockedAsync(id, true);
    if (result)
    {
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }



  [Authorize(Roles = "Manager,Admin")]
  public async Task<IActionResult> UnBlockUser(string id)
  {
    bool result = await usersManager.EditIsBlockedAsync(id, false);

    if (result)
    {
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }



  public async Task<IActionResult> ResetPassword(CancellationToken ct)
  {
    var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
   HttpContext.Connection.RemoteIpAddress?.ToString();

    var ipApiResponse = await ipApiService.Get(ipAddress, ct);

    int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      countryId = 1;
    }
    if (countryId != null && countryId != 0)
    {
      return View();
    }
    else
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<IActionResult> ResetPassword(ForgotPasswordViewModel forgotPasswordViewModel)
  {
    bool checkLoginResult = await usersManager.CheckLoginTypeAsync(forgotPasswordViewModel.Email);
    if (checkLoginResult)
    {
      TempData["IsExternallyLoggedIn"] = true;
      return View();
    }

    if (ModelState.IsValid)
    {
      var accessToken = HttpContext.Session.GetString("AccessToken");
      Console.WriteLine("\n\n\naccessToken:" + accessToken);
      /*         if (string.IsNullOrEmpty(accessToken))
                  return RedirectToAction("Login", "Auth");*/
      var token = await usersManager.GeneratePasswordResetTokenAsync(forgotPasswordViewModel.Email);
      var resetPasswordLink = Url.Action("CreateNewPassword", "User",
    new { email = forgotPasswordViewModel.Email, token = token }, Request.Scheme);

      bool result = await mailManager.SendResetPasswordLinkAsync(forgotPasswordViewModel.Email, resetPasswordLink!);
      if (result)
      {
        TempData["IsEmailSent"] = true;
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }
    return View();
  }


  public async Task<IActionResult> CreateNewPassword(string? email, string? token, CancellationToken ct)
  {
    #region Get current user's country
    var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
    HttpContext.Connection.RemoteIpAddress?.ToString();
    var ipApiResponse = await ipApiService.Get(ipAddress, ct);
    #endregion

    int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      countryId = 1;
    }
    if (countryId != null && countryId != 0 && email != null && token != null)
    {
      return View(new UserPasswordResetViewModel
      {
        Email = email,
        Token = token
      });
    }
    else
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateNewPassword(UserPasswordResetViewModel userPasswordResetViewModel)
  {
    if (ModelState.IsValid)
    {
      bool result = await usersManager.ResetPasswordAsync(userPasswordResetViewModel.Email, userPasswordResetViewModel.Token, userPasswordResetViewModel.NewPassword);
      if (!result)
      {
        return View();
      }

      return RedirectToAction("Index", "Home");
    }
    return View();
  }

  public async Task<IActionResult> RemoveAddingShops(string id)
  {
    bool result = await usersManager.EditAddingShopsAsync(id, 2, 0);
    if (result)
    {
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  [Authorize(Roles = "Manager")]
  public async Task<IActionResult> ChangeToAdmin(string id)
  {
    bool result = await usersManager.EditRoleAsync(id, "Admin");
    if (result)
    {
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }

  [Authorize(Roles = "Manager")]
  public async Task<IActionResult> ChangeToUser(string id)
  {
    bool result = await usersManager.EditRoleAsync(id, "User");

    if (result)
    {
      return Json(new { success = true });
    }
    return Json(new { success = false });
  }


}
