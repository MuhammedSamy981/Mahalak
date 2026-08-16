using System.Threading.Tasks;

namespace Mahalak;

public interface IGmailAPIService
{
  Task<bool> SendAsync(Message message);
  Task<bool> CheckTokenExpiresInAsync();
}
