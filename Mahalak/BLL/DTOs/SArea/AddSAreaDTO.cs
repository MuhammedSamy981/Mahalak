
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class AddSAreaDTO
{
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int CityID{ get; set; }

}
