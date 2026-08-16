namespace Mahalak;
public interface IMailManager
{

  Task<bool> SendResetPasswordLinkAsync(string userEmail,string resetPasswordLink);

  Task<bool> SendVerificationLinkAsync(string userEmail,string confirmationLink);
}