using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ShopDetailsSummaryDTO
{
  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public int CategoryId { get; set; }
  public string? UserId { get; set; }
  public string Status { get; set; }=string.Empty;
  public int MaxProductNum { get; set; }
  public DateTime? DistinctiveExpiryDate { get; set; }
  public int ProductsCount { get; set; }
  public DateTime? CreatingDate { get; set; }

}
