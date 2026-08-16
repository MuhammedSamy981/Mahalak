
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class RatingUpdateViewModel
{

  public int Id{ get; set; }
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public int ShopId{ get; set; }
  public string UserId { get; set; }= string.Empty;

}
