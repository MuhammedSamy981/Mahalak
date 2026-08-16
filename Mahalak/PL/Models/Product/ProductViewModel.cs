using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ProductViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; } = string.Empty;
  public PCategoryViewModel? Category { get; set; }
  public PConditionViewModel? Condition { get; set; }
  public string Price { get; set; } = string.Empty;
  public string? Status { get; set; }
  public ProductImageViewModel? InterfaceImage { get; set; }
  public bool Distinctive { get; set; }
  public string AddingDate { get; set; }= string.Empty;  
  public int ProductsCount { get; set; }
  public int ShopId{ get; set; }
}
