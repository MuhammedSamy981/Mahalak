using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace Mahalak;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISCountriesManager countriesManager;
    private readonly IIpApiService ipApiService;

    public HomeController(ILogger<HomeController> logger, ISCountriesManager countriesManager, IIpApiService ipApiService)
    {
        _logger = logger;
         this.countriesManager = countriesManager;
        this.ipApiService = ipApiService;
       
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {        
       #region Get current user's country
        var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ??
        HttpContext.Connection.RemoteIpAddress?.ToString();
        var ipApiResponse = await ipApiService.Get(ipAddress, ct);
        #endregion
        int? countryId = await countriesManager.GetIdByNameAsync(ipApiResponse!.country!);

        HttpContext.Session.SetInt32("CountryId", countryId.Value);

        if (countryId != null && countryId != 0)
        {
            return View();
        }
        else
        {
            return NotFound();
        }
    }




}



