
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalak;
public class Rating
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int Value { get; set; }

  [StringLength(50)]
  public string Comment { get; set; } = string.Empty;

  public DateTime? CommentDatetime { get; set; }

  [StringLength(5)]
  public string Status { get; set; } = string.Empty;

  [Required]
  [ForeignKey("ShopId")]
  public int ShopId { get; set; }

  public Shop? Shop { get; set; }

  [Required]
  [ForeignKey("UserId")]
  public string UserId { get; set; }= string.Empty;

  public User? User { get; set; }
}
