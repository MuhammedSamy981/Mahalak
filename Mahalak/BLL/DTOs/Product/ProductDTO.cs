using System.ComponentModel.DataAnnotations;

namespace Mahalak;

public class ProductDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public PCategoryDTO? Category { get; set; }
  public PConditionDTO? Condition { get; set; }
  public decimal Price { get; set; }
  public string Currency { get; set; } = string.Empty;
  public string? Status { get; set; }
  public List<ProductImageDTO>? Images { get; set; }
  public bool Distinctive { get; set; }
  public DateTime? AddingDate { get; set; }
  public int ProductsCount { get; set; }
  public int ShopId { get; set; }
}
