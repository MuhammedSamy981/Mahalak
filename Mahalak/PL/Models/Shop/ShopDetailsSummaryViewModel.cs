using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ShopDetailsSummaryViewModel
{
  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public int CategoryId { get; set; }
  public string? UserId { get; set; }
  public string Status { get; set; }=string.Empty;
  public int MaxProductNum { get; set; }
  public string DistinctiveExpiryDate { get; set; }= string.Empty;
  public int ProductsCount { get; set; }
  public string CreatingDate { get; set; }= string.Empty;

}
