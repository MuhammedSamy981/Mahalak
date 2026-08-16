
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class PCategoryUpdateViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int SCategoryId{ get; set; }
}
