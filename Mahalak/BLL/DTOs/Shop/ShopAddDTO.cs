
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;

public class ShopAddDTO
{

  public string Name { get; set; } = string.Empty;

  public int CategoryId { get; set; }

  public int CountryId { get; set; }

  public int CityId { get; set; }

  public int AreaId { get; set; }
  
  public string Status { get; set; } = string.Empty;

  public string ButtonName { get; set; } = string.Empty;

  public string? UserId { get; set; }
}