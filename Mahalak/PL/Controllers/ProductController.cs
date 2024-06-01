using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace Mahalak;

public class ProductController : Controller
{
    public static string[] images=[];

    private readonly IShopsManager shopsManager;
    private readonly IProductsManager productsManager;
    private readonly IPCategoriesManager categoriesManager;
    private readonly IPConditionsManager conditionsManager;
    private readonly IProductImagesManager productImagesManager;
    private readonly IWebHostEnvironment webHostEnvironment;
    public ProductController(IShopsManager shopsManager,
    IProductsManager productsManager,
    IPCategoriesManager categoriesManager,
    IPConditionsManager conditionsManager,
    IProductImagesManager productImagesManager,
    IWebHostEnvironment webHostEnvironment)
    {
        this.shopsManager = shopsManager;
        this.productsManager = productsManager;
        this.categoriesManager = categoriesManager;
        this.conditionsManager = conditionsManager;
        this.productImagesManager = productImagesManager;
        this.webHostEnvironment = webHostEnvironment;
    }

[Authorize(Roles ="User")]
[HttpGet]
[Route("products/{shopID}/{id}")]
    public IActionResult Index(int shopID,int id)
    {
        TempData["Name"] = "" ;
        TempData["Price"] = "" ;
        TempData["Category"] = "" ;
        TempData["Condition"] = "" ;
        TempData["Describtion"] = "" ;

        if (images != null)
        {
          productImagesManager.DeleteTemporeryImages(images!);
        }
        HttpContext.Session.SetInt32("ShopID", shopID);

        var products = productsManager.GetAllPaginatedByShopId(shopID,3,id);
        ViewBag.ProductsCount=(products.Count!=0)?products[0].ProductsCount:0;
        ViewBag.ShopID=shopID;
        return View(products);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        var product = productsManager.GetAllDetailsById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [Authorize(Roles ="User")]
    public IActionResult Create()
    {
                 ViewBag.BackToShop= HttpContext.Session.GetInt32("ShopID");
        
        ViewBag.Images = TempData["Images"];
        var shopCategoryId = shopsManager.GetById(Convert.ToInt32(HttpContext.Session.GetInt32("ShopID")))!.CategoryID;


            ViewBag.categories = (Convert.ToString(TempData["Category"]) != "") ?

             new SelectList(categoriesManager
            .GetAllBySCategoryId(shopCategoryId)
             ,"ID", "Name", Convert.ToInt32(TempData["Category"])) : 

             new SelectList(categoriesManager
            .GetAllBySCategoryId(shopCategoryId)
             ,"ID", "Name");


            ViewBag.conditions = (Convert.ToString(TempData["Condition"]) != "") ?

            new SelectList(conditionsManager.GetAll()
            ,"ID", "Name", Convert.ToInt32(TempData["Condition"])) :

            ViewBag.conditions = new SelectList(conditionsManager.GetAll()
            , "ID", "Name");




        return View();
    }


    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCategory(int categoryID)
    {
        if (!productsManager.VerifyField(categoryID))
        {
            return Json($"برجاء أختيار نوع المنتج");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult VerifyCondition(int conditionID)
    {
        if (!productsManager.VerifyField(conditionID))
        {
            return Json($"برجاء أختيار حالة المنتج");
        }

        return Json(true);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AddProductDTO productDTO,
    Microsoft.AspNetCore.Http.IFormCollection formcollection)
    {
        TempData["Name"] = "" + formcollection["Name"];
        TempData["Price"] = "" + formcollection["Price"];
        TempData["Category"] = "" + formcollection["CategoryID"];
        TempData["Condition"] = "" + formcollection["ConditionID"];
        TempData["Describtion"] = "" + formcollection["Describtion"];

        if (productDTO.Images?.Length == 4)
        {
            images = productImagesManager.ShowUploadedImages(productDTO.Images);
            TempData["Images"] = images;
        }
        //Console.WriteLine("\n\n"+images[0]+"\n\n");
        if (ModelState.IsValid && HttpContext.Session.GetInt32("ShopID") != 0 && images != null
         && productDTO.ButtonName=="Add")
        {

            productDTO.ShopID = Convert.ToInt32(HttpContext.Session.GetInt32("ShopID"));
            //productDTO.CategoryID = categoriesManager.GetAllBySCategoryId(Convert.ToInt32(HttpContext.Session.GetInt32("Category")))[0].ID;
            bool addedProduct = productsManager.Add(productDTO);

            if (addedProduct)
            {
                productImagesManager.AddCollection(images);
              
               return RedirectToAction(HttpContext.Session.GetInt32("ShopID").ToString(), "products"
                , new { id = 1 });
            }
        }
        return RedirectToAction("create");

    }




    [Authorize(Roles ="User")]
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        ViewBag.BackToShop= HttpContext.Session.GetInt32("ShopID");
        
        if(TempData["Images"]!=null)
        {
          ViewBag.Images = TempData["Images"];
        }
        else
        {
          ViewBag.ProductImages = productImagesManager.GetAllByProductId(id);
        }

       int shopCategoryId = shopsManager.GetById(Convert.ToInt32(HttpContext.Session.GetInt32("ShopID")))!.CategoryID;

        ViewBag.categories = new SelectList(categoriesManager
            .GetAllBySCategoryId(shopCategoryId)
             ,"ID", "Name",Convert.ToInt32(TempData["CategoryID"]));


            ViewBag.conditions = new SelectList(conditionsManager.GetAll()
            , "ID", "Name");

        var product = productsManager.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        TempData["ProductId"] = id;
        TempData["CategoryID"]=product.CategoryID;
        Console.WriteLine("\n\n"+TempData["CategoryID"]+"\n\n");

        return View(new UpdateProductDTO
        {
            Name = product.Name,
            Price = product.Price,
            CategoryID = product.CategoryID,
            ConditionID=product.ConditionID,
            Describtion=product.Describtion
        });
    }


    [HttpPost]
    public IActionResult Edit(UpdateProductDTO productDTO)
    {
        if (productDTO.Images?.Length == 4)
        {
            images =  productImagesManager.ShowUploadedImages(productDTO.Images);
            TempData["Images"] = images;
        }
        Console.WriteLine("\n\n"+productDTO.CategoryID+"\n\n");

        if (ModelState.IsValid && productDTO.ButtonName=="Edit")
        {

            productDTO.ID= Convert.ToInt32(TempData["ProductId"]);
            //productDTO.CategoryID = categoriesManager.GetByShopId(Convert.ToInt32(HttpContext.Session.GetInt32("ShopID")))[0].ID;
            bool updatedProduct =  productsManager.Update(productDTO);

            if (updatedProduct==true && images != null)
             {
              productImagesManager.UpdateCollection(images,productDTO.ID);
                
            }
             return RedirectToAction(HttpContext.Session.GetInt32("ShopID").ToString(), "products"
                , new { id = 1 });
        }
        return RedirectToAction("edit");
    }

    public IActionResult AcceptProduct(int id)
    {
        productsManager.EditStatus(id, "مقبول");
        return RedirectToAction("index", "user");
    }

    public IActionResult RefuseProduct(int id)
    {
        productsManager.EditStatus(id, "مرفوض");
        return RedirectToAction("index", "user");
    }

    public IActionResult Delete(int id)
    {
        productsManager.Delete(id);
         return RedirectToAction(HttpContext.Session.GetInt32("ShopID").ToString(), "products"
                , new { id = 1 });
    }
}
