using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using System.Net;
using System.Security.Claims;

namespace Mahalak;

public class ShopController : Controller
{
    //public static int clickCount = 0;
    public int shopsPageSize = 9;
    private readonly IUsersManager usersManager;
    private readonly IShopsManager shopsManager;
    private readonly ISCategoriesManager categoriesManager;
    private readonly ISCountriesManager countriesManager;
    private readonly ISCitiesManager citiesManager;
    private readonly ISAreasManager areasManager;
    private readonly IRatingsManager ratingsManager;
    private readonly IProductImagesManager productImagesManager;
    private readonly IIpApiService ipApiService;


    public ShopController(IShopsManager shopsManager
    , ISCategoriesManager categoriesManager
    , ISCountriesManager countriesManager
    , ISCitiesManager citiesManager
    , ISAreasManager areasManager
    , IRatingsManager ratingsManager
    , IUsersManager usersManager
    , IProductImagesManager productImagesManager
    , IIpApiService ipApiService
    )
    {
        this.usersManager = usersManager;
        this.shopsManager = shopsManager;
        this.categoriesManager = categoriesManager;
        this.countriesManager = countriesManager;
        this.citiesManager = citiesManager;
        this.areasManager = areasManager;
        this.ratingsManager = ratingsManager;
        this.productImagesManager = productImagesManager;
        this.ipApiService = ipApiService;
    }


    [Authorize(Roles = "User")]
    public async Task<IActionResult> Management()
    {
        /*        #region Clear old values after adding shop
                TempData["ShopName"] = "";
                TempData["Category"] = "";
                HttpContext.Session.SetInt32("Country", 0);
                TempData["City"] = "";
                TempData["Area"] = "";
                clickCount=0;
                #endregion*/


        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return NoContent();
        }

        var user = await usersManager.GetByIdAsync(userId);
        var shopsCount = await shopsManager.GetCountByUserIdAsync(userId);
        TempData["CheckShopsCount"] = shopsCount >= user!.MaxShopNum;

        return View();


    }


    public async Task<IActionResult> GetPaginatedShopManagementTable(string? shopName, CancellationToken ct)
    {
        //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
        HttpContext.Session.SetString("ShopName", shopName ?? "");
        ViewBag.ShopsPageSize = shopsPageSize;
        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {
            if (shopName != null && shopName != "")
            {
                ViewBag.ShopsCount = await shopsManager.GetCountByNameAsync(shopName, ct);
            }
            else
            {

                ViewBag.ShopsCount = await shopsManager.GetCountAsync(ct);
            }
        }
        else
            if (User.IsInRole("User"))
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

                #region Pagenation loading
                ViewBag.ShopsCount = await shopsManager.GetCountByUserIdAsync(userId, ct);
                #endregion

            }
        return PartialView("_PaginatedShopManagementTable");

    }

    public async Task<IActionResult> GetShopManagementTable(int? id, CancellationToken ct)
    {
        //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
        int currentTablePage = id ?? 1;
        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {

            string? shopName = HttpContext.Session.GetString("ShopName");

            if (shopName != null && shopName != "")
            {
                var shops = await shopsManager.GetPaginatedByNameAsync(currentTablePage,
                 shopsPageSize, shopName, ct);
                return PartialView("_ShopManagementTable", shops.Select(s => new ShopSummaryViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Status = s.Status!,
                    Distinctive = s.Distinctive,
                    DistinctiveExpiryDate = s.DistinctiveExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    MaxProductNum = s.MaxProductNum,
                    CreatingDate = s.CreatingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    UserId = s.UserId
                }).ToList());
            }
            else
            {
                var shops = await shopsManager
              .GetPaginatedAsync(currentTablePage, shopsPageSize, ct);


                return PartialView("_ShopManagementTable", shops.Select(s => new ShopSummaryViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Status = s.Status!,
                    Distinctive = s.Distinctive,
                    DistinctiveExpiryDate = s.DistinctiveExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    MaxProductNum = s.MaxProductNum,
                    CreatingDate = s.CreatingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    UserId = s.UserId
                }).ToList());
            }

        }

        else
            if (User.IsInRole("User"))
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                var shops = await shopsManager.GetPaginatedByUserIdAsync(currentTablePage, shopsPageSize, userId, ct);
                return PartialView("_ShopManagementTable", shops.Select(s => new ShopSummaryViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Status = s.Status!,
                    Distinctive = s.Distinctive,
                    DistinctiveExpiryDate = s.DistinctiveExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    MaxProductNum = s.MaxProductNum,
                    CreatingDate = s.CreatingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    UserId = s.UserId
                }).ToList());
            }

        return NotFound();
    }


    /*    public async Task<IActionResult> Index(int? id, CancellationToken ct)
        {
                Console.WriteLine("\n\njjjjjjjjjjjj"+User.FindFirstValue(ClaimTypes.MobilePhone)+"\n\n");
            await usersManager.DeleteUnActiveUsersAsync();
            await usersManager.ResetViolationsCountAsync();
            await usersManager.CheckViolationsCountAsync();
            await shopsManager.CheckDistinctivePeriodAsync();

            if (User.FindFirstValue(ClaimTypes.NameIdentifier)!=null)
            {

            } 

            #region Get current user's country
            var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
            HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipApiResponse = await ipApiService.Get(ipAddress, ct);
            #endregion
            int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
                if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      countryId=1;
    }
            if (countryId != null && countryId != 0)
            {
                if (id == null)
                {
                    id = 1;
                }
                TempData["CategoryId"] = HttpContext.Session.GetInt32("CategoryId");
                TempData["CityId"] = HttpContext.Session.GetInt32("CityId");
                TempData["AreaId"] = HttpContext.Session.GetInt32("AreaId");

                ViewBag.SearchSize = "col-md-6";

                if (TempData["CategoryId"] != null && (int?)TempData["CategoryId"] != 0)
                {
                    ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(), "Id", "Name"
                    , Convert.ToInt32(TempData["CategoryId"]));
                }
                else
                {
                    ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(), "Id", "Name");
                }

                if (TempData["CityId"] != null && (int?)TempData["CityId"] != 0)
                {
                    ViewBag.SearchSize = "col-md-4";
                    ViewBag.cities = new SelectList(await citiesManager
                    .GetAllByCountryIdAsync(countryId.Value)
                    , "Id", "Name"
                    , Convert.ToInt32(TempData["CityId"]));

                }

                else
                {
                    ViewBag.cities = new SelectList(await citiesManager
                    .GetAllByCountryIdAsync(countryId.Value)
                    , "Id", "Name");
                }

                if ((int?)TempData["AreaId"] != 0)
                {

                    ViewBag.areas = new SelectList(await areasManager
                      .GetAllByCityIdAsync(Convert.ToInt32(TempData["CityId"]))
                      , "Id", "Name"
                       , Convert.ToInt32(TempData["AreaId"]));
                }

                else
                {
                    ViewBag.areas = new SelectList(await areasManager
                      .GetAllByCityIdAsync(Convert.ToInt32(TempData["CityId"]))
                      , "Id", "Name");
                }


                int categoryId = (TempData["CategoryId"] != null) ? Convert.ToInt32(TempData["CategoryId"]) : 0;
                int cityId = (TempData["CityId"] != null && (int?)TempData["CityId"] != 0) ? Convert.ToInt32(TempData["CityId"]) : 0;
                int areaId = (TempData["AreaId"] != null && (int?)TempData["AreaId"] != 0) ? Convert.ToInt32(TempData["AreaId"]) : 0;
                var shops = await shopsManager.GetPaginatedByFiltersAsync(id!.Value,shopsPageSize, categoryId, countryId.Value, cityId, areaId);

                ViewBag.ShopsCount = await shopsManager.GetCountByFiltersAsync(categoryId, countryId.Value, cityId, areaId);
             ViewBag.ShopsPageNumber = id!.Value;
              ViewBag.ShopsPageSize =shopsPageSize;
                return View(shops);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Index(int categoryId, int cityId, int areaId)
        {
            HttpContext.Session.SetInt32("CategoryId", categoryId);
            HttpContext.Session.SetInt32("CityId", cityId);
            HttpContext.Session.SetInt32("AreaId", areaId);

            return RedirectToAction("Index", "Shop");
        }

    */


    public async Task<IActionResult> Index(CancellationToken ct)
    {
        //Console.WriteLine("\n\njjjjjjjjjjjj"+User.FindFirstValue(ClaimTypes.MobilePhone)+"\n\n");
        //await shopsManager.RemoveAllExpired();

        #region Get current user's country
        var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
        HttpContext.Connection.RemoteIpAddress?.ToString();
        var ipApiResponse = await ipApiService.Get(ipAddress, ct);
        #endregion
        int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
        if (WebApplication.CreateBuilder().Environment.IsDevelopment())
        {
            countryId = 2;
        }
        if (countryId != null && countryId != 0)
        {
            HttpContext.Session.SetInt32("CountryId", countryId.Value);

            //ViewBag.SearchSize = "col-md-6";

            ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(ct), "Id", "Name");


            //ViewBag.SearchSize = "col-md-4";

            ViewBag.cities = new SelectList(await citiesManager
            .GetAllByCountryIdAsync(countryId.Value, ct)
            , "Id", "Name");




            return View();
        }
        else
        {
            return NotFound();
        }
    }


    public async Task<IActionResult> GetPaginatedShopList(int categoryId, int cityId, int areaId, CancellationToken ct)
    {
        HttpContext.Session.SetInt32("CategoryId", categoryId);
        HttpContext.Session.SetInt32("CityId", cityId);
        HttpContext.Session.SetInt32("AreaId", areaId);
        int countryId = HttpContext.Session.GetInt32("CountryId")!.Value;

        #region Pagenation loading
        //ViewBag.ShopsCount = await shopsManager.GetCountByFiltersAsync();

        ViewBag.ShopsCount = await shopsManager.GetCountByFiltersAsync(categoryId, countryId, cityId, areaId, ct);
        ViewBag.ShopsPageSize = shopsPageSize;
        #endregion

        return PartialView("_PaginatedShopList");

    }

    public async Task<IActionResult> GetShopList(int? id, CancellationToken ct)
    {
        //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
        int currentPage = id ?? 1;
        int countryId = HttpContext.Session.GetInt32("CountryId")!.Value;
        int categoryId = HttpContext.Session.GetInt32("CategoryId")!.Value;
        int cityId = HttpContext.Session.GetInt32("CityId")!.Value;
        int areaId = HttpContext.Session.GetInt32("AreaId")!.Value;

        var shops = await shopsManager.GetPaginatedByFiltersAsync(currentPage, shopsPageSize, categoryId, countryId, cityId, areaId, ct);
        return PartialView("_ShopList", shops.Select(s => new ShopViewModel
        {
            Id = s.Id,
            Name = s.Name,
            CategoryId = s.CategoryId,
            CountryId = s.CountryId,
            CityId = s.CityId,
            AreaId = s.AreaId,
            Status = s.Status!,
            TotalRaters = s.TotalRaters,
            Distinctive = s.Distinctive,
            DistinctiveExpiryDate = s.DistinctiveExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
            MaxProductNum = s.MaxProductNum,
            CreatingDate = s.CreatingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
            ShopsCount = shops.Count,
            UserId = s.UserId
        }).ToList());

    }



    public async Task<IActionResult> GetAreasByCityId(int id, CancellationToken ct)
    {
        return Json(new { areas = new SelectList(await areasManager.GetAllByCityIdAsync(id, ct), "Id", "Name") });
    }


    [HttpPost]
    public async Task<IActionResult> SearchShops(int categoryId, int cityId, int areaId, CancellationToken ct)
    {
        // Console.WriteLine("\n\n search :"+categoryId+"-"+cityId+"-"+areaId+"\n\n");
        int currentPage = HttpContext.Session.GetInt32("CurrentPage") ?? 1;
        int countryId = HttpContext.Session.GetInt32("CountryId")!.Value;
        var shops = await shopsManager.GetPaginatedByFiltersAsync(currentPage, shopsPageSize, categoryId, countryId, cityId, areaId, ct);

        return PartialView("_ShopsList", shops.Select(s => new ShopViewModel
        {
            Id = s.Id,
            Name = s.Name,
            CategoryId = s.CategoryId,
            CountryId = s.CountryId,
            CityId = s.CityId,
            AreaId = s.AreaId,
            Status = s.Status!,
            TotalRaters = s.TotalRaters,
            Distinctive = s.Distinctive,
            DistinctiveExpiryDate = s.DistinctiveExpiryDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
            MaxProductNum = s.MaxProductNum,
            CreatingDate = s.CreatingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
            ShopsCount = shops.Count,
            UserId = s.UserId
        }).ToList());

    }

    public async Task<IActionResult> Details(int? id, CancellationToken ct)
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
            if (id == null)
            {
                return BadRequest();
            }
            var shop = await shopsManager.GetDetailsByIdAsync(id, countryId);
            if (shop == null)
            {
                return NotFound();
            }

            //prevent show shop details to client before accepting
            if (shop.Status != "مقبول" && User.FindFirstValue(ClaimTypes.NameIdentifier) != shop.User?.Id)
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32("shopId", id.Value);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                ViewBag.AddingRating = await ratingsManager.CheckExistenceAsync(
                   userId, id.Value);
            }
            return View(new ShopDetailsViewModel
            {
                Id = shop.Id,
                Name = shop.Name,
                CategoryName = shop.Category!.Name,
                Address = shop.Area?.Name + "-" + shop.City?.Name,
                OwnerName = shop.User?.FirstName! + " " + shop.User?.LastName!,
                OwnerNumber = shop.User?.PhoneNumber!,
                Status = shop.Status!,
                /*      ClientsRatings = shop.Ratings.Select(r => new RatingViewModel
                      {
                        Id = r.Id,
                        UserName = r.User!.FirstName+" "+r.User!.LastName,
                        Value = r.Value,
                        Comment = r.Comment,
                        Status = r.Status!,
                        CommentDatetime = r.CommentDatetime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                        ShopId = r.ShopId,
                        UserId = r.UserId
                      }).ToList(),*/
                Products = shop.Products!.Select(p => new ProductInShopViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    InterfaceImage = p.Images!.Select(img => new ProductImageViewModel
                    {
                        Id = img.Id,
                        Name = img.Name,
                        ProductId = img.ProductId
                    }).ToList().FirstOrDefault()
                }).ToList()
            });
        }
        else
        {
            return NotFound();
        }
    }

    /*  [HttpPost]
      public async Task<IActionResult> Details(ShopDetailsViewModel shop)
      {

          var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
          if (userId == null)
          {
              return BadRequest();
          }
          if (shop.AddRating?.Value != null)
          {
              var rating = new AddRatingViewModel
              {
                  ShopId = shop.Id,
                  UserId = userId,
                  Value = shop.AddRating.Value,
                  Comment = shop.AddRating.Comment
              };
              await ratingsManager.AddAsync(rating);
              return RedirectToAction("details", "Shop");
          }

          // if(shop.AddRating?.Value!=null && TempData["Edit"]!=null)
          // {
          // var rating=new UpdateRatingViewModel
          // {
          // Id=Convert.ToInt32(TempData["Edit"]),
          // ShopId=shop.Id,
          // UserId=4,
          //  Value=shop.AddRating.Value
          //};    
          //ratingsManager.Update(rating);
          //  return RedirectToAction("details", "Shop");
          //}
          return View();
      }*/

    /*        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(CancellationToken ct)
        { 
            #region Get current user's country
            var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
            HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipApiResponse = await ipApiService.Get(ipAddress, ct);
            #endregion
            int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
            if (countryId != null && countryId != 0)
            {
                HttpContext.Session.SetInt32("Country", countryId.Value);

                if ((string?)TempData["Category"] != "")
                {
                    ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(), "Id", "Name"
                    , Convert.ToInt32(TempData["Category"]));
                }
                else
                {
                    ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(), "Id", "Name");
                }


                if ((string?)TempData["City"] != "")
                {
                    ViewBag.cities = new SelectList(await citiesManager
                    .GetAllByCountryIdAsync(countryId.Value)
                    , "Id", "Name", Convert.ToInt32(TempData["City"]));

                    ViewBag.areas = new SelectList(await areasManager
                     .GetAllByCityIdAsync(Convert.ToInt32(TempData["City"]))
                     , "Id", "Name");
                }

                else
                {
                    ViewBag.cities = new SelectList(await citiesManager.GetAllByCountryIdAsync(countryId.Value)
                    , "Id", "Name");
                    ViewBag.areas = new SelectList(await areasManager.GetAllAsync(), "Id", "Name");
                }

                if ((string?)TempData["Area"] != "" && (string?)TempData["Area"] != "0")
                {
                    ViewBag.areas = new SelectList(await areasManager
                      .GetAllByCityIdAsync(Convert.ToInt32(TempData["City"]))
                      , "Id", "Name", Convert.ToInt32(TempData["Area"]));
                }

                return View();

            }
            else
            {
                return NotFound();
            }
        }*/

    [Authorize(Roles = "User")]
    public async Task<IActionResult> Create(CancellationToken ct)
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
            HttpContext.Session.SetInt32("Country", countryId.Value);

            ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(ct)
                 , "Id", "Name");

            ViewBag.cities = new SelectList(await citiesManager.GetAllByCountryIdAsync(countryId.Value, ct), "Id", "Name");
            //ViewBag.areas = new SelectList(await areasManager.GetAllAsync(), "Id", "Name");

            return View();

        }
        else
        {
            return NotFound();
        }
    }




    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifyName(string name)
    {
        if (!await shopsManager.VerifyFieldAsync(name))
        {
            return Json($"أسم المحل {name} مستخدم مسبقا برجاء أدخال أسم محل أخر");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCategory(int categoryId)
    {
        if (!shopsManager.VerifyField(categoryId))
        {
            return Json($"برجاء أختيار نوع المحل");
        }

        return Json(true);
    }



    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCity(int cityId)
    {
        if (!shopsManager.VerifyField(cityId))
        {
            return Json($"برجاء أختيار المدينة");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyArea(int areaId)
    {
        if (!shopsManager.VerifyField(areaId))
        {
            return Json($"برجاء أختيار المنطقة");
        }

        return Json(true);
    }

    /*    [HttpPost]
        public async Task<IActionResult> Create(AddShopViewModel shopViewModel
        , Microsoft.AspNetCore.Http.IFormCollection formcollection)
        {
            TempData["ShopName"] = "" + formcollection["Name"];
            TempData["Category"] = "" + formcollection["CategoryId"];
            TempData["City"] = "" + formcollection["CityId"];
            TempData["Area"] = "" + formcollection["AreaId"];


            if (ModelState.IsValid && User.FindFirstValue(ClaimTypes.NameIdentifier) != null
            && shopViewModel.ButtonName == "Add")
            {
                clickCount++;
                if(clickCount==1){ 

                if ((bool?)TempData["CheckShopsCount"] == true)
                {
                    TempData["MessageMaxShops"] = true;
                    return RedirectToAction("Management", "Shop"
                         , new { Id = 1 });
                }
                shopViewModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                shopViewModel.CountryId = HttpContext.Session.GetInt32("Country")!.Value;
                if (shopViewModel.UserId == null)
                {
                    return BadRequest();
                }

                await shopsManager.AddAsync(shopViewModel);

            }
            return RedirectToAction("Management", "Shop"
                       , new { Id = 1 });
            }
            return RedirectToAction("create");

        }
    */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ShopAddViewModel shopViewModel)
    {
        /*Console.WriteLine("\n\n"+ModelState.IsValid+"\n\n"+
        "\n\n"+shopViewModel.Name+"/"+shopViewModel.CategoryId+"/"+shopViewModel.CityId+"/"+shopViewModel.CityId+"/"+shopViewModel.AreaId+"\n\n"+
        "\n\n"+User.FindFirstValue(ClaimTypes.MobilePhone) +"\n\n"+
            "\n\nbtn" +shopViewModel.ButtonName +"\n\n");*/

        if (ModelState.IsValid && User.FindFirstValue(ClaimTypes.NameIdentifier) != null
         && !string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.MobilePhone)))//&& shopViewModel.ButtonName == "Add")
        {
            //Console.WriteLine("\n\njohohhh"+shopViewModel.Name+"/"+shopViewModel.CategoryId+"/"+shopViewModel.CityId+"/"+shopViewModel.CityId+"/"+shopViewModel.AreaId+"\n\n");

            //Console.WriteLine("\n\nttttttttyyyyyyy"+User.FindFirstValue(ClaimTypes.MobilePhone)+"\n\n");

            if ((bool?)TempData["CheckShopsCount"] == true)
            {

                TempData["MessageMaxShops"] = true;
                return RedirectToAction("Management", "Shop"
                     , new { Id = 1 });
            }
            shopViewModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            shopViewModel.CountryId = HttpContext.Session.GetInt32("Country")!.Value;
            if (shopViewModel.UserId == null)
            {
                return BadRequest();
            }

            await shopsManager.AddAsync(new ShopAddDTO
            {
                Name = shopViewModel.Name.Trim(),
                CategoryId = shopViewModel.CategoryId,
                CountryId = shopViewModel.CountryId,
                CityId = shopViewModel.CityId,
                AreaId = shopViewModel.AreaId,
                UserId = shopViewModel.UserId!
            });

            return RedirectToAction("Management", "Shop"
                       , new { Id = 1 });
        }

        if (string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.MobilePhone)))
        {
            //Console.WriteLine("\n\nddddddddd"+User.FindFirstValue(ClaimTypes.MobilePhone)+"\n\n");
            TempData["IsMobilePhoneUnavailable"] = true;
        }

        return RedirectToAction("create");

    }

    [Authorize(Roles = "User")]
    [HttpGet]
    public async Task<IActionResult> Edit(int? id, CancellationToken ct)
    {
        var shop = await shopsManager.GetByIdAsync(id, ct);
        if (shop == null)
        {
            return NotFound();
        }
        if (shop.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
        {
            return BadRequest();
        }
        HttpContext.Session.SetInt32("ShopId", id!.Value);

        TempData["ShopCategory"] = shop.CategoryId;
        TempData["ProductsCount"] = shop?.ProductsCount;
        ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(), "Id", "Name");
        return View(new ShopUpdateViewModel
        {
            Name = shop!.Name,
            CategoryId = shop.CategoryId
        });

    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerifyEditName(string name)
    {
        if (!await shopsManager.VerifyEditFieldAsync(name, HttpContext.Session.GetInt32("ShopId")))
        {
            return Json($"أسم المحل {name} مستخدم مسبقا برجاء أدخال أسم محل أخر");
        }

        return Json(true);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ShopUpdateViewModel shopViewModel)
    {
        if (ModelState.IsValid)
        {
            if ((int?)TempData["ShopCategory"] != shopViewModel.CategoryId
            && (int?)TempData["ProductsCount"] != 0)
            {
                TempData["MessageEditCategory"] = true;
                return RedirectToAction("Management", "Shop"
                     , new { Id = 1 });
            }
            shopViewModel.Id = HttpContext.Session.GetInt32("ShopId")!.Value;
            await shopsManager.UpdateAsync(new ShopUpdateDTO
            {
                Id = shopViewModel.Id,
                Name = shopViewModel!.Name,
                CategoryId = shopViewModel.CategoryId
            });
            return RedirectToAction("Management", "Shop"
                    , new { Id = 1 });
        }
        return View();
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> AcceptShop(int id)
    {
        bool result = await shopsManager.EditStatusAsync(id, "مقبول");
        if (result)
        {
            return Json(new { success = true });
        }
        return Json(new { success = false });

    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> RefuseShop(int id)
    {
        bool result = await shopsManager.EditStatusAsync(id, "مرفوض");

        if (result)
        {
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }


    public async Task<IActionResult> DistinguishShop(string distinctivePeriod)
    {

        if (distinctivePeriod != null && distinctivePeriod != "0")
        {
            string[] shopValues = distinctivePeriod.Split("-");
            Console.WriteLine("\n" + shopValues[0] + "\n");
            int shopId = int.Parse(shopValues[0]);
            int period = int.Parse(shopValues[1]);
            bool result = await shopsManager.EditDistinctiveAsync(shopId, period);

            if (result)
            {
                return Json(new { success = true });
            }
        }

        return Json(new { success = false });
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> RemoveDistinctive(int id)
    {
        bool result = await shopsManager.EditDistinctiveAsync(id, 0);
        if (result)
        {
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [Authorize(Roles = "Manager,User")]
    public async Task<IActionResult> Delete(int id)
    {

        var shopProductCount = await shopsManager.CheckExistsAsync(id);
        if (shopProductCount == null)
        {
            return NotFound();
        }
        //var user=await usersManager.GetByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        /*        if (shop.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier)! && !User.IsInRole("Manager") && !User.IsInRole("Admin"))
                {
                    return NotFound();
                }*/

        if (shopProductCount != 0)
        {
            TempData["MessageDeleteShop"] = true;
            return RedirectToAction("Management", "Shop"
                 , new { Id = 1 });
        }

        await shopsManager.DeleteAsync(id);

        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {
            ViewBag.ShopsPageSize = shopsPageSize;
            ViewBag.ShopsCount = await shopsManager.GetCountAsync();
            return PartialView("_PaginatedShopManagementTable");
        }

        return RedirectToAction("Management", "Shop"
                     , new { Id = 1 });
    }

    /*    [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var rating = await ratingsManager.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            if (rating.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
            {
                return BadRequest();
            }
            await ratingsManager.DeleteAsync(id);
            return RedirectToAction("details", "Shop",
            new { Id = HttpContext.Session.GetInt32("shopId") });
        }*/

    public IActionResult CancelSearch()
    {
        HttpContext.Session.SetInt32("CategoryId", 0);
        HttpContext.Session.SetInt32("CountryId", 0);
        HttpContext.Session.SetInt32("CityId", 0);
        HttpContext.Session.SetInt32("AreaId", 0);

        return RedirectToAction("Index", "Shop");
    }
}
