
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetSCityByIdDTO
{
    public int ID{ get; set; }
  public string Name{ get; set; } = string.Empty;
  public int CountryID{ get; set; }
  
}
