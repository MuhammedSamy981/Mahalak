
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Mahalak;
public class UserLoginDTO
{
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public bool EmailConfirmed { get; set; }
  public bool IsBlocked { get; set; }
  public int ViolationsCount { get; set; }
  public DateTime? BanExpiryDate { get; set; }
  //public ClaimsPrincipal? CP{ get; set; }
  public IEnumerable<AuthenticationScheme>? Schemes { get; set; }
}