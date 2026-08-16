
using Microsoft.AspNetCore.Identity;


namespace Mahalak;
public class MailManager : IMailManager
{ 
    private readonly UserManager<User> userManager;
    private readonly IUnitOfWork unitOfWork;
    private readonly IConfiguration config;


    public MailManager(UserManager<User> userManager, IUnitOfWork unitOfWork,IConfiguration config)
    {
      this.userManager = userManager;
      this.unitOfWork = unitOfWork;
      this.config = config;
    }

  public async Task<bool> SendResetPasswordLinkAsync(string userEmail,string resetPasswordLink)
  {
    var user = await userManager.FindByEmailAsync(userEmail);
    if (user == null)
      return false;

      string domain="http://mahalak.runasp.net";;

    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
      domain="http://localhost:5052";
    }

    var token = await userManager.GeneratePasswordResetTokenAsync(user);
    var url = domain+"/user/createNewPassword" +
                      $"?email={user.Email}" +
                      $"&token={token}";
    Message message = new Message
    {
      RecipientName = user.FirstName+" "+user.LastName,
      RecipientEmail = user.Email,
      Subject = "أعادة تعببن كلمة المرور",
      Body = $"<a style=\"text-decoration: none; color: brown;\" href=\"{resetPasswordLink}\">أضغط هنا</a>"
    };

    if (await unitOfWork.GmailAPIService.CheckTokenExpiresInAsync())
    {
      await SendOauth2LinkAsync();
      return await unitOfWork.MailService.SendAsync(message);
    }    
    if (!await unitOfWork.GmailAPIService.SendAsync(message))
    {
      return await unitOfWork.MailService.SendAsync(message);
    }

      return true;
   
  }

  public async Task<bool> SendVerificationLinkAsync(string userEmail,string confirmationLink)
  {
    var user = await userManager.FindByEmailAsync(userEmail.Trim());
    if (user == null)
      return false;

      string domain="http://mahalak.runasp.net";
    if (WebApplication.CreateBuilder().Environment.IsDevelopment())
    {
       domain="http://localhost:5052";
    }

    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

    var url = domain+"/user/activeAccount" +
                      $"?email={user.Email}" +
                      $"&token={token}";

    Message message = new Message()
    {
      RecipientName = user.FirstName+" "+user.LastName,
      RecipientEmail = user.Email,
      Subject = "تفعيل الحساب",
      Body = $"<a style=\"text-decoration: none; color: brown;\" href=\"{confirmationLink}\">أضغط هنا لتفعيل حسابك</a>"
    };

    if (await unitOfWork.GmailAPIService.CheckTokenExpiresInAsync())
    {
      await SendOauth2LinkAsync();
      return await unitOfWork.MailService.SendAsync(message);
    }  
    
    if (!await unitOfWork.GmailAPIService.SendAsync(message))
    {
      //Console.WriteLine("\n\n" + "Failed sent" + "\n\n");
      return await unitOfWork.MailService.SendAsync(message);
    }
      return true;
  }

  public async Task SendOauth2LinkAsync()
  {
      var clientId = config["Gmail:ClientId"];
      var redirectUri = config["Gmail:RedirectUri"];
      var scope = "https://www.googleapis.com/auth/gmail.send";

      var url = "https://accounts.google.com/o/oauth2/v2/auth" +
                      $"?client_id={clientId}" +
                      $"&redirect_uri={Uri.EscapeDataString(redirectUri!)}" +
                      $"&response_type=code" +
                      $"&scope={Uri.EscapeDataString(scope)}" +
                      $"&access_type=offline" +   // ← required for refresh token
                      $"&prompt=consent";         // ← forces refresh token every login

      Message message = new Message{
                      RecipientName = "Me",
                      RecipientEmail = "mohamed981226@gmail.com",
                      Subject = "refresh token is expired",
                      Body = $"<a style=\"text-decoration: none; color: brown;\" href=\"{url}\">أضغط هنا</a>"
                      };

      await unitOfWork.MailService.SendAsync(message);

  }
}
