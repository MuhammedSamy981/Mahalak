using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ShopSummaryViewModel
{
  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public string? UserId { get; set; }
  public string Status { get; set; }=string.Empty;
  public bool Distinctive { get; set; }
  public string DistinctiveExpiryDate { get; set; }= string.Empty;
  public int MaxProductNum { get; set; }
  public string CreatingDate { get; set; }= string.Empty;
}
