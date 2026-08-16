using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mahalak;

public class ProductController : Controller
{
    //public static int clickCount = 0;
    public int productsPageSize = 9;
    //public static string[]? images = null;
    private readonly IShopsManager shopsManager;
    private readonly ISCountriesManager countriesManager;
    private readonly IProductsManager productsManager;
    private readonly IPCategoriesManager categoriesManager;
    private readonly IPConditionsManager conditionsManager;
    private readonly IProductImagesManager productImagesManager;
    private readonly IIpApiService ipApiService;

    public ProductController(IShopsManager shopsManager,
    ISCountriesManager countriesManager,
    IProductsManager productsManager,
    IPCategoriesManager categoriesManager,
    IPConditionsManager conditionsManager,
    IProductImagesManager productImagesManager,
    IIpApiService ipApiService)
    {
        this.shopsManager = shopsManager;
        this.countriesManager = countriesManager;
        this.productsManager = productsManager;
        this.categoriesManager = categoriesManager;
        this.conditionsManager = conditionsManager;
        this.productImagesManager = productImagesManager;
        this.ipApiService = ipApiService;
    }

    [Authorize(Roles = "User")]
    [HttpGet]
    [Route("product/management/{shopId}")]
    public async Task<IActionResult> Management(int shopId, CancellationToken ct)
    {
        /*        #region Clear old values after adding product
                TempData["Name"] = "";
                TempData["Price"] = "";
                TempData["Category"] = "";
                TempData["Condition"] = "";
                TempData["Describtion"] = "";
                //images = null;
                clickCount = 0;
                #endregion*/
        #region Get current user's country
        var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
        HttpContext.Connection.RemoteIpAddress?.ToString();
        var ipApiResponse = await ipApiService.Get(ipAddress, ct);
        #endregion

        int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);
        var shopVerification = await shopsManager.GetDetailsByIdAsync(shopId, countryId);
        if (shopVerification == null)
        {
            return NotFound();
        }
        else
        {
            if (shopVerification.User?.Id != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
            {
                return BadRequest();
            }
        }

        HttpContext.Session.SetInt32("ShopId", shopId);
        var shop = await shopsManager.GetByIdAsync(shopId);
        TempData["CheckProductsCount"] = shop!.ProductsCount >= shop.MaxProductNum;
        return View();

    }

    public async Task<IActionResult> GetPaginatedProductManagementTable(string? productName, CancellationToken ct)
    {

        HttpContext.Session.SetString("ProductName", productName ?? "");

        ViewBag.ProductsPageSize = productsPageSize;
        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {

            if (productName != null && productName != "")
            {
                ViewBag.ProductsCount = await productsManager.GetCountAsync(productName, ct);
            }
            else
            {

                ViewBag.ProductsCount = await productsManager.GetCountAsync("",ct);
            }
        }
        else
            if (User.IsInRole("User"))
            {
                int shopId = HttpContext.Session.GetInt32("ShopId") ?? 0;
                ViewBag.ShopId = shopId;

                var shop = await shopsManager.GetByIdAsync(shopId, ct);
                ViewBag.ShopName = shop!.Name;
                ViewBag.ProductsCount = await productsManager.GetCountByShopIdAsync(shopId, ct);
            }
        return PartialView("_PaginatedProductManagementTable");
    }

    public async Task<IActionResult> GetProductManagementTable(int? id, CancellationToken ct)
    {
        //Console.WriteLine("\n"+"id:"+id+",table:"+table+",role:"+role+"\n");
        int currentTablePage = id ?? 1;

        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {
            string? productName = HttpContext.Session.GetString("ProductName");

            if (productName != null && productName != "")
            {
                var products = await productsManager.GetPaginatedAsync(currentTablePage,
                 productsPageSize, ct, productName);
                return PartialView("_ProductManagementTable", products.Select(p => new ProductSummaryViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString().Remove(p.Price.ToString().IndexOf("."), 2),
                    Status = p.Status!,
                    AddingDate = p.AddingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    //ProductsCount = products.Count,
                    ShopId = p.ShopId
                }).ToList());
            }
            else
            {
                var products = await productsManager
              .GetPaginatedAsync(currentTablePage, productsPageSize, ct);


                return PartialView("_ProductManagementTable", products.Select(p => new ProductSummaryViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString().Remove(p.Price.ToString().IndexOf("."), 2),
                    Status = p.Status!,
                    AddingDate = p.AddingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    //ProductsCount = products.Count,
                    ShopId = p.ShopId
                }).ToList());
            }
        }
        else
            if (User.IsInRole("User"))
            {
                int shopId = HttpContext.Session.GetInt32("ShopId") ?? 0;
                var products = await productsManager.GetPaginatedByShopIdAsync(currentTablePage, productsPageSize, shopId, ct);



                return PartialView("_ProductManagementTable", products.Select(p => new ProductSummaryViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString().Remove(p.Price.ToString().IndexOf("."), 2),
                    Status = p.Status!,
                    AddingDate = p.AddingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
                    //ProductsCount = products.Count,
                    ShopId = p.ShopId
                }).ToList());
            }

        return Json("none");
    }



    public async Task<IActionResult> Index(CancellationToken ct)
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
        HttpContext.Session.SetInt32("CountryId", countryId.Value);


        if (countryId != null && countryId != 0)
        {

            ViewBag.categories = new SelectList(await categoriesManager.GetAllAsync(ct), "Id", "Name");

            ViewBag.conditions = await conditionsManager.GetAllAsync(ct);


            return View();
        }
        else
        {
            return NotFound();
        }
    }


    public async Task<IActionResult> GetPaginatedProductList(ProductFiltersViewModel productFilters, CancellationToken ct)
    {
        //Console.WriteLine("\n"+"id:table:"+productFilters!.MinPrice.ToString()+"\n");
        //Console.WriteLine("\n"+"id:table:"+productFilters!.MaxPrice.ToString()+"\n");
        HttpContext.Session.SetString("ProductName", productFilters!.Name ?? "");
        HttpContext.Session.SetInt32("CategoryId", productFilters!.CategoryId);
        HttpContext.Session.SetString("MinPrice", productFilters!.MinPrice.ToString());
        HttpContext.Session.SetString("MaxPrice", productFilters!.MaxPrice.ToString());
        HttpContext.Session.SetInt32("ConditionId", productFilters!.ConditionId);

        int? countryId = HttpContext.Session.GetInt32("CountryId");

        ViewBag.ProductsCount = await productsManager.GetCountByFiltersAsync(countryId, ct, productFilters!.Name ?? "", productFilters!.CategoryId, productFilters!.MinPrice, productFilters!.MaxPrice, productFilters!.ConditionId);
        ViewBag.ProductsPageSize = productsPageSize;

        return PartialView("_PaginatedProductList");

    }

    public async Task<IActionResult> GetProductList(int? id, CancellationToken ct)
    {
        int currentPage = id ?? 1;

        string productName = HttpContext.Session.GetString("ProductName") ?? "";
        int categoryId = HttpContext.Session.GetInt32("CategoryId")!.Value;
        decimal minPrice = Convert.ToDecimal(HttpContext.Session.GetString("MinPrice"));
        decimal maxPrice = Convert.ToDecimal(HttpContext.Session.GetString("MaxPrice"));
        int conditionId = HttpContext.Session.GetInt32("ConditionId")!.Value;

        int? countryId = HttpContext.Session.GetInt32("CountryId");

        var products = await productsManager.GetPaginatedByFiltersAsync(currentPage, productsPageSize, countryId, ct,
            productName, categoryId, minPrice, maxPrice, conditionId);

        return PartialView("_ProductsList", products.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price.ToString().Remove(p.Price.ToString().IndexOf("."), 2) + " " + p.Currency,
            Status = p.Status,
            AddingDate = p.AddingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
            Category = new PCategoryViewModel
            {
                Id = p.Category!.Id,
                Name = p.Category!.Name
            },
            Condition = new PConditionViewModel
            {
                Id = p.Condition!.Id,
                Name = p.Condition!.Name
            },
            InterfaceImage = p.Images!.Select(img => new ProductImageViewModel
            {
                Id = img.Id,
                Name = img.Name,
                ProductId = img.ProductId
            }).ToList().FirstOrDefault(),
            Distinctive = p.Distinctive,
            ProductsCount = products.Count,
            ShopId = p.ShopId
        }).ToList());

    }



    /*public async Task<IActionResult> GetAllProducts()
    {
        int currentPage = HttpContext.Session.GetInt32("CurrentPage") ?? 1;
            var products = await productsManager.GetPaginatedByFiltersAsync(currentPage,1);
return PartialView("_ProductsList",products);

    }*/



    /*    [HttpPost]
            public  async Task<IActionResult> SearchProducts(ProductFiltersViewModel productFilters)
        {
           // Console.WriteLine("\n\n search :"+productFilters!.CategoryId+"-"+productFilters!.Name+"-"+productFilters!.MinPrice.ToString()+"-"+productFilters!.MaxPrice.ToString()+"-"+productFilters!.ConditionId+"-"+"\n\n");
    int currentPage = HttpContext.Session.GetInt32("CurrentPage") ?? 1;
            var products = await productsManager.GetPaginatedByFiltersAsync(currentPage,1,
                productFilters!.Name??"", productFilters!.CategoryId,productFilters!.MinPrice,productFilters!.MaxPrice,productFilters!.ConditionId);

            return PartialView("_ProductsList", products.Select(p => new ProductViewModel
        {
          Id = p.Id,
          Name = p.Name,
          Price = p.Price.ToString().Remove(p.Price.ToString().IndexOf("."),2),
          Status = p.Status,
          AddingDate = p.AddingDate?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
          Category = new PCategoryViewModel
          {
            Id = p.Category!.Id,
            Name = p.Category!.Name
          },
          Condition = new PConditionViewModel
          {
            Id = p.Condition!.Id,
            Name = p.Condition!.Name
          },
          InterfaceImage = p.Images!.Select(img => new ProductImageViewModel
          {
              Id = img.Id,
              Name = img.Name,
              ProductId = img.ProductId
          }).ToList().FirstOrDefault(),
          Distinctive=p.Distinctive,
          ProductsCount = products.Count,
          ShopId = p.ShopId
        }).ToList());
            //return RedirectToAction("Index", "Product");
        }*/


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
            var product = await productsManager.GetDetailsByIdAsync(id, countryId);
            if (product == null)
            {
                return NotFound();
            }
            var shop = await shopsManager.GetDetailsByIdAsync(product.ShopId, countryId);

            //prevent show product details to client before accepting
            if (product.Status != "مقبول" && User.FindFirstValue(ClaimTypes.NameIdentifier) != shop!.User?.Id
            && !User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                return NotFound();
            }

            if (User.IsInRole("Manager") || User.IsInRole("Admin"))
            {
                TempData["DisplayedProductId"] = product.Id;
                //Console.WriteLine("\n\n" + "product"+TempData["DisplayedProductId"] + "\n\n");
            }

            return View(new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString().Remove(product.Price.ToString().IndexOf("."), 2) + " " + product.Currency,
                Category = new PCategoryViewModel()
                {
                    Id = product.Category!.Id,
                    Name = product.Category!.Name
                },
                Status = product.Status!,
                Describtion = product.Describtion,
                Condition = new PConditionViewModel()
                {
                    Id = product.Condition!.Id,
                    Name = product.Condition!.Name
                },
                Images = product.Images!.Select(img => new ProductImageViewModel
                {
                    Id = img.Id,
                    Name = img.Name,
                    ProductId = img.ProductId
                }).ToList(),
                ShopId = product.ShopId,
                ShopName = product.ShopName
            });
        }
        else
        {
            return NotFound();
        }
    }

    /*    [Authorize(Roles = "User")]
        public async Task<IActionResult> Create()
        {
            var shopVerification = await shopsManager.GetAllDetailsByIdAsync(HttpContext.Session.GetInt32("ShopId"));
            if (shopVerification == null)
            {
                return NotFound();
            }
            else
            {
                if (shopVerification.User?.Id != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
                {
                    return BadRequest();
                }
            }
            ViewBag.BackToShop = HttpContext.Session.GetInt32("ShopId");

            ViewBag.Images = TempData["Images"];
            var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));

            ViewBag.categories = (Convert.ToString(TempData["Category"]) != "") ?

             new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
             , "Id", "Name", Convert.ToInt32(TempData["Category"])) :

             new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
             , "Id", "Name");


            ViewBag.conditions = (Convert.ToString(TempData["Condition"]) != "") ?

            new SelectList(await conditionsManager.GetAllAsync()
            , "Id", "Name", Convert.ToInt32(TempData["Condition"])) :

            ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync()
            , "Id", "Name");


            return View();
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

        var shopVerification = await shopsManager.GetDetailsByIdAsync(HttpContext.Session.GetInt32("ShopId"), countryId);
        if (shopVerification == null)
        {
            return NotFound();
        }
        else
        {
            if (shopVerification.User?.Id != User.FindFirstValue(ClaimTypes.NameIdentifier)!)
            {
                return BadRequest();
            }
        }
        ViewBag.BackToShop = HttpContext.Session.GetInt32("ShopId");

        var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));

        ViewBag.categories = new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
         , "Id", "Name");

        ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync()
        , "Id", "Name");


        return View();
    }


    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCategory(int categoryId)
    {
        if (!productsManager.VerifyField(categoryId))
        {
            return Json($"برجاء أختيار نوع المنتج");
        }

        return Json(true);
    }

    /*       [AcceptVerbs("GET", "POST")]
       public IActionResult VerifyImages(List<IFormFile> images)
       {
           if (images==null)
           {
               return Json($"برجاء أختيار نوع المنتج");
           }

           return Json(true);
       }*/



    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCondition(int conditionId)
    {
        if (!productsManager.VerifyField(conditionId))
        {
            return Json($"برجاء أختيار حالة المنتج");
        }

        return Json(true);
    }


    /*    [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel productViewModel,
        Microsoft.AspNetCore.Http.IFormCollection formcollection)
        {
            TempData["Name"] = "" + formcollection["Name"];
            TempData["Price"] = "" + formcollection["Price"];
            TempData["Category"] = "" + formcollection["CategoryId"];
            TempData["Condition"] = "" + formcollection["ConditionId"];
            TempData["Describtion"] = "" + formcollection["Describtion"];

            TempData["ImagesCount"] = productViewModel.Images?.Length;

            if (productViewModel.Images?.Length == 3)
            {
                images = await productImagesManager.ShowUploadedImages(productViewModel.Images, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                TempData["Images"] = images;
            }
            //Console.WriteLine("\n\n"+images[0]+"\n\n");
            if (ModelState.IsValid && HttpContext.Session.GetInt32("ShopId") != 0 && images != null
             && productViewModel.ButtonName == "Add")
            {
     Console.WriteLine("\n\nShopadd\n\n");
                clickCount++;
                if (clickCount == 1)
                {
                    Console.WriteLine("\n\nShop"+clickCount+"\n\n");
                    if ((bool?)TempData["CheckProductsCount"] == true)
                    {
                        TempData["MessageMaxProducts"] = true;
                        return RedirectToAction(HttpContext.Session.GetInt32("ShopId").ToString(), "products"
                       , new { Id = 1 });
                    }

                    productViewModel.ShopId = Convert.ToInt32(HttpContext.Session.GetInt32("ShopId"));
                    Console.WriteLine("\n\n"+HttpContext.Session.GetInt32("ShopId")+"\n\n");
                    bool addedProduct = await productsManager.AddAsync(productViewModel);

                    if (addedProduct)
                    {
                        Console.WriteLine("\n\nadd\n\n");
                        await productImagesManager.AddCollectionAsync(images, User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                    }
                }

                #region Clear old values after adding product
                TempData["Name"] = "";
                TempData["Price"] = "";
                TempData["Category"] = "";
                TempData["Condition"] = "";
                TempData["Describtion"] = "";
                images = null;
                clickCount = 0;
                #endregion
                return RedirectToAction(HttpContext.Session.GetInt32("ShopId").ToString(), "products"
         , new { Id = 1 });
            }
            return RedirectToAction("create");

        }
    */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductAddViewModel productViewModel, CancellationToken ct)
    {
        string errorMessage = ImageValidator.IsImagesValid(productViewModel.Images!);
        if (errorMessage != string.Empty)
        {
            var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));

            ViewBag.categories = new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
             , "Id", "Name");

            ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync()
            , "Id", "Name");

            ModelState.AddModelError("Images", errorMessage);
            return View(productViewModel);
        }

        /*        Console.WriteLine("\n\netreter"+ModelState.IsValid +"=="+ HttpContext.Session.GetInt32("ShopId")+"---"+
                    errorMessage +"---"+ productViewModel.ButtonName+"\n\n");*/

        if (ModelState.IsValid && HttpContext.Session.GetInt32("ShopId") != 0 &&
            errorMessage == string.Empty)//&& productViewModel.ButtonName == "Add")
        {
            // Console.WriteLine("\n\nShopadd\n\n");
            if ((bool?)TempData["CheckProductsCount"] == true)
            {
                TempData["MessageMaxProducts"] = true;
                return RedirectToAction("management", "product"
               , new { Id = HttpContext.Session.GetInt32("ShopId") });

            }

            productViewModel.ShopId = Convert.ToInt32(HttpContext.Session.GetInt32("ShopId"));
            Console.WriteLine("\n\n" + HttpContext.Session.GetInt32("ShopId") + "\n\n");
            bool addedProduct = await productsManager.AddAsync(new ProductAddDTO
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Describtion = productViewModel.Describtion,
                CategoryId = productViewModel.CategoryId,
                ConditionId = productViewModel.ConditionId,
                ShopId = productViewModel.ShopId
            });

            if (addedProduct)
            {
                Console.WriteLine("\n\nadd\n\n");
                await productImagesManager.AddCollectionAsync(productViewModel.Images!, User.FindFirstValue(ClaimTypes.NameIdentifier)!, ct);
            }

            return RedirectToAction("management", "product"
                   , new { Id = HttpContext.Session.GetInt32("ShopId") });
        }
        return RedirectToAction("create");

    }


    /*  [Authorize(Roles = "User")]
       [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var product = await productsManager.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var shopVerification = await shopsManager.GetAllDetailsByIdAsync(product.ShopId);
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != shopVerification!.User?.Id)
            {
                return NotFound();
            }


            if (TempData["Images"] != null)
            {
                ViewBag.Images = TempData["Images"];
            }
            else
            {
                ViewBag.ProductImages = await productImagesManager.GetAllByProductIdAsync(id);
            }

            var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));

            ViewBag.categories = new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
                 , "Id", "Name", Convert.ToInt32(TempData["CategoryId"]));


            ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync()
            , "Id", "Name");

            ViewBag.BackToShop = HttpContext.Session.GetInt32("ShopId");

            TempData["ProductId"] = id;
            TempData["CategoryId"] = product.CategoryId;
            Console.WriteLine("\n\n" + TempData["CategoryId"] + "\n\n");

            return View(new UpdateProductViewModel
            {
                Name = product.Name,
                Price = Convert.ToDecimal( product.Price),
                CategoryId = product.CategoryId,
                ConditionId = product.ConditionId,
                Describtion = product.Describtion
            });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductViewModel productViewModel)
        {
            TempData["ImagesCount"] = productViewModel.Images?.Length;

            if (productViewModel.Images?.Length == 3)
            {
                images = await productImagesManager.ShowUploadedImages(productViewModel.Images, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                TempData["Images"] = images;
            }
            Console.WriteLine("\n\n" + productViewModel.ButtonName +
            "-------------" + productViewModel.CategoryId + "_____" + productViewModel.ConditionId + "\n\n");
            // Console.WriteLine("\n\n" + productViewModel.CategoryId + "\n\n");

            if (ModelState.IsValid && productViewModel.ButtonName == "Edit")
            {


                productViewModel.Id = Convert.ToInt32(TempData["ProductId"]);
                //productViewModel.CategoryId = categoriesManager.GetByShopId(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")))[0].Id;
                bool updatedProduct = await productsManager.UpdateAsync(productViewModel);

                if (updatedProduct == true && images != null)
                {
                    await productImagesManager.UpdateCollectionAsync(images, productViewModel.Id, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                }

                



                return RedirectToAction(HttpContext.Session.GetInt32("ShopId").ToString(), "products"
                   , new { Id = 1 });
            }
            return RedirectToAction("edit");
        }
    */

    [Authorize(Roles = "User")]
    [HttpGet]
    public async Task<IActionResult> Edit(int? id, CancellationToken ct)
    {
        #region Get current user's country
        var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
        HttpContext.Connection.RemoteIpAddress?.ToString();
        var ipApiResponse = await ipApiService.Get(ipAddress, ct);
        #endregion

        int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);

        var product = await productsManager.GetDetailsByIdAsync(id, countryId);
        if (product == null)
        {
            return NotFound();
        }
        var shopVerification = await shopsManager.GetDetailsByIdAsync(product.ShopId, countryId);
        if (User.FindFirstValue(ClaimTypes.NameIdentifier) != shopVerification!.User?.Id)
        {
            return NotFound();
        }

        //ViewBag.ProductImages =await productImagesManager.GetAllByProductIdAsync(id); 

        var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));
        //Console.WriteLine("\n\n" + shop!.CategoryId + "\n\n"+ Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));
        ViewBag.categories = new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId)
             , "Id", "Name");


        ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync()
        , "Id", "Name");

        ViewBag.BackToShop = HttpContext.Session.GetInt32("ShopId");

        TempData["ProductId"] = id;
        TempData["CategoryId"] = product.Category!.Id;

        return View(new ProductUpdateViewModel
        {
            Name = product.Name,
            Price = Convert.ToDecimal(product.Price),
            CategoryId = product.Category!.Id,
            ConditionId = product.Condition!.Id,
            CurrentImages = product.Images!.Select(img => new ProductImageViewModel
            {
                Id = img.Id,
                Name = img.Name,
                ProductId = img.ProductId
            }).ToList(),
            Describtion = product.Describtion
        });
    }


    [HttpPost]
    public async Task<IActionResult> Edit(ProductUpdateViewModel productViewModel, CancellationToken ct)
    {
        if (productViewModel.NewImages != null)
        {
            string errorMessage = ImageValidator.IsImagesValid(productViewModel.NewImages);
            if (errorMessage != string.Empty)
            {
                var shop = await shopsManager.GetByIdAsync(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));
                //Console.WriteLine("\n\n" + shop.Name + "\n\n"+ Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")));
                ViewBag.categories = new SelectList(await categoriesManager.GetAllBySCategoryIdAsync(shop!.CategoryId, ct)
                 , "Id", "Name");

                ViewBag.conditions = new SelectList(await conditionsManager.GetAllAsync(ct)
                , "Id", "Name");

                ModelState.AddModelError("NewImages", errorMessage);
                return View(productViewModel);
            }
        }


        if (ModelState.IsValid && productViewModel.ButtonName == "Edit")
        {
            productViewModel.Id = Convert.ToInt32(TempData["ProductId"]);
            //productViewModel.CategoryId = categoriesManager.GetByShopId(Convert.ToInt32(HttpContext.Session.GetInt32("ShopId")))[0].Id;
            bool updatedProduct = await productsManager.UpdateAsync(new ProductUpdateDTO
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                CategoryId = productViewModel.CategoryId,
                ConditionId = productViewModel.ConditionId,
                Describtion = productViewModel.Describtion
            });

            if (updatedProduct == true && productViewModel.NewImages != null)
            {
                await productImagesManager.UpdateCollectionAsync(productViewModel.NewImages, productViewModel.Id, User.FindFirstValue(ClaimTypes.NameIdentifier)!, ct);
            }


            return RedirectToAction("management", "product"
                  , new { Id = HttpContext.Session.GetInt32("ShopId") });
        }
        return View(productViewModel);
    }


    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> AcceptProduct(int id)
    {
        //Console.WriteLine("\n\n" + "product"+TempData["DisplayedProductId"] + "\n\n");
        /*if (HttpContext.Session.GetInt32("ProductId") != id)
                {
                    TempData["MessageForAdmin"] = true;
                    return RedirectToAction("Management", "user");
                }*/
        bool result = await productsManager.EditStatusAsync(id, "مقبول");

        if (result)
        {
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> RefuseProduct(int id)
    {
        Console.WriteLine("\n\n" + "product" + TempData["DisplayedProductId"] + "\n\n");
        bool result = await productsManager.EditStatusAsync(id, "مرفوض");

        //check admin see product before accept or refuse it
        /*        if (HttpContext.Session.GetInt32("ProductId") != id)
                {
                    TempData["MessageForAdmin"] = true;
                    return RedirectToAction("Management", "user");
                }*/

        if (result)
        {
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [Authorize(Roles = "Manager,User")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        /*        var product = await productsManager.GetByIdAsync(id);
               if (product == null)
               {
                   return NotFound();
               }

              var shopVerification = await shopsManager.GetDetailsByIdAsync(product.ShopId);
               if (User.FindFirstValue(ClaimTypes.NameIdentifier) != shopVerification!.User?.Id
               && !User.IsInRole("Manager") && !User.IsInRole("Admin"))
               {
                   return NotFound();
               }*/

        if (await productImagesManager.DeleteCollectionAsync(id, ct))
        {
            await productsManager.DeleteAsync(id);
        }


        if (User.IsInRole("Manager") || User.IsInRole("Admin"))
        {
            ViewBag.ProductsPageSize = productsPageSize;
            ViewBag.ProductsCount = await productsManager.GetCountAsync();
            return PartialView("_PaginatedProductManagementTable");
        }


        return RedirectToAction("management", "product"
                  , new { Id = HttpContext.Session.GetInt32("ShopId") });
    }

}
