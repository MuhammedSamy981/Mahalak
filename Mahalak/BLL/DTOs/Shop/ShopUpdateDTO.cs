
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class ShopUpdateDTO
{
  public int Id { get; set; }

  public string Name { get; set; } = string.Empty;

  public int CategoryId { get; set; }

  public string Status { get; set; } = string.Empty;
}
