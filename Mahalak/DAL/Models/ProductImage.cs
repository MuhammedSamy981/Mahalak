using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class ProductImage
{
  [Key]
  public int ID{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;

  [Required]
  [ForeignKey("ProductID")]
  public int ProductID{ get; set; }
  public Product? Product{ get; set; }

}
