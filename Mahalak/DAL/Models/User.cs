
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Mahalak;

public class User:IdentityUser
{

  [Required]
  [StringLength(11)]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  [StringLength(11)]
  public string LastName { get; set; } = string.Empty;

  [Required]
  public override string? Email { get; set; } 

  [Required]
  [StringLength(15)]
  public override string? PhoneNumber { get; set; }

  public int MaxShopNum { get; set; }

  public DateTime? AddedShopsExpiryDate { get; set; }

  [Range(0,99)]
  public int ViolationsCount { get; set; }

  public bool IsBlocked { get; set; }

  public DateTime? BanExpiryDate { get; set; }

  public bool IsExternallyLoggedIn { get; set; }

  public DateTime? LoginTime { get; set; }

  public ICollection<Shop> Shops { get; set; } = new HashSet<Shop>();

  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();


/*  [Required]
  [StringLength(4)]
  public string Gender { get; set; }= string.Empty;


  [Required]
  public DateTime Birthdate { get; set; }*/
}

