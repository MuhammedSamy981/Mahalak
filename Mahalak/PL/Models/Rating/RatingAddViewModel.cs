
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class RatingAddViewModel
{
  [Required(ErrorMessage = "برجاء أضافة تقييم")]
  public int Value{ get; set; }
  [Required(ErrorMessage = "برجاء أضافة تعليق ")]
  public string Comment { get; set; }= string.Empty;
  public int ShopId{ get; set; }
  public string UserId { get; set; }= string.Empty;
}
