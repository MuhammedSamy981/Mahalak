using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllPaginatedShopsDTO
{
  public int ID { get; set; }
  public string Name = string.Empty;
  public Guid UserID { get; set; }
  public int CategoryID { get; set; }
  public int CountryID { get; set; }
  public int CityID { get; set; }
  public int AreaID { get; set; }
  public string Status { get; set; }=string.Empty;
  public bool Distinctive { get; set; }
  public string ExpDtOfMark { get; set; } = string.Empty;
  public int MaxProductNum { get; set; }
  public string CreatingDate { get; set; } = string.Empty;
  public int TotalRaters { get; set; }
  public int ShopsCount { get; set; }

}
