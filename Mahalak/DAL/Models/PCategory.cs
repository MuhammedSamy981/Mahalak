
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class PCategory
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int ID{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;

  [Required]
  [ForeignKey("CategoryID")]
  public int SCategoryID{ get; set; }
  public SCategory? SCategory{ get; set; }
  public ICollection<Product> Products{ get; set; }=new HashSet<Product>();

}
