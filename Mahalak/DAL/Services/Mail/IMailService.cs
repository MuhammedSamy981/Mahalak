namespace Mahalak;

public interface IMailService
{
   Task<bool> Send(Mail mail);
}