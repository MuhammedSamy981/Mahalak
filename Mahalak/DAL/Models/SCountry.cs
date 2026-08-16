
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class SCountry
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Currency { get; set; } = string.Empty;
  public ICollection<SCity> Cities { get; set; } = new HashSet<SCity>();
  public ICollection<Shop> Shops { get; set; } = new HashSet<Shop>();
}
