
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ProductImageViewModel
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int ProductId{ get; set; }
}
