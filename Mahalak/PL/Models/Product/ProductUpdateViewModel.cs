
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class ProductUpdateViewModel
{
  public int Id { get; set; }

  [Required(ErrorMessage = "برجاء إدخال أسم المنتج")]
  [StringLength(30, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المنتج عن حرفين ولا يزيد عن 30 حرف")]
  public string Name { get; set; } = string.Empty;

  [Remote("VerifyCategory", "Product")]
  public int CategoryId { get; set; }

  [Required(ErrorMessage = "برجاء إدخال سعر المنتج")]
  [RegularExpression("[0-9]{1,9}", ErrorMessage = "يجب أن يحتوي سعر المنتج على أرقام فقط بحد أقصى 9 أرفام")]
  public decimal Price { get; set; }
  
  [Remote("VerifyCondition", "Product")]
  public int ConditionId { get; set; }

  [Required(ErrorMessage = "برجاء إدخال وصف المنتج")]
  public string Describtion { get; set; } = string.Empty;

  public List<ProductImageViewModel>? CurrentImages { get; set; }

  //[Required(ErrorMessage = "برجاء إدخال صور المنتج")]
  [DataType(DataType.Upload)]
  public List<IFormFile>? NewImages { get; set; }
  //public IFormFile[]? Images { get; set; }

  public string ButtonName { get; set; } = string.Empty;

  public string Status { get; set; } = string.Empty;
}