namespace Mahalak;

public interface IIpApiService
{
  Task<IpApiResponse?> Get(string? ipAddress, CancellationToken ct);
}
