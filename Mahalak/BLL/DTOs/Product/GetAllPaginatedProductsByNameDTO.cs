using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllPaginatedProductsByNameDTO
{
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int ShopID{ get; set; }
  public int CategoryID{ get; set; }
  public string Price { get; set; }= string.Empty;
  public int ConditionID{ get; set; }
  public string Status { get; set; }=string.Empty;
  public string AddingDate { get; set; }= string.Empty;
 public int ProductsCount { get; set; }
}
