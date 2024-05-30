
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class PCondition
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int ID { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;
  public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
