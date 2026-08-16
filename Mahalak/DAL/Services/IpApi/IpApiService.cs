namespace Mahalak;
public class IpApiService : IIpApiService
{
    private readonly HttpClient httpClient;
    public IpApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    private const string BASE_URL = "http://ip-api.com";
    public async Task<IpApiResponse?> Get(string? ipAddress, CancellationToken ct)
    {
        var ipAddressWithoutPort = ipAddress?.Split(':')[0];
        var route = $"{BASE_URL}/json/{ipAddressWithoutPort}";
        var response = await httpClient.GetFromJsonAsync<IpApiResponse>(route, ct);
        return response;
    }
}