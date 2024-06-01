
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class AddShopDTO
{
  [Required(ErrorMessage = "برجاء إدخال أسم المحل")]
  [StringLength(30, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المحل عن حرفين ولا يزيد عن 30 حرف")]
  [Remote(action: "VerifyName", controller: "Shop")]
  public string Name { get; set; }= string.Empty;

  [Remote(action: "VerifyCategory", controller: "Shop")]
  public int CategoryID { get; set; }

  [Remote(action: "VerifyCountry", controller: "Shop")]
  public int CountryID { get; set; }

  [Remote(action: "VerifyCity", controller: "Shop")]
  public int CityID { get; set; }

  [Remote(action: "VerifyArea", controller: "Shop")]
  public int AreaID { get; set; }
    public string ButtonName { get; set; }= string.Empty;
   public Guid UserID { get; set; }
}
