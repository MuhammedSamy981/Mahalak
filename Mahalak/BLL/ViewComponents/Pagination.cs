using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Mahalak;
public class Pagination : ViewComponent
{   
     PaginationViewComponentModel paginationView=new PaginationViewComponentModel();


    public IViewComponentResult Invoke(int pageSize, int listLength,string actionName,string controllerName)
    {
      paginationView!.ActionName=actionName;
      //HttpContext.Session.SetString("ControllerName", controllerName);
      paginationView!.ControllerName=controllerName;
      paginationView!.TotalPages=(listLength%pageSize!=0)?(listLength/pageSize)+1:(listLength/pageSize);   

      return View(paginationView);
    }

  //  public IViewComponentResult Invoke(int sizeOfPage,,out List<object> paginatedData)
  //  {
  //      loadData(currentPage,sizeOfPage,data,out paginatedData);
  //  totalPages = data.Count/sizeOfPage;
// for(int i = 0 ; i < totalPages ;i++)
// {
//    pageNumbers[i]= i+1;
 // }
//  return View(pageNumbers);
  //  }

public void loadData(int pageNumber,int pageSize,List<object> data,out List<object> paginatedData)
{
  paginatedData = []; 
  int length=pageSize*pageNumber;
  int index=length-pageSize;
  int count=0;
  for(int i=index;i<length;i++)
  {
    if(data[i]!=null)
    {
      paginatedData[count]=data[i];
      count++;
    }
  }
  Console.WriteLine(paginatedData);  
}
}