using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Mahalak;
public class ShopController : Controller
{
    private readonly IUsersManager usersManager;
    private readonly IShopsManager shopsManager;
    private readonly ISCategoriesManager categoriesManager;
    private readonly ISCountriesManager countriesManager;
    private readonly ISCitiesManager citiesManager;
    private readonly ISAreasManager areasManager;
    private readonly IRatingsManager ratingsManager;
    private int currentPage;
    private int totalPages;

    public ShopController(IShopsManager shopsManager
    , ISCategoriesManager categoriesManager
    , ISCountriesManager countriesManager
    , ISCitiesManager citiesManager
    , ISAreasManager areasManager
    , IRatingsManager ratingsManager
    , IUsersManager usersManager
    )
    {
        this.usersManager = usersManager;
        this.shopsManager = shopsManager;
        this.categoriesManager = categoriesManager;
        this.countriesManager = countriesManager;
        this.citiesManager = citiesManager;
        this.areasManager = areasManager;
        this.ratingsManager = ratingsManager;
    }


    [Authorize(Roles = "User")]
    public IActionResult Index(int? id)
    {
        TempData["ShopName"] = "" ;
        TempData["Category"] = "" ;
        TempData["Country"] = "" ;
        TempData["City"] = "" ;
        TempData["Area"] = "" ;

        if (id == null)
        {
           return NotFound();
        }
        Guid userId = usersManager.GetIdByName(User.Identity?.Name!);
        var shops = shopsManager.GetAllPaginatedByUserId(userId, 9, id!.Value);
        ViewBag.ShopsCount=(shops.Count!=0)?shops[0].ShopsCount:0;
        var user=usersManager.GetById(userId);
        TempData["CheckShopsCount"] = user!.ShopsCount>=user.MaxShopNum;
        return View(shops);

    }




    public async Task<IActionResult> ViewForCustumers(int? id)
    {
       await usersManager.CheckViolationsCount();
        await shopsManager.CheckDistinctivePeriod();

        TempData["CategoryID"] = HttpContext.Session.GetInt32("CategoryID");
        TempData["CountryID"] = HttpContext.Session.GetInt32("CountryID");
        TempData["CityID"] = HttpContext.Session.GetInt32("CityID");
        TempData["AreaID"] = HttpContext.Session.GetInt32("AreaID");

        ViewBag.SearchSize="col-md-6";

        if (TempData["CategoryID"] != null&& (int?)TempData["CategoryID"] != 0)
        {
            ViewBag.categories = new SelectList(categoriesManager.GetAll(), "ID", "Name"
            , Convert.ToInt32(TempData["CategoryID"]));
        }
        else
        {
            ViewBag.categories = new SelectList(categoriesManager.GetAll(), "ID", "Name");
        }
        if (TempData["CountryID"] != null&& (int?)TempData["CountryID"] != 0)
        {
            ViewBag.SearchSize="col-md-4";
            ViewBag.countries = new SelectList(countriesManager.GetAll(), "ID", "Name"
            , Convert.ToInt32(TempData["CountryID"]));
        }
        else
        {
            ViewBag.countries = new SelectList(countriesManager.GetAll(), "ID", "Name");
        }

        if (TempData["CityID"] != null&& (int?)TempData["CityID"] != 0)
        {
            ViewBag.SearchSize="col-md-3";
            ViewBag.cities = new SelectList(citiesManager
            .GetAllByCountryId(Convert.ToInt32(TempData["CountryID"]))
            , "ID", "Name"
            , Convert.ToInt32(TempData["CityID"]));

        }

        else
        {
            ViewBag.cities = new SelectList(citiesManager
            .GetAllByCountryId(Convert.ToInt32(TempData["CountryID"]))
            , "ID", "Name");
        }

        if ((int?)TempData["AreaID"] != 0)
        {

            ViewBag.areas = new SelectList(areasManager
              .GetAllByCityId(Convert.ToInt32(TempData["CityID"]))
              , "ID", "Name"
               , Convert.ToInt32(TempData["AreaID"]));
        }

        else
        {
            ViewBag.areas = new SelectList(areasManager
              .GetAllByCityId(Convert.ToInt32(TempData["CityID"]))
              , "ID", "Name");
        }



        if (id == null)
        {
            id = 1;
        }

        int categoryID = (TempData["CategoryID"] != null) ? Convert.ToInt32(TempData["CategoryID"]) : 0;
        int countryID = (TempData["CountryID"] != null) ? Convert.ToInt32(TempData["CountryID"]) : 0;
        int cityID = (TempData["CityID"] != null && (int?)TempData["CityID"] != 0) ? Convert.ToInt32(TempData["CityID"]) : 0;
        int areaID = (TempData["AreaID"] != null && (int?)TempData["AreaID"] != 0) ? Convert.ToInt32(TempData["AreaID"]) : 0;
        var shops = shopsManager.GetAllPaginatedWithFilter(9, id!.Value, categoryID, countryID, cityID, areaID);
        
        ViewBag.ShopsCount=(shops.Count!=0)?shops[0].ShopsCount:0;
        
        Console.WriteLine(TempData["CategoryID"] + "\n " +
        TempData["CountryID"] + "\n " +
        TempData["CityID"] + "\n " +
        TempData["AreaID"] + "\n ");

        return View(shops);
    }
    [HttpPost]
    public IActionResult ViewForCustumers(int categoryID, int countryID, int cityID, int areaID)
    {
        HttpContext.Session.SetInt32("CategoryID", categoryID);
        HttpContext.Session.SetInt32("CountryID", countryID);
        HttpContext.Session.SetInt32("CityID", cityID);
        HttpContext.Session.SetInt32("AreaID", areaID);

        return RedirectToAction("ViewForCustumers", "Shop");
    }


    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        var shop = shopsManager.GetAllDetailsById(id);
        if (shop == null)
        {
            return NotFound();
        }
        HttpContext.Session.SetInt32("shopID", id.Value);
        if(User.Identity?.Name!=null){
        ViewBag.AddingRating = ratingsManager.CheckExistence(usersManager.GetIdByName(User.Identity.Name)
        , id.Value);}
        return View(shop);
    }

    [HttpPost]
    public IActionResult Details(GetShopDetailsByIdDTO shop)
    {
        if (shop.AddRating?.Value != null)
        {
            var rating = new AddRatingDTO
            {
                ShopID = shop.ID,
                UserID = usersManager.GetIdByName(User.Identity?.Name!),
                Value = shop.AddRating.Value,
                Comment = shop.AddRating.Comment
            };
            ratingsManager.Add(rating);
            return RedirectToAction("details", "Shop");
        }

        // if(shop.AddRating?.Value!=null && TempData["Edit"]!=null)
        // {
        // var rating=new UpdateRatingDTO
        // {
        // ID=Convert.ToInt32(TempData["Edit"]),
        // ShopID=shop.ID,
        // UserID=4,
        //  Value=shop.AddRating.Value
        //};    
        //ratingsManager.Update(rating);
        //  return RedirectToAction("details", "Shop");
        //}
        return View();
    }

    [Authorize(Roles = "User")]
    public IActionResult Create()
    {
        if ((string?)TempData["Category"] != "")
        {
        ViewBag.categories = new SelectList(categoriesManager.GetAll(), "ID", "Name"
        , Convert.ToInt32(TempData["Category"]));}
        else
        {
            ViewBag.categories = new SelectList(categoriesManager.GetAll(), "ID", "Name");
        }

        if ((string?)TempData["Country"] != "")
        {
            ViewBag.countries = new SelectList(countriesManager.GetAll(), "ID", "Name"
            , Convert.ToInt32(TempData["Country"]));
        }
        else
        {
            ViewBag.countries = new SelectList(countriesManager.GetAll(), "ID", "Name");
        }

        if ((string?)TempData["City"] != "" )
        {
            ViewBag.cities = new SelectList(citiesManager
            .GetAllByCountryId(Convert.ToInt32(TempData["Country"]))
            , "ID", "Name", Convert.ToInt32(TempData["City"]));
        }

        else
        {
            ViewBag.cities = new SelectList(citiesManager.GetAll(), "ID", "Name");
        }

                if ((string?)TempData["Area"] != "" )
        {
            ViewBag.areas = new SelectList(areasManager
              .GetAllByCityId(Convert.ToInt32(TempData["City"]))
              , "ID", "Name", Convert.ToInt32(TempData["Area"]));
              }
              else{
                ViewBag.areas = new SelectList(areasManager.GetAll(), "ID", "Name");
              }


        return View();
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyName(string name)
    {
        if (!shopsManager.VerifyField(name))
        {
            return Json($"أسم المحل {name} مستخدم مسبقا برجاء أدخال أسم محل أخر");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCategory(int categoryID)
    {
        if (!shopsManager.VerifyField(categoryID))
        {
            return Json($"برجاء أختيار نوع المحل");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCountry(int countryID)
    {
        if (!shopsManager.VerifyField(countryID))
        {
            return Json($"برجاء أختيار نوع المحل");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCity(int cityID)
    {
        if (!shopsManager.VerifyField(cityID))
        {
            return Json($"برجاء أختيار نوع المحل");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyArea(int areaID)
    {
        if (!shopsManager.VerifyField(areaID))
        {
            return Json($"برجاء أختيار نوع المحل");
        }

        return Json(true);
    }

    [HttpPost]
    public IActionResult Create(AddShopDTO shopDTO
    , Microsoft.AspNetCore.Http.IFormCollection formcollection)
    {
        TempData["ShopName"] = "" + formcollection["Name"];
        TempData["Category"] = "" + formcollection["CategoryID"];
        TempData["Country"] = "" + formcollection["CountryID"];
        TempData["City"] = "" + formcollection["CityID"];
        TempData["Area"] = "" + formcollection["AreaID"];



        if (ModelState.IsValid && User.Identity?.Name != null
        && shopDTO.ButtonName=="Add")
        {

            if ((bool?)TempData["CheckShopsCount"] == true)
            {
                TempData["Message_1"] = true;
                return RedirectToAction("index", "Shop"
                     , new { id = 1 });
            }
            shopDTO.UserID = usersManager.GetIdByName(User.Identity?.Name!);
            //Console.WriteLine(TempData["AreaID"]+"+"+shopDTO.UserID);
            shopsManager.Add(shopDTO);
            return RedirectToAction("index", "Shop"
                   , new { id = 1 });
        }
        return RedirectToAction("create");

    }

    [Authorize(Roles = "User")]
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        var shop = shopsManager.GetById(id);
        if (shop == null)
        {
            return NotFound();
        }
        TempData["ShopId"] = id;
        TempData["ShopCategory"] = shop.CategoryID;
        TempData["ProductsCount"]=shop?.ProductsCount;
        ViewBag.categories = new SelectList(categoriesManager.GetAll(), "ID", "Name");
        return View(new UpdateShopDTO
        {
            Name = shop!.Name,
            CategoryID = shop.CategoryID
        });
    }


    [HttpPost]
    public IActionResult Edit(UpdateShopDTO shopDTO)
    {
        if (ModelState.IsValid)
        {
            if ((int?)TempData["ShopCategory"] != shopDTO.CategoryID 
            && (int?)TempData["ProductsCount"]!=0)
            {
                TempData["Message_2"] = true;
                return RedirectToAction("index", "Shop"
                     , new { id = 1 });
            }
            shopDTO.ID = Convert.ToInt32(TempData["ShopId"]);
            shopsManager.Update(shopDTO);
           return RedirectToAction("index", "Shop"
                   , new { id = 1 });
        }
        return View();
    }


    public IActionResult AcceptShop(int id)
    {
        shopsManager.EditStatus(id, "مقبول");
        return RedirectToAction("index", "user");

    }

    public IActionResult RefuseShop(int id)
    {
        shopsManager.EditStatus(id, "مرفوض");
        return RedirectToAction("index", "user");
    }


    public async Task<IActionResult> RemoveDistinctive(int id)
    {
       await shopsManager.EditDistinctive(id, false, 0);
        return RedirectToAction("index", "user");
    }

    public IActionResult Delete(int id)
    {
        shopsManager.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteRating(int id)
    {
        ratingsManager.Delete(id);
        return RedirectToAction("details", "Shop",
        new { id = HttpContext.Session.GetInt32("shopID") });
    }

    public IActionResult CancelSearch()
    {
        HttpContext.Session.SetInt32("CategoryID", 0);
        HttpContext.Session.SetInt32("CountryID", 0);
        HttpContext.Session.SetInt32("CityID", 0);
        HttpContext.Session.SetInt32("AreaID", 0);

         return RedirectToAction("ViewForCustumers", "Shop");
    }
}
