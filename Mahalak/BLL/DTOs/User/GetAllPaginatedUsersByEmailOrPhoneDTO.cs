
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllPaginatedUsersByEmailOrPhoneDTO
{
  public Guid ID { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Gender { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Birthdate { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Role { get; set; }= string.Empty;
  public string LoginTime { get; set; } = string.Empty;
  public bool Status { get; set; }
  public int MaxShopNum { get; set; }
  public string AddedShopsExpDate { get; set; }=string.Empty;
   public int ViolationsCount { get; set; }
   public string ExpDtOfBan { get; set; } = string.Empty;
public int UsersCount { get; set; }
}
