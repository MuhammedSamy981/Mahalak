
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class RatingAddDTO
{
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public int ShopId{ get; set; }
  public string UserId { get; set; }= string.Empty;
}
