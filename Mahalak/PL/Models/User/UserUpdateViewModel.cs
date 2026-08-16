
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class UserUpdateViewModel
{
   public string Id { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إدخال الأسم الأول")]
  [StringLength(10, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل الأسم الأول عن حرفين ولا يزيد عن 10 حرف")]
  public string FirstName { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إدخال الأسم الثاني")]
  [StringLength(10, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل الأسم الثاني عن حرفين ولا يزيد عن 10 حرف")]
  public string LastName { get; set; } = string.Empty;

/*  [Required(ErrorMessage = "برجاء إدخال كلمةالمرور")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "برجاء إعادة إدخال كلمةالمرور")]
  [DataType(DataType.Password)]
  [Compare("Password", ErrorMessage = "برجاء التحقق من تأكيد كلمة المرور")]
  public string ConfirmPass { get; set; } = string.Empty;*/

 /* [Required(ErrorMessage = "برجاء تحديد النوع")]
  public string Gender { get; set; } = string.Empty;*/

  [Required(ErrorMessage = "برجاء إدخال رقم الهاتف")]
  [DataType(DataType.PhoneNumber)]
  [RegularExpression("[0-9]{7,15}", ErrorMessage = "برجاء التأكد من صحة رقم الهاتف")]
  [Remote("VerifyEditPhoneNumber", "User")]
  public string PhoneNumber { get; set; } = string.Empty;

  /*[Required(ErrorMessage = "برجاء إدخال تاريخ الميلاد")]
  [DataType(DataType.Date)]
  public DateTime Birthdate { get; set; }*/

  [Required(ErrorMessage = "برجاء إدخال البريد الألكترونى")]
  [RegularExpression("[a-zA-Z0-9_]+@[a-zA-Z_]+.[a-zA-Z]{3,4}", ErrorMessage = "برجاء التأكد من صحة البريد الألكترونى")]
  [Remote("VerifyEditEmail", "User")]
  public string Email { get; set; } = string.Empty;
}

