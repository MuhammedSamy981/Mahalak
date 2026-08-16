
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class UserDTO
{
  public string Id { get; set; } = string.Empty;  
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public bool EmailConfirmed { get; set; }
  public string PhoneNumber { get; set; } = string.Empty;
  public string RoleName { get; set; } = string.Empty;
  public int MaxShopNum { get; set; }
  public DateTime? AddedShopsExpiryDate { get; set; }
  public int ViolationsCount { get; set; }
  public bool IsBlocked { get; set; }
  public DateTime? BanExpiryDate { get; set; }
  public DateTime? LoginTime { get; set; } 
}
