
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class SCity
{
  [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]

  public int ID{ get; set; }

  [Required]
  public string Name{ get; set; } = string.Empty;

  [Required]
  [ForeignKey("CountryID")]
  public int CountryID{ get; set; }
  public SCountry? Country{ get; set; }
  public ICollection<SArea> Areas { get; set; }= new HashSet<SArea>();
  public ICollection<Shop> Shops { get; set; }= new HashSet<Shop>();
}
