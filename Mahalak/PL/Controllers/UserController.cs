using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Mahalak;

public class UserController : Controller
{
  private readonly IUsersManager usersManager;
  private readonly IShopsManager shopsManager;
  private readonly ISCategoriesManager sCategoriesManager;
  private readonly ISCountriesManager countriesManager;
  private readonly ISCitiesManager citiesManager;
  private readonly ISAreasManager areasManager;
  private readonly IProductsManager productsManager;
  private readonly IPCategoriesManager pCategoriesManager;
  private readonly IPConditionsManager conditionsManager;
  private readonly IRatingsManager ratingsManager;
  private readonly IMailService mailService;

  public UserController(
      IUsersManager usersManager,
      IShopsManager shopsManager,
      ISCategoriesManager sCategoriesManager,
      ISCountriesManager countriesManager,
      ISCitiesManager citiesManager,
      ISAreasManager areasManager,
      IProductsManager productsManager,
      IPCategoriesManager pCategoriesManager,
      IPConditionsManager conditionsManager,
      IRatingsManager ratingsManager,

      IMailService mailService
      )
  {
    this.usersManager = usersManager;
    this.shopsManager = shopsManager;
    this.sCategoriesManager = sCategoriesManager;
    this.countriesManager = countriesManager;
    this.citiesManager = citiesManager;
    this.areasManager = areasManager;
    this.productsManager = productsManager;
    this.pCategoriesManager = pCategoriesManager;
    this.conditionsManager = conditionsManager;
    this.ratingsManager = ratingsManager;

    this.mailService = mailService;
  }

  [Authorize(Roles = "Manger,Admin")]
  [HttpGet]
  [Route("admin")]
  [Route("admin/{table}/{id}")]
  //[Route("adminPage/users/{id}")]
  //[Route("adminPage/shops/{id}")]
  //[Route("adminPage/products/{id}")]
  public async Task<IActionResult> Index(string table, int id)
  {
      
    if(id==0)
    {
      id=1;
    }     
    ViewBag.admins = usersManager.GetAllPaginatedByRole("Admin", 9, 1);

                  ViewBag.users = usersManager.GetAllPaginatedByRole("User", 9, 1);
             ViewBag.UsersCount=(ViewBag.users.Count!=0)?ViewBag.users[0].UsersCount:0;
         ViewBag.shops = shopsManager.GetAllPaginated(9, 1);
          ViewBag.ShopsCount=( ViewBag.shops.Count!=0)? ViewBag.shops[0].ShopsCount:0;

         ViewBag.products = productsManager.GetAllPaginated(9, 1);
            ViewBag.ProductsCount=(ViewBag.products.Count!=0)?ViewBag.products[0].ProductsCount:0;  
           

    ViewBag.AdminsCount=0;     
      
    if (table == "users")
    {
      if (HttpContext.Session.GetString("UserSearch") != null 
      && HttpContext.Session.GetString("UserSearch") != "")
      {
        ViewBag.users = usersManager.GetAllPaginatedByEmailOrPhone(HttpContext.Session.GetString("UserSearch")!,
        9, id);
        
        ViewBag.UsersCount=(ViewBag.users.Count!=0)?ViewBag.users[0].UsersCount:0;
      }
      else
      {
        ViewBag.users = usersManager.GetAllPaginatedByRole("User", 9, id);
        ViewBag.UsersCount=(ViewBag.users.Count!=0)?ViewBag.users[0].UsersCount:0;
      }
    }

     

   if (table == "shops")
    {
      if (HttpContext.Session.GetString("ShopSearch") != null 
      && HttpContext.Session.GetString("ShopSearch") != "")
      {
        ViewBag.shops = shopsManager.GetAllPaginatedByName(HttpContext.Session.GetString("ShopSearch") !, 9, id);
        ViewBag.ShopsCount=(ViewBag.shops.Count!=0)?ViewBag.shops[0].ShopsCount:0;
      }


      else
      {
        ViewBag.shops = shopsManager.GetAllPaginated(9, id);
         ViewBag.ShopsCount=(ViewBag.shops.Count!=0)?ViewBag.shops[0].ShopsCount:0;
      }
    }

      

    if (table == "products")
    {
      if (HttpContext.Session.GetString("ProductSearch") != null
       && HttpContext.Session.GetString("ProductSearch") != "")
      {
        ViewBag.products = productsManager.GetAllPaginatedByName(HttpContext.Session.GetString("ProductSearch") !,
        9, id);
        ViewBag.ProductsCount=(ViewBag.products.Count!=0)?ViewBag.products[0].ProductsCount:0;
      }
      else
      {
        ViewBag.products = productsManager.GetAllPaginated(9, id);
           ViewBag.ProductsCount=(ViewBag.products.Count!=0)?ViewBag.products[0].ProductsCount:0;
      }
    }

 
         
  

    


    ViewBag.ratings = await ratingsManager.GetAllWithCommentsInWaiting();

    ViewBag.sCategories = new SelectList(sCategoriesManager.GetAll(), "ID", "Name", 0);
    ViewBag.countries = new SelectList(countriesManager.GetAll(), "ID", "Name", 0);
    ViewBag.cities = new SelectList(citiesManager.GetAll(), "ID", "Name", 0);
    ViewBag.areas = new SelectList(areasManager.GetAll(), "ID", "Name", 0);
    ViewBag.pCategories = new SelectList(pCategoriesManager.GetAll(), "ID", "Name", 0);
    ViewBag.conditions = new SelectList(conditionsManager.GetAll(), "ID", "Name", 0);
    return View();
  }

  [HttpPost]
  [Route("admin")]
    [Route("admin/{table}/{id}")]
  public async Task<IActionResult> Index(GetAllAdminPermissiosDTO adminPermissios,
    Microsoft.AspNetCore.Http.IFormCollection formcollection)
  {
    HttpContext.Session.SetString("UserSearch","" + formcollection["UserSearch"]);

     if (HttpContext.Session.GetString("UserSearch") != null 
        && HttpContext.Session.GetString("UserSearch") != "")
        {
          HttpContext.Session.SetString("ProductSearch","");
          HttpContext.Session.SetString("ShopSearch","");
          return RedirectToAction("users","admin", new { id = 1 });
        }

    HttpContext.Session.SetString("ShopSearch",""+ formcollection["ShopSearch"]);

         if (HttpContext.Session.GetString("ShopSearch") != null 
        && HttpContext.Session.GetString("ShopSearch") != "")
        {
          HttpContext.Session.SetString("ProductSearch","");
          HttpContext.Session.SetString("UserSearch","");
          return RedirectToAction("shops","admin", new { id = 1 });
        }

    HttpContext.Session.SetString("ProductSearch",""+ formcollection["ProductSearch"]);

         if (HttpContext.Session.GetString("ProductSearch") != null 
        && HttpContext.Session.GetString("ProductSearch") != "")
        {
          HttpContext.Session.SetString("ShopSearch","");
          HttpContext.Session.SetString("UserSearch","");
          return RedirectToAction("products","admin", new { id = 1 });
        }
    

    if (adminPermissios.SCategory?.Name != null && adminPermissios.SCategory?.Name != "")
    {
      adminPermissios.SCategory!.ID = sCategoriesManager.GetAll().Last().ID + 1;
      sCategoriesManager.Add(adminPermissios.SCategory);
    }

    else
    if (adminPermissios.SCategory?.ID != null && adminPermissios.SCategory?.ID != 0)
    {
      //Console.WriteLine("\n"+adminPermissios.SCategory?.ID+"\n");
      sCategoriesManager.Delete(adminPermissios.SCategory!.ID);
    }

    else
    if (adminPermissios.Country?.Name != null && adminPermissios.Country?.Name != "")
    {
      adminPermissios.Country!.ID = countriesManager.GetAll().Last().ID + 1;
      countriesManager.Add(adminPermissios.Country);

    }

    else
    if (adminPermissios.Country?.ID != null && adminPermissios.Country?.ID != 0)
    {
      countriesManager.Delete(adminPermissios.Country!.ID);
    }

    else
    if (adminPermissios.City?.Name != null && adminPermissios.City?.Name != "")
    {
      adminPermissios.City!.ID = citiesManager.GetAll().Last().ID + 1;
      citiesManager.Add(adminPermissios.City);
    }

    else
    if (adminPermissios.City?.ID != null && adminPermissios.City?.ID != 0)
    {
      citiesManager.Delete(adminPermissios.City!.ID);
    }

    else
    if (adminPermissios.Area?.Name != null && adminPermissios.Area?.Name != "")
    {
      adminPermissios.Area!.ID = areasManager.GetAll().Last().ID + 1;
      areasManager.Add(adminPermissios.Area);
    }

    else
    if (adminPermissios.Area?.ID != null && adminPermissios.Area?.ID != 0)
    {
      areasManager.Delete(adminPermissios.Area!.ID);
    }

    else
    if (adminPermissios.PCategory?.Name != null && adminPermissios.PCategory?.Name != "")
    {
      adminPermissios.PCategory!.ID = pCategoriesManager.GetAll().Last().ID + 1;
      pCategoriesManager.Add(adminPermissios.PCategory);
    }

    else
    if (adminPermissios.PCategory?.ID != null && adminPermissios.PCategory?.ID != 0)
    {
      pCategoriesManager.Delete(adminPermissios.PCategory!.ID);
    }

    else
    if (adminPermissios.Condition?.Name != null && adminPermissios.Condition?.Name != "")
    {
      adminPermissios.Condition!.ID = conditionsManager.GetAll().Last().ID + 1;
      conditionsManager.Add(adminPermissios.Condition);
    }

    else
    if (adminPermissios.Condition?.ID != null && adminPermissios.Condition?.ID != 0)
    {
      conditionsManager.Delete(adminPermissios.Condition!.ID);
    }

    else
    if (adminPermissios.User?.EmailOrPhoneNumber != null && adminPermissios.User?.EmailOrPhoneNumber != ""
    && adminPermissios.User?.AdminPassword != null && adminPermissios.User?.AdminPassword != "")
    {
      TempData["ForgottenPassword"] = usersManager
      .GetForgottenPassword(adminPermissios.User!.EmailOrPhoneNumber)!;
    }

    else
    if (adminPermissios.DistinctivePeriod != null && adminPermissios.DistinctivePeriod != "0")
    {
      string[] shopValues = adminPermissios.DistinctivePeriod.Split("-");
      //Console.WriteLine("\n"+shopValues[0]+"\n");
      int shopId = int.Parse(shopValues[0]);
      int period = int.Parse(shopValues[1]);
     await shopsManager.EditDistinctive(shopId, true, period);
    }
    else
    if (adminPermissios.AddingShopsCount != null && adminPermissios.AddingShopsCount != "0"
    && adminPermissios.AddingShopsPeriod != null && adminPermissios.AddingShopsPeriod != 0)
    {
      string[] addingShops = adminPermissios.AddingShopsCount.Split("-");
      Guid userId = Guid.Parse(addingShops[0]);
      int shopsCount = int.Parse(addingShops[1]);
      int period = adminPermissios.AddingShopsPeriod.Value;
     await usersManager.EditAddingShops(userId, shopsCount, period);
    }

    return RedirectToAction("index");

  }

  [Authorize(Roles = "User")]
  public IActionResult Details(Guid? id)
  {
    if (id == null)
    {
      return BadRequest();
    }
    var user = usersManager.GetById(id);
    if (user == null)
    {
      return NotFound();
    }
    return View(user);
  }

  public IActionResult LogIn()
  {
    //ViewBag.ExpDtOfBan=HttpContext.Session.GetString("ExpDtOfBan");
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> LogIn(GetUserLoginDTO userLoginDTO)
  {
    var user = usersManager.GetLogin(userLoginDTO.EmailOrPhoneNumber, userLoginDTO.Password);
    if (user != null && user.Status)
    {
      HttpContext.Session.SetString("ExpDtOfBan", user.ExpDtOfBan);
      ViewBag.ExpDtOfBan = Convert.ToDateTime(user.ExpDtOfBan).DayOfYear - DateTime.Now.DayOfYear;
      return View();
    }

    else if (user == null || !ModelState.IsValid)
    {
      ModelState.AddModelError("", "برجاء التأكد من صحة البريد الألكترونى أو رقم الهاتف أو التأكد من صحة كلمة المرور");
      return View(userLoginDTO);
    }


    await HttpContext.SignInAsync(user.CP!);

    //var Id=Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    //HttpContext.Session.SetInt32("UserID", user.UserID);

    //TempData["UserID"]=user.UserID;
    if (user.CP!.IsInRole("Manger") || user.CP!.IsInRole("Admin"))
    {
      return RedirectToAction("index", "user");
    }

    return RedirectToAction("ViewForCustumers", "Shop");

  }

  public async Task<IActionResult> LogOut()
  {
    await HttpContext.SignOutAsync();
    //HttpContext.Session.SetInt32("UserID", 0);
    //TempData["UserID"]=0;

    return RedirectToAction("ViewForCustumers", "Shop");
  }


  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyName(string name)
  {
    if (!usersManager.VerifyField(name, "Name"))
    {
      return Json($"أسم المستخدم {name} مستخدم مسبقا برجاء أدخال أسم مستخدم أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyEmail(string email)
  {
    if (!usersManager.VerifyField(email, "Email"))
    {

      return Json($"البريد الألكترونى {email} مستخدم مسبقا برجاء أدخال بريد إلكترونى أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyPhone(string phone)
  {
    if (!usersManager.VerifyField(phone, "Phone"))
    {

      return Json($"رقم الهاتف {phone} مستخدم مسبقا برجاء أدخال رقم هاتف أخر");
    }

    return Json(true);
  }


  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(AddUserDTO userDTO)
  {
    if (ModelState.IsValid)
    {
      usersManager.Add(userDTO);
      var user = usersManager.GetLogin(userDTO.Email, userDTO.Password);
      await HttpContext.SignInAsync(user?.CP!);
      return RedirectToAction("ViewForCustumers", "Shop");
    }
    return View();
  }

  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyEditName(string name)
  {
    if (!usersManager.VerifyEditField(name, "Name", usersManager.GetIdByName(User.Identity?.Name!)))
    {

      return Json($"أسم المستخدم {name} مستخدم مسبقا برجاء أدخال أسم مستخدم أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyEditEmail(string email)
  {
    if (!usersManager.VerifyEditField(email, "Email", usersManager.GetIdByName(User.Identity?.Name!)))
    {

      return Json($"البريد الألكترونى {email} مستخدم مسبقا برجاء أدخال بريد إلكترونى أخر");
    }

    return Json(true);
  }

  [AcceptVerbs("GET", "POST")]
  public IActionResult VerifyEditPhone(string phone)
  {
    if (!usersManager.VerifyEditField(phone, "Phone", usersManager.GetIdByName(User.Identity?.Name!)))
    {

      return Json($"رقم الهاتف {phone} مستخدم مسبقا برجاء أدخال رقم هاتف أخر");
    }

    return Json(true);
  }

    [Authorize(Roles ="User")]
  [HttpGet]
  public IActionResult Edit()
  {
    Guid id = usersManager.GetIdByName(User.Identity?.Name!);
    var user = usersManager.GetById(id);
    if (user == null)
    {
      return NotFound();
    }
    return View(new UpdateUserDTO
    {
      Name = user.Name,
      Password = user.Password,
      Gender = user.Gender,
      Phone = user.Phone,
      Birthdate = user.Birthdate,
      Email = user.Email
    });
  }


  [HttpPost]
  public async Task<IActionResult> Edit(UpdateUserDTO userDTO)
  {
    if (ModelState.IsValid)
    {
      userDTO.ID = usersManager.GetIdByName(User.Identity?.Name!);
      Console.WriteLine("\n" + userDTO.ID + "\n");
      bool resut = usersManager.Update(userDTO);
      if (!resut)
      {
        return View(userDTO);
      }
      await HttpContext.SignOutAsync();
      return RedirectToAction("ViewForCustumers", "Shop");

    }
    return View();
  }


  public async Task<IActionResult> BlockUser(Guid id)
  {
     await usersManager.EditStatus(id, true);
    return RedirectToAction("Index");
  }


  public async Task<IActionResult> UnBlockUser(Guid id)
  {
   await usersManager.EditStatus(id, false);
    return RedirectToAction("Index");
  }

  public IActionResult AcceptClientComment(int id)
  {
    usersManager.EditClientCommentStatus(id, "مقبول");
    return RedirectToAction("Index");
  }

  public IActionResult RemoveClientComment(int id)
  {
    usersManager.EditClientCommentStatus(id, "مرفوض");
    return RedirectToAction("Index");
  }


  public IActionResult Delete(Guid id)
  {
    usersManager.Delete(id);
    return RedirectToAction("Index");
  }

  public IActionResult RecoveringPassword()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> RecoveringPassword(GetForgottenUserPasswordDTO getForgottenUserPasswordDTO)
  {

    if (ModelState.IsValid)
    {
      bool result = await usersManager.ResetPassword(getForgottenUserPasswordDTO);
      if (result)
      {
        return RedirectToAction("ViewForCustumers", "Shop");
      }
      else
      {
        return View();
      }
    }
    return View();
  }

  public async Task<IActionResult> RemoveAddingShops(Guid id)
  {
    await usersManager.EditAddingShops(id, 2, 0);
    return RedirectToAction("index");
  }

  public IActionResult ChangeToAdmin(Guid id)
  {
    usersManager.EditRole(id, "Admin");
    return RedirectToAction("index");
  }

  public IActionResult ChangeToUser(Guid id)
  {
    usersManager.EditRole(id, "User");
    return RedirectToAction("index");
  }


}
