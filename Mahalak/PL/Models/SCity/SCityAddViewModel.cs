
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class SCityAddViewModel
{
  public int Id{ get; set; }
  public string Name{ get; set; } = string.Empty;
  public int CountryId{ get; set; }
}
