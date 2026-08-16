using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class Shop
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(20)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [ForeignKey("UserId")]
  public string UserId { get; set; } = string.Empty;

  public User? User { get; set; }

  [Required]
  [ForeignKey("CategoryId")]
  public int CategoryId { get; set; }

  public SCategory? Category { get; set; }

  [Required]
  [ForeignKey("CountryId")]
  public int CountryId { get; set; }

  public SCountry? Country { get; set; }

  [Required]
  [ForeignKey("CityId")]
  public int CityId { get; set; }

  public SCity? City { get; set; }

  [Required]
  [ForeignKey("AreaId")]
  public int AreaId { get; set; }

  public SArea? Area { get; set; }

  [StringLength(5)]
  public string? Status { get; set; }

  public DateTime? DistinctiveExpiryDate { get; set; }

  public int MaxProductNum { get; set; }

  public DateTime? CreatingDate { get; set; }

  public ICollection<Product> Products { get; set; } = new HashSet<Product>();

  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
}
