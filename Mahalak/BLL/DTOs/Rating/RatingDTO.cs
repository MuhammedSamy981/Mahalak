using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class RatingDTO
{
  public int Id{ get; set; }
  public string UserFirstName { get; set; } = string.Empty;
  public string UserLastName { get; set; } = string.Empty;
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public DateTime? CommentDatetime { get; set; }
  public string Status { get; set; }=string.Empty;
  public int ShopId{ get; set; }
  public string UserId { get; set; }= string.Empty;
}
