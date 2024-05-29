
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Mahalak;
public class GetUserLoginDTO
{
  [Required(ErrorMessage = "برجاء إدخال البريد الألكترونى أو رقم الهاتف")]
  public string EmailOrPhoneNumber { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إدخال كلمة المرور")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;
  public bool Status { get; set; }
 public int ViolationsCount { get; set; }
 public string ExpDtOfBan { get; set; } = string.Empty;
  public ClaimsPrincipal? CP{ get; set; }
  
}
