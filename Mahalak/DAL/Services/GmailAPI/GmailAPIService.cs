using Microsoft.Extensions.Options;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;


namespace Mahalak;

public class GmailAPIService : IGmailAPIService
{
 private readonly IConfiguration _config;

  public GmailAPIService(IConfiguration config)
    {
        _config = config;
    }


    public async Task<bool> SendAsync(Message message)
    {
        var response  = await GetTokenAsync();
                            if(response==null){ return false;}
        var senderEmail  = _config["Gmail:SenderEmail"];

      string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\templates\\mail.html";
      string format = File.ReadAllText(filePath);
      string recipientName = message.RecipientName!;
      string body = message.Body!;

      string dateTime = DateTime.Today.Date.ToString("yyyy/MM/dd");
      string htmlBody = string.Format(format, recipientName, body, dateTime);

      
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress("Mahalak", senderEmail));
        mimeMessage.To.Add(new MailboxAddress(message.RecipientName, message.RecipientEmail));
        mimeMessage.Subject = message.Subject;
        //mimeMessage.Body = new TextPart("html") { Text = "body" };
        mimeMessage.Body = new BodyBuilder()
        {
         HtmlBody = htmlBody,
         TextBody = message.Body
        }.ToMessageBody();


        // Convert to raw Base64URL format required by Gmail API
        using var stream = new MemoryStream();
        await mimeMessage.WriteToAsync(stream);
        var rawMessage = Convert.ToBase64String(stream.ToArray())
            .Replace('+', '-')
            .Replace('/', '_')
            .Replace("=", "");

        using var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", response.AccessToken);

        var payload = JsonSerializer.Serialize(new { raw = rawMessage });
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        var result = await http.PostAsync(
            "https://gmail.googleapis.com/gmail/v1/users/me/messages/send", content);

        if (!result.IsSuccessStatusCode)
            throw new Exception($"Gmail send failed: {await result.Content.ReadAsStringAsync()}");
            
            return result.IsSuccessStatusCode;
    }

 public async Task<bool> CheckTokenExpiresInAsync()
    {
        var response  = await GetTokenAsync();
                    if(response==null){ return false;}
        return DateTime.UtcNow >= DateTime.UtcNow.AddSeconds(response.ExpiresIn).AddMinutes(-1);
        
    }

      private async Task<TokenResponse> GetTokenAsync()
    {
        var clientId     = _config["Gmail:ClientId"];
        var clientSecret = _config["Gmail:ClientSecret"];
        var refreshToken = _config["Gmail:RefreshToken"];

        using var http = new HttpClient();
        var response = await http.PostAsync("https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"]     = clientId!,
                ["client_secret"] = clientSecret!,
                ["refresh_token"] = refreshToken!,
                ["grant_type"]    = "refresh_token"
            }));

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        //return json.GetProperty("access_token").GetString()!;
                return System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(json)!;

    }

}


public record TokenResponse(
    [property: JsonPropertyName("access_token")]  string AccessToken,
    [property: JsonPropertyName("refresh_token")] string? RefreshToken,
    [property: JsonPropertyName("expires_in")]    int ExpiresIn,
    [property: JsonPropertyName("token_type")]    string TokenType
);
