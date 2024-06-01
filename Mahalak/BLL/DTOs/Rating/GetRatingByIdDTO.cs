
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetRatingByIdDTO
{

  public int ID{ get; set; }
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public string Datetime { get; set; }= string.Empty;
  public int ShopID{ get; set; }
   public Guid UserID { get; set; }

}
