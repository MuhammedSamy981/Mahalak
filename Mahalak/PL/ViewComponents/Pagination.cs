using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Mahalak;
public class Pagination : ViewComponent
{
  private PaginationViewComponentModel paginationView = new PaginationViewComponentModel();

  public IViewComponentResult Invoke(
    int pageSize,
    int listLength,
    string controllerName,
    string actionName,
    string contentId)
  {
     paginationView.ControllerName = controllerName;
     paginationView.ActionName = actionName;
     paginationView.ContentId=contentId;
     paginationView.TotalPages = listLength % pageSize != 0 ? listLength / pageSize + 1 : listLength / pageSize;

     Console.WriteLine("\n\nlistLength"+paginationView.TotalPages);
    return View(paginationView);
  }

  public void loadData(
    int pageNumber,
    int pageSize,
    List<object> data,
    out List<object> paginatedData)
  {
    paginatedData = new List<object>();
    int length = pageSize * pageNumber;
    int index = length - pageSize;
    int count = 0;
    for (int i = index; i < length; i++)
    {
      if (data[i] != null)
      {
        paginatedData[count] = data[i];
        count++;
      }
    }
    Console.WriteLine(paginatedData);
  }
}