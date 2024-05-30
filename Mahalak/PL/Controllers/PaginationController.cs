using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Mahalak;
public class PaginationController : Controller
{
    public static int currentPage=1;
    public string? ActionName;
    public string? ControllerName;
 
[Route("pagination/showPreviousPage/{controllerName}/{actionName}")]
public IActionResult ShowPreviousPage(string actionName, string controllerName)
{
   //string actionName= HttpContext.Session.GetString("ActionName")!;
   //string controllerName=HttpContext.Session.GetString("ControllerName")!;

  if(currentPage!=1 && currentPage!=0)
  {
     currentPage-=1;
  }
 
  Console.WriteLine("\n\n"+currentPage+"\n\n");
  return RedirectToAction(actionName, controllerName, new { id=currentPage });
}

[Route("pagination/showNumberPage/{controllerName}/{actionName}/{id}")]
public IActionResult ShowNumberPage(string actionName, string controllerName,int id)
{  Console.WriteLine("\n\n"+"kkkkkk/".Split('/')[0]+"\n\n");

    //string actionName= HttpContext.Session.GetString("ActionName")!;
   //string controllerName=HttpContext.Session.GetString("ControllerName")!;
    currentPage=id;
   return RedirectToAction(actionName, controllerName, new { id=currentPage });
}

[Route("pagination/showNextPage/{controllerName}/{actionName}/{totalPages}")]
public IActionResult ShowNextPage(string actionName, string controllerName,int totalPages)
{
   //string actionName= HttpContext.Session.GetString("ActionName")!;
   //string controllerName=HttpContext.Session.GetString("ControllerName")!;

  if(currentPage<totalPages && currentPage!=0)
  {
     currentPage+=1;
  }
  if(currentPage>totalPages)
  {
    currentPage=totalPages;
  }
 
 // Console.WriteLine("p1:"+"\n\n"+currentPage+"\n"+totalPages+"\n\n");
  return RedirectToAction(actionName, controllerName, new { id=currentPage });
}   
}

