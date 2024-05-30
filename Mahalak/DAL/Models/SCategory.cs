
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class SCategory
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int ID{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;
   public ICollection<Shop> Shops{ get; set; }=new HashSet<Shop>();

}
