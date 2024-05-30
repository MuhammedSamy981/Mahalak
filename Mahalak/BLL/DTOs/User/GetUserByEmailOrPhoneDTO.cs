
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Mahalak;
public class GetUserByEmailOrPhoneDTO
{
  public string EmailOrPhoneNumber { get; set; } = string.Empty;
  public string AdminPassword { get; set; } = string.Empty;
  public string ForgottenPassword { get; set; } = string.Empty;
  
}
