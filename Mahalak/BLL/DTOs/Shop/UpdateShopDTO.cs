
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class UpdateShopDTO
{

  public int ID { get; set; }

  [Required(ErrorMessage = "برجاء إدخال أسم المحل")]
  [StringLength(20, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المحل عن حرفين ولا يزيد عن 20 حرف")]
  public string Name { get; set; }= string.Empty;

  [Remote(action: "VerifyCategory", controller: "Shop")]
  public int CategoryID { get; set; }
  
  public string Status { get; set; }=string.Empty;


}
