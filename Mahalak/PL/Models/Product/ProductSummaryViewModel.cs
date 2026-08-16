using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ProductSummaryViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public string Price { get; set; } = string.Empty;
  //public int ConditionId{ get; set; }
  public string Status { get; set; }=string.Empty;
  public string AddingDate { get; set; }= string.Empty;
  //public int ProductsCount { get; set; }
  public int ShopId{ get; set; }

}
