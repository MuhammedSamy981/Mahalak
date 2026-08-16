
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class SCountryUpdateViewModel
{
  public int Id{ get; set; }
  public string Name{ get; set; } = string.Empty;
  public string Currency { get; set; } = string.Empty;
}
