
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;
public class UserUpdateDTO
{
  public string Id { get; set; } = string.Empty;

  public string FirstName { get; set; } = string.Empty;

  public string LastName { get; set; } = string.Empty;

/*public string Password { get; set; } = string.Empty;

  public string ConfirmPass { get; set; } = string.Empty;*/

/*public string Gender { get; set; } = string.Empty;*/

  public string PhoneNumber { get; set; } = string.Empty;

/*public DateTime Birthdate { get; set; }*/

  public string Email { get; set; } = string.Empty;
}

