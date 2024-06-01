
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class AddUserDTO
{
   [Required(ErrorMessage = "برجاء إدخال أسم المستحدم")]
   [StringLength(20, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المستخدم عن حرفين ولا يزيد عن 20 حرف")]
   [Remote(action: "VerifyName", controller: "User")]
   public string Name { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء إدخال كلمةالمرور")]
   [DataType(DataType.Password)]
   public string Password { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء إعادة إدخال كلمةالمرور")]
   [DataType(DataType.Password)]
   [Compare("Password", ErrorMessage = "برجاء التحقق من تأكيد كلمة المرور")]
   public string ConfirmPass { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء تحديد النوع")]
   public string Gender { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء إدخال رقم الهاتف")]
   [DataType(DataType.PhoneNumber)]
   [StringLength(15, MinimumLength = 7, ErrorMessage = "برجاء التأكد من صحة رقم الهاتف")]
   [Remote(action: "VerifyPhone", controller: "User")]
   public string Phone { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء إدخال تاريخ الميلاد")]
   [DataType(DataType.Date)]
   public string Birthdate { get; set; } = string.Empty;

   [Required(ErrorMessage = "برجاء إدخال البريد الألكترونى")]
   [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z_]+.[a-zA-Z]{3,4}", ErrorMessage = "برجاء التأكد من صحة البريد الألكترونى")]
   [Remote(action: "VerifyEmail", controller: "User")]
   public string Email { get; set; } = string.Empty;
   

}
