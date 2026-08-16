
using System.ComponentModel.DataAnnotations;

namespace Mahalak;

public class ProductDetailsDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public string Currency { get; set; } = string.Empty;
  public PCategoryDTO? Category { get; set; }
  public PConditionDTO? Condition { get; set; }
  public List<ProductImageDTO>? Images { get; set; }
  public string Describtion { get; set; } = string.Empty;
  public string Status { get; set; } = string.Empty;
  public int ShopId { get; set; }
  public string ShopName { get; set; } = string.Empty;
}
