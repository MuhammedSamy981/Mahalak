
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Mahalak;
public class UserLoginViewModel
{
  [Required(ErrorMessage = "برجاء إدخال البريد الألكترونى")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إدخال كلمة المرور")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;
  public bool EmailConfirmed { get; set; }
  public bool IsBlocked { get; set; }
  public int ViolationsCount { get; set; }
  public string BanExpiryDate { get; set; }= string.Empty;
  
  //public ClaimsPrincipal? CP{ get; set; }
  public IEnumerable<AuthenticationScheme>? Schemes { get; set; }
}