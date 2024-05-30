
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class AddProductDTO
{
  [Required(ErrorMessage = "برجاء إدخال أسم المنتج")]
  public string Name { get; set; }= string.Empty;

  [Remote(action: "VerifyCategory", controller: "Product")]
  public int CategoryID{ get; set; }

  [Required(ErrorMessage = "برجاء إدخال سعر المنتج")]
  public string Price { get; set; }= string.Empty;

  [Remote(action: "VerifyCondition", controller: "Product")]
  public int ConditionID{ get; set; }

  [Required(ErrorMessage = "برجاء إدخال وصف المنتج")]
  public string Describtion { get; set; }= string.Empty;

  //[Required(ErrorMessage = "برجاء إدخال صور المنتج")]  
  public IFormFile[]? Images { get; set; }
  public string ButtonName { get; set; }= string.Empty;
  public int ShopID{ get; set; }
}
