using System.ComponentModel.DataAnnotations;

namespace Mahalak;

public class ProductSummaryDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  //public int ConditionId{ get; set; }
  public string Status { get; set; } = string.Empty;
  public DateTime? AddingDate { get; set; }
  //public int ProductsCount { get; set; }
  public int ShopId { get; set; }

}
