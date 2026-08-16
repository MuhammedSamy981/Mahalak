using System.ComponentModel.DataAnnotations;

namespace Mahalak;

public class ProductFiltersViewModel
{
  public string Name { get; set; } = string.Empty;
  public int CategoryId { get; set; }
  //[Range(0,4)]      
  public decimal MinPrice { get; set; }
  //[Range(typeof(decimal), "0.01", "9999.99", ErrorMessage = "Price must be between {1} and {2}.")]
  public decimal MaxPrice { get; set; }
  public int ConditionId { get; set; }
}
