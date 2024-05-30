
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class User
{
  [Key]
  public Guid ID { get; set; }

  [Required]
  [StringLength(100)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [StringLength(100)]
  public string Password { get; set; } = string.Empty;

  [Required]
  [StringLength(6)]
  public string Gender { get; set; } = string.Empty;

  [Required]
  [StringLength(15)]
  public string Phone { get; set; } = string.Empty;

  [StringLength(100)]
  public string Birthdate { get; set; } = string.Empty;

  [Required]
  [StringLength(100)]
  public string Email { get; set; } = string.Empty;

  [Required]
  [StringLength(100)]
  public string Role { get; set; }= "User";

  [Required]
  [StringLength(100)]
  public string LoginTime { get; set; } = string.Empty;

  public bool Status { get; set; }

  [Required]
  public int MaxShopNum { get; set; }=2;

  public string AddedShopsExpDate { get; set; }=string.Empty;

  [StringLength(2)]
  public int ViolationsCount { get; set; }

  [StringLength(100)]
  public string ExpDtOfBan { get; set; } = string.Empty;

  public ICollection<Shop> Shops { get; set; } = new HashSet<Shop>();
  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();

}
