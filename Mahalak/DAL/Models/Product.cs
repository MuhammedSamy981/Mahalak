
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mahalak;

public class Product
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(30)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [ForeignKey("ShopId")]
  public int ShopId { get; set; }

  public Shop? Shop { get; set; }

  [Required]
  [ForeignKey("CategoryId")]
  public int CategoryId { get; set; }

  public PCategory? Category { get; set; }

  [Required]
[Precision(12, 2)] 
public decimal Price { get; set; }

  [Required]
  [ForeignKey("ConditionId")]
  public int ConditionId { get; set; }

  public PCondition? Condition { get; set; }

  [Required]
  public string Describtion { get; set; } = string.Empty;

  [StringLength(5)]
  public string? Status { get; set; }

  public DateTime? AddingDate { get; set; }

  public ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();
}
