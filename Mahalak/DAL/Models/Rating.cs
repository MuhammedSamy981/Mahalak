
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class Rating
{
  [Key]
  public int ID{ get; set; }

  [Required]
  public int Value{ get; set; }

  [StringLength(50)]
  public string Comment { get; set; }= string.Empty;

  [StringLength(100)]
  public string Datetime { get; set; }= string.Empty;
  public string Status { get; set; }=string.Empty;

  [Required]
  [ForeignKey("ShopID")]
  public int ShopID{ get; set; }
  public Shop? Shop{ get; set; }
  
  [Required]
  [ForeignKey("UserID")]
  public Guid UserID { get; set; }
  public User? User{ get; set; }

}
