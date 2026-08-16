
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class SCityAddDTO
{
  public int Id{ get; set; }
  public string Name{ get; set; } = string.Empty;
  public int CountryId{ get; set; }
}
