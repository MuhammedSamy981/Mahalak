using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class RatingViewModel
{
  public int Id{ get; set; }
  public string UserName{ get; set; }= string.Empty;
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public string CommentDatetime { get; set; }= string.Empty;
  public string Status { get; set; }=string.Empty;
  public int ShopId{ get; set; }
  public string UserId { get; set; }= string.Empty;
}
