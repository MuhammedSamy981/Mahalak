
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;

public class ShopAddViewModel
{
  [Required(ErrorMessage = "برجاء إدخال أسم المحل")]
  [StringLength(20, MinimumLength = 2, ErrorMessage = "يجب أن لا يقل اسم المحل عن حرفين ولا يزيد عن 20 حرف")]
  [Remote("VerifyName", "Shop")]
  public string Name { get; set; } = string.Empty;

  [Remote("VerifyCategory", "Shop")]
  public int CategoryId { get; set; }

  public int CountryId { get; set; }

  [Remote("VerifyCity", "Shop")]
  public int CityId { get; set; }

  [Remote("VerifyArea", "Shop")]
  public int AreaId { get; set; }
    public string Status { get; set; } = string.Empty;

  public string ButtonName { get; set; } = string.Empty;

  public string? UserId { get; set; }
}