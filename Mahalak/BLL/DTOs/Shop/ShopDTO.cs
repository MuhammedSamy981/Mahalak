using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ShopDTO
{
  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public string UserId { get; set; }= string.Empty;
  public int CategoryId { get; set; }
  public int CountryId { get; set; }
  public int CityId { get; set; }
  public int AreaId { get; set; }
  public string Status { get; set; }=string.Empty;
  public bool Distinctive { get; set; }
  public DateTime? DistinctiveExpiryDate { get; set; }
  public int MaxProductNum { get; set; }
  public DateTime? CreatingDate { get; set; }
  public int TotalRaters { get; set; }
  public int ShopsCount { get; set; }

}
