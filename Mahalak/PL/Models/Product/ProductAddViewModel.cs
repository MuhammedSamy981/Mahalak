
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class ProductAddViewModel
{
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


  //[Required(ErrorMessage = "برجاء إدخال صور المنتج")]

  //[Remote("VerifyImages", "Product")] 

/* 
//do not work with input with style ="display :none;"  
 [ImagesValidation(
  MinFiles = 1,
  MaxFiles = 5,
  MaxFileSize = 2 * 1024 * 1024,
  AllowedExtensions = new[] { ".jpg", ".jpeg", ".png" }
)]*/
    [DataType(DataType.Upload)]
    public List<IFormFile>? Images { get; set; }
    //public IFormFile[]? Images { get; set; }

  public string Status { get; set; } = string.Empty;

  //public string ButtonName { get; set; } = string.Empty;

  public int ShopId { get; set; }
}
