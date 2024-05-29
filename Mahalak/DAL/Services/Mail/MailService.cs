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

    public async Task<bool> Send(Mail mail)
    {
        try
        {
            using (MimeMessage emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(mailSettings.SenderName, mailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(mail.UserName,mail.UserEmail);
                emailMessage.To.Add(emailTo);

                emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                emailMessage.Subject = mail.EmailSubject;

                string filePath = Directory.GetCurrentDirectory() + "\\PL\\Templates\\Hello.html";
                string emailTemplateText = File.ReadAllText(filePath);

                emailTemplateText = string.Format(emailTemplateText, mail.UserName,mail.UserPassword, DateTime.Today.Date.ToShortDateString());

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = emailTemplateText;
                emailBodyBuilder.TextBody = mail.EmailBody;

                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
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


