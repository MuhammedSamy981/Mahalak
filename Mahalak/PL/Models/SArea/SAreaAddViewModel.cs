
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class SAreaAddViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int CityId{ get; set; }

}
