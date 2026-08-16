using Mahalak;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(30); // ← keep session alive longer
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax; // ← important for OAuth redirects
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddSingleton<IGmailAPIService, GmailAPIService>();

builder.Services.AddScoped<ICloudStorageService, CloudStorageService>();


builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
  options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
  options.KnownNetworks.Clear();
  options.KnownProxies.Clear();
});

builder.Services.AddHttpClient<IIpApiService, IpApiService>();


builder.Services.AddHostedService<MyBackgroundService>();

#region Database
string? connection = builder.Configuration.GetConnectionString("Mahalak_CS");
builder.Services.AddDbContext<MahalakDbContext>(
    i => i.UseSqlServer(connection));
#endregion

#region Identity

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.SignIn.RequireConfirmedEmail = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;

        options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
    }
    )
    .AddEntityFrameworkStores<MahalakDbContext>()
    .AddDefaultTokenProviders();
#endregion



#region Repositories
builder.Services.AddScoped<IUsersRepository,UsersRepository>();
builder.Services.AddScoped<IShopsRepository,ShopsRepository>();
builder.Services.AddScoped<ISCategoriesRepository,SCategoriesRepository>();
builder.Services.AddScoped<ISCountriesRepository,SCountriesRepository>();
builder.Services.AddScoped<ISCitiesRepository,SCitiesRepository>();
builder.Services.AddScoped<ISAreasRepository,SAreasRepository>();
builder.Services.AddScoped<IRatingsRepository,RatingsRepository>();
builder.Services.AddScoped<IProductsRepository,ProductsRepository>();
builder.Services.AddScoped<IPCategoriesRepository,PCategoriesRepository>();
builder.Services.AddScoped<IPConditionsRepository,PConditionsRepository>();
builder.Services.AddScoped<IProductImagesRepository,ProductImagesRepository>();
#endregion

#region UnitOfWork
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
#endregion 

#region Managers
builder.Services.AddScoped<IUsersManager,UsersManager>();
builder.Services.AddScoped<IMailManager,MailManager>();
builder.Services.AddScoped<IShopsManager,ShopsManager>();
builder.Services.AddScoped<ISCategoriesManager,SCategoriesManager>();
builder.Services.AddScoped<ISCountriesManager,SCountriesManager>();
builder.Services.AddScoped<ISCitiesManager,SCitiesManager>();
builder.Services.AddScoped<ISAreasManager,SAreasManager>();
builder.Services.AddScoped<IRatingsManager,RatingsManager>();
builder.Services.AddScoped<IProductsManager,ProductsManager>();
builder.Services.AddScoped<IPCategoriesManager,PCategoriesManager>();
builder.Services.AddScoped<IPConditionsManager,PConditionsManager>();
builder.Services.AddScoped<IProductImagesManager,ProductImagesManager>();
#endregion

builder.Services.AddAuthentication()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcoreProductsRepositoryhsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseForwardedHeaders();

app.MapControllers(); // ← required for [HttpGet("signin-google")] to work
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await MahalakDbSeeder.SeedDataAsync(userManager,roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
#endregion

//app.Run();

await app.RunAsync();

