using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class ProductImage
{
  [Key]
  public int Id{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;

  [Required]
  [ForeignKey("ProductId")]
  public int ProductId{ get; set; }
  public Product? Product{ get; set; }

}
