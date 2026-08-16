
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Zlib;


namespace Mahalak;

public class UsersManager : IUsersManager
{
  private readonly UserManager<User> userManager;
  private readonly SignInManager<User> signInManager;
  private readonly IUnitOfWork unitOfWork;

  public UsersManager(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
  {
    this.userManager = userManager;
    this.signInManager = signInManager;
    this.unitOfWork = unitOfWork;
  }

  /*  public async Task<List<UserDTO>> GetPaginatedAsync(
      int pageSize,
      int pageNumber)
    {
      List<User> users = await  unitOfWork.UsersRepository.GetAllAsync();
      int length = pageSize * pageNumber - pageSize;
      if (pageSize > users.Count - length)
        pageSize = users.Count - length;
      return users.Select(u => new UserDTO
      {
        ID = u.ID,
         FirstName=u.FirstName,
      LastName=u.LastName,
        Gender = u.Gender,
        Birthdate = u.Birthdate,
        PhoneNumber = u.PhoneNumber,
        Email = u.Email,
        Role = u.Role,
        MaxShopNum = u.MaxShopNum,
        AddedShopsExpiryDate = u.AddedShopsExpiryDate,
        LoginTime = u.LoginTime,
        IsBlocked = u.IsBlocked,
        ViolationsCount = u.ViolationsCount,
        UsersCount = users.Count
      }).ToList().GetRange(length, pageSize);
    }*/

  public async Task<List<UserDTO>> GetPaginatedByRoleAsync(int pageNumber, int pageSize,
    string roleName, CancellationToken ct=default)
  {
   /*var users = await userManager.GetUsersInRoleAsync(roleName.Trim());
    int index = pageSize * pageNumber - pageSize;
    if (pageSize > users.Count - index)
      pageSize = users.Count - index;*/

    var users = await unitOfWork.UsersRepository.GetPaginatedByRoleAsync(pageNumber,pageSize,roleName.Trim(),ct);
    return users.Select(u => new UserDTO
    {
      Id = u.Id,
      FirstName = u.FirstName,
      LastName = u.LastName,
      PhoneNumber = u.PhoneNumber!,
      Email = u.Email!,
      EmailConfirmed = u.EmailConfirmed,
      RoleName = roleName.Trim(),
      MaxShopNum = u.MaxShopNum,
      AddedShopsExpiryDate = u.AddedShopsExpiryDate,
      LoginTime = u.LoginTime,
      IsBlocked = u.IsBlocked,
      ViolationsCount = u.ViolationsCount,
    }).ToList();//.GetRange(index, pageSize);
  }

    public async Task<int> GetCountByRoleAsync(string roleName, CancellationToken ct=default)
    {
      return await unitOfWork.UsersRepository.GetCountByRoleAsync(roleName,ct);
    }

  public async Task<List<UserDTO>> GetPaginatedByEmailOrPhoneNumberAsync(int pageNumber
    , int pageSize,string roleName, string emailOrPhoneNumber, CancellationToken ct=default)
  {
/*    var users = (await userManager.GetUsersInRoleAsync(roleName.Trim())).Where(u => u.Email.Contains(emailOrPhoneNumber.Trim())
    || u.PhoneNumber.Contains(emailOrPhoneNumber.Trim())).ToList();
    int num = pageSize * pageNumber;
    int index = num - pageSize;
    if (pageSize > users.Count - index)
      pageSize = users.Count - index;
    Console.WriteLine($"\n\n{users.Count.ToString()}\n\n{index.ToString()}\n\n{num.ToString()}\n\n");*/
    var users = await unitOfWork.UsersRepository.GetSearchResultPaginatedAsync(pageNumber,pageSize,roleName,emailOrPhoneNumber,ct);
    return users.Select(u => new UserDTO
    {
      Id = u.Id,
      FirstName = u.FirstName,
      LastName = u.LastName,
      PhoneNumber = u.PhoneNumber!,
      Email = u.Email!,
      EmailConfirmed = u.EmailConfirmed,
      RoleName = roleName,
      MaxShopNum = u.MaxShopNum,
      AddedShopsExpiryDate = u.AddedShopsExpiryDate,
      LoginTime = u.LoginTime,
      IsBlocked = u.IsBlocked,
      ViolationsCount = u.ViolationsCount,
      //UsersCount = users.Count
    }).ToList();//.GetRange(index, pageSize);
  }

    public async Task<int> GetSearchResultCountAsync(string roleName,string emailOrPhoneNumber, CancellationToken ct=default)
    {
      return await unitOfWork.UsersRepository.GetSearchResultCountAsync(roleName,emailOrPhoneNumber,ct);
    }
    public async Task<UserDTO?> GetByIdAsync(string? id)
    {
     var user = await userManager.FindByIdAsync(id!);
     if (user == null)
       return null;
            Console.WriteLine("-Count\n\n"
            + user.Shops.Count!);

     var roles = await userManager.GetRolesAsync(user);
     return new UserDTO
     {
      FirstName = user.FirstName,
      LastName = user.LastName,
      PhoneNumber = user.PhoneNumber!,
      Email = user.Email!,
      RoleName = roles.First(),
      MaxShopNum = user.MaxShopNum,
      LoginTime = user.LoginTime
     };
  }

  public async Task<bool> CheckEmailExistsAsync(string email)
  {
    return await unitOfWork.UsersRepository.IsExistedAsync(email);
  }

  public async Task<bool> CheckEmailConfirmedAsync(string email)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
      return false;
    var result = await userManager.IsEmailConfirmedAsync(user);
    return result;
  }

  public async Task<UserLoginDTO?> GetLogInAsync(string email, string Password)
  {
    var result = await signInManager.PasswordSignInAsync(email, Password, false, false);
    if (result.Succeeded)
    {
      var user = await userManager.FindByEmailAsync(email);
      if (user != null)
      {      
        var roles = await userManager.GetRolesAsync(user);
        user.LoginTime = DateTime.Now;
     if (user.ViolationsCount != 0 && Convert.ToDateTime(user.BanExpiryDate).AddYears(1).Year <= DateTime.Now.Year)
        {
          user.ViolationsCount = 0;
        }

                      if (user.BanExpiryDate.ToString() != string.Empty)
      {
        if (Convert.ToDateTime(user.BanExpiryDate) <= DateTime.Now)
          user.IsBlocked = true;
        else
          user.IsBlocked = false;
      }
        await userManager.UpdateAsync(user);
   var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!)
              };

              await signInManager.SignInWithClaimsAsync(user, false, claims);
        

/*        var principal = await signInManager.CreateUserPrincipalAsync(user);
        ((ClaimsIdentity)principal.Identity!).AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));*/
Console.WriteLine("\n\n"+"-----------"+user.PhoneNumber+"\n\n");
        return new UserLoginDTO()
        {
          Email = user.Email!,
          IsBlocked = user.IsBlocked,
          EmailConfirmed = user.EmailConfirmed,
          ViolationsCount = user.ViolationsCount,
          BanExpiryDate = user.BanExpiryDate,
        };
      }
    }
    return null;
  }

  public async Task<UserLoginDTO?> GetLogInAsync(string email)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user != null)
    {
      await signInManager.SignInAsync(user, false);
      var roles = await userManager.GetRolesAsync(user);
      user.LoginTime = DateTime.Now;
      await userManager.UpdateAsync(user);
      var principal = await signInManager.CreateUserPrincipalAsync(user);
      ((ClaimsIdentity)principal.Identity!).AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!));
      return new UserLoginDTO()
      {
        Email = user.Email!,
        IsBlocked = user.IsBlocked,
        EmailConfirmed = user.EmailConfirmed,
        ViolationsCount = user.ViolationsCount,
        BanExpiryDate = user.BanExpiryDate,
      };
    }
    return null;
  }

  public ChallengeResult GetExternalLogin(string provider, string redirectUrl)
  {
    var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
    return new ChallengeResult(provider, properties);
  }

  public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
  {
    return await signInManager.GetExternalAuthenticationSchemesAsync();
  }

  public async Task<UserLoginDTO?> GetExternalLoginCallback()
  {
    //Get login info
    var info = await signInManager.GetExternalLoginInfoAsync();
    if (info == null)
    {
      return null;
    }

    var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
    if (signInResult.Succeeded)
    {
      var user = await userManager.FindByLoginAsync(
          info.LoginProvider,
          info.ProviderKey);
      if (user == null)
      {
        return null;
      }
      /*        var claims = new List<Claim>
              {
                  new Claim("AuthProvider", info.LoginProvider),
                  new Claim("IsExternal", "true")
              };

              await signInManager.SignInWithClaimsAsync(user, false, claims);
      */

      await signInManager.SignInWithClaimsAsync(user, false, new List<Claim> { new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!) });
      user.LoginTime = DateTime.Now;
      await userManager.UpdateAsync(user);

      return new UserLoginDTO()
      {
        Email = user.Email!,
        IsBlocked = user.IsBlocked,
        EmailConfirmed = user.EmailConfirmed,
        ViolationsCount = user.ViolationsCount,
        BanExpiryDate = user.BanExpiryDate,
      };
    }


    string fullName = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "Google User";
    string firstName = fullName.Substring(0, fullName.IndexOf(" "));
    string lastName = fullName.Substring(fullName.IndexOf(" ") + 1);
    string? email = info.Principal.FindFirstValue(ClaimTypes.Email);

    if (!string.IsNullOrEmpty(email))
    {
      var user = await userManager.FindByEmailAsync(email);

      Console.WriteLine(
        email + "-Email\n\n"
+ info.Principal.FindFirstValue(ClaimTypes.GivenName) + "-GivenName\n\n");

      if (user == null)
      {
        user = new User()
        {
          FirstName = firstName,
          LastName = lastName,
          UserName = email,
          Email = email,
          PhoneNumber = string.Empty,
          MaxShopNum = 2,
          EmailConfirmed = true,
          IsExternallyLoggedIn = true,
          LoginTime = DateTime.Now
        };

        await userManager.CreateAsync(user);
        await userManager.AddToRoleAsync(user, "User");
        await userManager.AddLoginAsync(user, info);
      }

      await signInManager.SignInWithClaimsAsync(user, false, new List<Claim> { new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!) });


      Console.WriteLine("\n\new" + user.PhoneNumber + "\n\n");

      return new UserLoginDTO()
      {
        Email = user.Email!,
        IsBlocked = user.IsBlocked,
        EmailConfirmed = user.EmailConfirmed,
        ViolationsCount = user.ViolationsCount,
        BanExpiryDate = user.BanExpiryDate
      };
    }

    return null;
  }


  public async Task GetLogOutAsync()
  {
    await signInManager.SignOutAsync();
  }

  public async Task<bool> AddAsync(UserRegisterDTO userDTO)
  {
    var user = new User()
    {
      FirstName = userDTO.FirstName.Trim(),
      LastName = userDTO.LastName.Trim(),
      UserName = userDTO.Email.Trim(),
      Email = userDTO.Email.Trim(),
      PhoneNumber = userDTO.PhoneNumber.Trim(),
      MaxShopNum = 2,
      LoginTime = DateTime.Now,
    };
    var result = await userManager.CreateAsync(user, userDTO.Password!);
    if (result.Succeeded)
    {
      await userManager.AddToRoleAsync(user, "User");
      return true;
    }

    return false;
  }

  public async Task<bool> UpdateAsync(UserUpdateDTO userDTO)
  {
    var user = await userManager.FindByIdAsync(userDTO.Id);
    if (user == null)
      return false;
    user.FirstName = userDTO.FirstName.Trim();
    user.LastName = userDTO.LastName.Trim();
    user.UserName = userDTO.Email.Trim();
    user.PhoneNumber = userDTO.PhoneNumber.Trim();
    user.Email = userDTO.Email.Trim();

    var result = await userManager.UpdateAsync(user);
    return result != null;
  }

  public async Task<string> GenerateConfirmationTokenAsync(string email)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
      return string.Empty;
var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
    return token;
  }



  public async Task<bool> EditEmailConfirmedAsync(string email, string token)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
      return false;
    //user.EmailConfirmed
    var confirmEmailResult = await userManager.ConfirmEmailAsync(user, token);
    return confirmEmailResult.Succeeded;
  }

  public async Task<bool> EditIsBlockedAsync(string id, bool isBlocked)
  {
    var user = await userManager.FindByIdAsync(id);
    if (user == null)
      return false;
    user.IsBlocked = isBlocked;
    var updateIsBlockedResult = await userManager.UpdateAsync(user);
    return updateIsBlockedResult.Succeeded;
  }

  public async Task<bool> EditRoleAsync(string id, string role)
  {
    var user = await userManager.FindByIdAsync(id);
    if (user == null)
      return false;
    var roles = await userManager.GetRolesAsync(user);
    var OldRemovedRole = await userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault()!);
    if (OldRemovedRole.Succeeded)
    {
      await userManager.AddToRoleAsync(user, role.Trim());
      return true;
    }
    return false;
  }


  public async Task<bool> VerifyFieldAsync(string value, string type)
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    for (int index = 0; index < users.Count; index++)
    {
      if (type == "Email" && users[index].Email == value.Trim()
      || type == "PhoneNumber" && users[index].PhoneNumber == value.Trim())
        return false;
    }
    return true;
  }

  public async Task<bool> VerifyEditFieldAsync(string value, string type, string? id)
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    var user = await userManager.FindByIdAsync(id!);
    if (user != null)
    {
      for (int index = 0; index < users.Count; ++index)
      {
        if (type == "Email" && user.Email != value && users[index].Email == value.Trim()
        || type == "PhoneNumber" && user.PhoneNumber != value && users[index].PhoneNumber == value.Trim())
          return false;
      }
    }
    return true;
  }

  public async Task<bool> DeleteAsync(string id)
  {
    var user = await userManager.FindByIdAsync(id);
    if (user == null)
      return false;
    var result = await userManager.DeleteAsync(user);
    return result != null;
  }

  /*  public async Task<string?> GetIdByNameAsync(string name)
    {
      var user = await userManager.FindByNameAsync(name);
      return user!.Id;
    }*/



  public async Task<bool> CheckLoginTypeAsync(string email)
  {
    var user = await userManager.Users.Select(u => new { u.IsExternallyLoggedIn, u.Email })
    .FirstOrDefaultAsync(u => u.Email == email);
    if (user == null)
    {
      return false;
    }
    return user!.IsExternallyLoggedIn == true;
  }


    public async Task<string> GeneratePasswordResetTokenAsync(string email)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
      return string.Empty;
var token = await userManager.GeneratePasswordResetTokenAsync(user);
    return token;
  }
  public async Task<bool> ResetPasswordAsync(string email, string token,string mewPassword)
  {
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
      return false;
    var result = await userManager.ResetPasswordAsync(user,token,mewPassword);

    if (result.Succeeded)
    {
      return true;
    }
    return false;
  }

/*  public async Task<bool> CheckViolationsCountAsync()
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    foreach (var user in users)
    {
      if (user.BanExpiryDate.ToString() != string.Empty)
      {
        if (Convert.ToDateTime(user.BanExpiryDate) <= DateTime.Now)
          await EditIsBlockedAsync(user.Email!, true);
        else
          await EditIsBlockedAsync(user.Email!, false);
      }
    }
    return true;
  }*/


/*  public async Task<bool> ResetViolationsCountAsync()
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    foreach (var user in users)
    {
      if (user.ViolationsCount != 0)
      {
        if (Convert.ToDateTime(user.BanExpiryDate).AddYears(1).Year <= DateTime.Now.Year)
        {
          user.ViolationsCount = 0;
          await userManager.UpdateAsync(user);
        }
      }
    }
    return true;
  }*/

  public async Task<bool> DeleteUnActiveUsersAsync()
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    foreach (var user in users)
    {
      if (user.ViolationsCount == 0)
      {
        if (Convert.ToDateTime(user.LoginTime).AddYears(1) <= DateTime.Now)
        {
          await userManager.DeleteAsync(user);
        }
      }
    }
    return true;
  }

  public async Task<bool> EditAddingShopsAsync(string id, int shopsCount, int period)
  {
    var user = await userManager.FindByIdAsync(id);
    if (user == null)
      return false;
    user.MaxShopNum = shopsCount;
    if (period != 0)
    {
      user.AddedShopsExpiryDate = DateTime.Now.AddMonths(period);
    }
    var result = await userManager.UpdateAsync(user);
    return result != null;
  }

  public async Task<bool> CheckAddingShopsPeriodAsync()
  {
    var users = await userManager.GetUsersInRoleAsync("User");
    foreach (var user in users)
    {
      if (user.AddedShopsExpiryDate.ToString() != string.Empty && user.AddedShopsExpiryDate <= DateTime.Now)
        await EditAddingShopsAsync(user.Id, 2, 0);
    }
    return true;
  }

/*    public async Task<bool> RemoveAllInactive()
    {
         var users=unitOfWork.UsersRepository.GetAllInactive();
        if(users==null)
        {
           return false;
        }
        unitOfWork.UsersRepository.RemoveRange(users);

        return await  unitOfWork.SaveChangesAsync() != 0;
    }*/

}
