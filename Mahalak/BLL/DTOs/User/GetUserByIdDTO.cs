
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetUserByIdDTO
{
  public Guid ID { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string Gender { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Birthdate { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Role { get; set; }= string.Empty;
   public int ShopsCount { get; set; }
  public int MaxShopNum { get; set; }
  public string AddedShopsExpDate { get; set; }=string.Empty;
  public string LoginTime { get; set; } = string.Empty;

  public string ExpDtOfBan { get; set; } = string.Empty;

}
