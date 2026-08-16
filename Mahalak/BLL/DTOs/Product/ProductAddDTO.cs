
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;

public class ProductAddDTO
{
  public string Name { get; set; } = string.Empty;

  public int CategoryId { get; set; }

  public decimal Price { get; set; }

  public int ConditionId { get; set; }

  public string Describtion { get; set; } = string.Empty;

  public List<IFormFile>? Images { get; set; }
  //public IFormFile[]? Images { get; set; }

  public string Status { get; set; } = string.Empty;

  //public string ButtonName { get; set; } = string.Empty;

  public int ShopId { get; set; }
}
