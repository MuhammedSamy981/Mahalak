using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Mahalak;

public interface IUsersManager
{
  //Task<List<UserDTO>> GetPaginatedAsync(int pageSize, int pageNumber);

  Task<List<UserDTO>> GetPaginatedByRoleAsync(
       int pageNumber, int pageSize, string roleName, CancellationToken ct=default);
       Task<int> GetCountByRoleAsync(string roleName, CancellationToken ct=default);

  Task<List<UserDTO>> GetPaginatedByEmailOrPhoneNumberAsync(
       int pageNumber, int pageSize, string roleName, string emailOrPhoneNumber, CancellationToken ct=default);
       Task<int> GetSearchResultCountAsync(string roleName,string emailOrPhoneNumber, CancellationToken ct=default);

  Task<UserDTO?> GetByIdAsync(string? id);
  
  Task<bool> CheckEmailExistsAsync(string email);

  Task<bool> CheckEmailConfirmedAsync(string email);

  Task<UserLoginDTO?> GetLogInAsync(string email, string Password);

  Task<UserLoginDTO?> GetLogInAsync(string email);

  ChallengeResult GetExternalLogin(string provider, string redirectUrl);

  Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();

  Task<UserLoginDTO?> GetExternalLoginCallback();

  Task GetLogOutAsync();

  Task<bool> AddAsync(UserRegisterDTO userDTO);

  Task<bool> UpdateAsync(UserUpdateDTO userDTO);

  Task<string> GenerateConfirmationTokenAsync(string email);

  Task<bool> EditEmailConfirmedAsync(string email, string token);

  Task<bool> EditRoleAsync(string id, string roleName);

  Task<bool> EditIsBlockedAsync(string id, bool isBlocked);

  Task<bool> VerifyFieldAsync(string value, string type);

  Task<bool> VerifyEditFieldAsync(string value, string type, string? id);

  Task<bool> DeleteAsync(string id);

  Task<bool> CheckLoginTypeAsync(string email);
  
  Task<string> GeneratePasswordResetTokenAsync(string email);

  Task<bool> ResetPasswordAsync(string email, string token,string mewPassword);

  Task<bool> DeleteUnActiveUsersAsync();

 // Task<bool> CheckViolationsCountAsync();

 // Task<bool> ResetViolationsCountAsync();

  Task<bool> EditAddingShopsAsync(string id, int shopsCount, int period);

  Task<bool> CheckAddingShopsPeriodAsync();

//  Task<bool> RemoveAllInactive();

}