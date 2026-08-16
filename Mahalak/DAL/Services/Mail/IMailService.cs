namespace Mahalak;

public interface IMailService
{
  Task<bool> SendAsync(Message message);
}