
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class UserViewModel
{
  public string Id { get; set; } = string.Empty;  
  public string FullName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public bool EmailConfirmed { get; set; }
  public string PhoneNumber { get; set; } = string.Empty;
  public string RoleName { get; set; } = string.Empty;
  public int MaxShopNum { get; set; }
  public string AddedShopsExpiryDate { get; set; } = string.Empty;
  public int ViolationsCount { get; set; }
  public bool IsBlocked { get; set; }
  public string BanExpiryDate { get; set; }= string.Empty;
  public string LoginTime { get; set; } = string.Empty;
}
