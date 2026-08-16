
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class ShopUpdateViewModel
{
   public int Id { get; set; }

  [Required(ErrorMessage = "برجاء إدخال أسم المحل")]
  [StringLength(20, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المحل عن حرفين ولا يزيد عن 20 حرف")]
  [Remote("VerifyEditName", "Shop")]
  public string Name { get; set; } = string.Empty;

  [Remote("VerifyCategory", "Shop")]
  public int CategoryId { get; set; }

  public string Status { get; set; } = string.Empty;
}
