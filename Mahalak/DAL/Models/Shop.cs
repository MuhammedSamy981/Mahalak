using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class Shop
{
  [Key]
  public int ID { get; set; }
  
 [Required]
  public string Name { get; set; }=string.Empty;

  [Required]
  [ForeignKey("UserID")]
  public Guid UserID { get; set; }

  public User? User { get; set; }

  [Required]
  [ForeignKey("CategoryID")]
  public int CategoryID { get; set; }

  public SCategory? Category { get; set; }

  [Required]
  [ForeignKey("CountryID")]
  public int CountryID { get; set; }

  public SCountry? Country { get; set; }

  [Required]
  [ForeignKey("CityID")]
  public int CityID { get; set; }
  public SCity? City { get; set; }

  [Required]
  [ForeignKey("AreaID")]
  public int AreaID { get; set; }
  public SArea? Area { get; set; }

  public string Status { get; set; }=string.Empty;

  public bool Distinctive { get; set; }

  [StringLength(100)]
  public string ExpDtOfMark { get; set; } = string.Empty;

  [Required]
  public int MaxProductNum { get; set; } =6;

  [StringLength(100)]
  public string CreatingDate { get; set; } = string.Empty;

  public ICollection<Product> Products { get; set; } = new HashSet<Product>();
  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();

}
