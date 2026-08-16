using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ProductDetailsSummaryViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public string Price { get; set; }= string.Empty;
  public PCategoryViewModel? Category { get; set; }
  public PConditionViewModel? Condition { get; set; }
  public List<ProductImageViewModel>? Images { get; set; }
  public string Describtion { get; set; }= string.Empty;
  public string Status { get; set; }=string.Empty;
  public int ShopId{ get; set; }

}
