using Mahalak;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(c=>{
    c.LoginPath="/user/logIn";
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MailService>();

#region Database
string? connection = builder.Configuration.GetConnectionString("Mahalak_CS");
builder.Services.AddDbContext<MahalakContext>(
    i => i.UseSqlServer(connection)
    );
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=ViewForCustumers}/{id?}");

app.Run();
