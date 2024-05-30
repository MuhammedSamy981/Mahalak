using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllRatingsDTO
{
  public int ID{ get; set; }
  public string UserName{ get; set; }= string.Empty;
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public string Datetime { get; set; }= string.Empty;
 public string Status { get; set; }=string.Empty;
  public int ShopID{ get; set; }
   public Guid UserID { get; set; }
}
