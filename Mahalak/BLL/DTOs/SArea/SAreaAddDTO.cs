
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class SAreaAddDTO
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int CityId{ get; set; }

}
