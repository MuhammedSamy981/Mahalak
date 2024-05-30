
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class SArea
{
  [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]

  public int ID{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;
  [Required]
  [ForeignKey("CityID")]
  public int CityID{ get; set; }
  public SCity? City{ get; set; }
  public ICollection<Shop> Shops=new HashSet<Shop>();
}
