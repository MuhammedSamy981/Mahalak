
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetForgottenUserPasswordDTO
{
  [Required(ErrorMessage = "برجاء إدخال البريد الألكترونى")]
  public string Email { get; set; } = string.Empty;

}
