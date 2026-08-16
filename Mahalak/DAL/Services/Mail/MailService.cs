using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Mahalak;

public class MailService : IMailService
{
  private readonly MailSettings mailSettings;

  public MailService(IOptions<MailSettings> mailSettingsOptions)
  {
     mailSettings = mailSettingsOptions.Value;
  }

  public async Task<bool> SendAsync(Message message)
  {
    try
    {
      using (MimeMessage emailMessage = new MimeMessage())
      {
        emailMessage.From.Add(new MailboxAddress( mailSettings.SenderName,  mailSettings.SenderEmail));
        emailMessage.To.Add(new MailboxAddress(message.RecipientName, message.RecipientEmail));
        emailMessage.Subject = message.Subject;

        string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\templates\\mail.html";
        string format = File.ReadAllText(filePath);
        string recipientName = message.RecipientName!;
        string body = message.Body!;

        string dateTime = DateTime.Today.Date.ToString("yyyy/MM/dd");
        string htmlBody = string.Format(format,recipientName,body,dateTime);

        emailMessage.Body = new BodyBuilder()
        {
          HtmlBody = htmlBody,
          TextBody = message.Body
        }.ToMessageBody();
        
        using (SmtpClient mailClient = new SmtpClient())
        {
          await mailClient.ConnectAsync(mailSettings.Server, mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
          await mailClient.AuthenticateAsync(mailSettings.UserName, mailSettings.Password);
          await mailClient.SendAsync(emailMessage);
          await mailClient.DisconnectAsync(true);
        }
      }
      return true;
    }
    catch
    {
      return false;
    }
  }
}


