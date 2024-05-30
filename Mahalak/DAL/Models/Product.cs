
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class Product
{
  [Key]
  public int ID{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;

  [Required]
  [ForeignKey("ShopID")]
  public int ShopID{ get; set; }
  public Shop? Shop{ get; set; }

  [Required]
  [ForeignKey("CategoryID")]
  public int CategoryID{ get; set; }
  public PCategory? Category{ get; set; }

  [Required]
  public string Price { get; set; }= string.Empty;

 [Required]
 [ForeignKey("ConditionID")]
  public int ConditionID{ get; set; }
  public PCondition? Condition{ get; set; }

  [Required]
  public string Describtion { get; set; }= string.Empty;
  public string Status { get; set; }=string.Empty;

  [StringLength(100)]
  public string AddingDate { get; set; }= string.Empty;
  
  public ICollection<ProductImage> Images{ get; set; }=new HashSet<ProductImage>();
  
}
