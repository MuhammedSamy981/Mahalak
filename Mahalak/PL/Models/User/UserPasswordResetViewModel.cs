
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class UserPasswordResetViewModel
{
  public string Email { get; set; } = string.Empty;
  public string Token { get; set; }= string.Empty;
  [Required(ErrorMessage = "برجاء إدخال كلمة المرور")]
  [DataType(DataType.Password)]
  public string NewPassword { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إعادة إدخال كلمة المرور")]
  [DataType(DataType.Password)]
  [Compare("NewPassword", ErrorMessage = "برجاء التحقق من تأكيد كلمة المرور")]
  public string ConfirmPass { get; set; } = string.Empty;
  
}
