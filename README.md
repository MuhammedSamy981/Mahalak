# Mahalak

**Mahalak** is an ASP.NET Core 8 MVC web application for creating and managing virtual shops. The platform allows users to register and authenticate, create shops, manage products, receive ratings, and browse shops and products. It also includes administrative management features for users, shops, categories, locations, products, and customer comments.

## Features

### User & Authentication
- User registration and profile management.
- Login and logout.
- Email confirmation.
- Password reset and new-password workflow.
- Google external authentication.
- Account blocking/unblocking.
- User and administrator management.
- Role-based administration.
- Shop creation limits and shop-period management.

### Virtual Shops
- Create, edit, view, and delete shops.
- Shop categories.
- Country, city, and area management.
- Shop approval and rejection by administrators.
- Featured/distinctive shop functionality with an expiry period.
- Shop search and filtering.
- Paginated shop listings.
- Shop details with products and ratings.

### Product Management
- Create, edit, and delete products.
- Product categories and conditions.
- Multiple product images.
- Product validation and image validation.
- Product approval and rejection.
- Product filtering and pagination.
- Product management per shop.

### Ratings & Comments
- Customers can submit ratings and comments for shops.
- Administrators can approve or remove comments.
- Rating summaries and star-rating UI.

### Email & Media
- SMTP email sending through MailKit.
- Gmail API integration for sending emails.
- Cloudinary integration for product image uploads and deletion.
- HTML email templates.

### Other
- IP-based location lookup through IP-API.
- Background service support.
- ASP.NET Core session management.
- Forwarded-header configuration for deployment behind a proxy.
- Reusable pagination and star-rating ViewComponents.

## Tech Stack

- **Framework:** ASP.NET Core MVC, .NET 8
- **Data access:** Entity Framework Core (SQL Server)
- **Auth:** ASP.NET Core Identity + Google OAuth
- **Email:** NETCore.MailKit, Google Gmail API
- **File/image storage:** Cloudinary (CloudinaryDotNet)
- **Frontend:** Razor views, Bootstrap, jQuery, jQuery Validation, Font Awesome

## Architecture

The project follows a layered architecture:

```
Mahalak/
├── DAL/            # Data Access Layer
│   ├── Models/          # EF Core entities (User, Shop, Product, Rating, ...)
│   ├── Context/         # EF Core DbContext
│   ├── Configurations/  # Entity type configurations
│   ├── Migrartions/     # EF Core migrations
│   ├── Repositories/    # Generic + entity-specific repositories
│   ├── UnitOfWork/      # Unit of work pattern
│   ├── Seeder/          # Database seeding (roles, admin user, lookup data)
│   └── Services/        # Mail, Gmail API, Cloud storage, IP lookup, background service
│
├── BLL/            # Business Logic Layer
│   ├── DTOs/             # Data transfer objects per entity
│   ├── Managers/         # Business logic / orchestration per entity
│   ├── Validators/       # Custom validation logic
│   └── ValidationAttribute/
│
├── PL/              # Presentation Layer
│   ├── Controllers/      # MVC controllers
│   ├── Models/           # View models per entity
│   ├── ViewComponents/   # Reusable view components
│   └── Templates/        # Email templates
│
├── Views/           # Razor views (.cshtml), organized by controller
├── wwwroot/         # Static assets (css, js, images, client-side libraries)
├── Properties/      # launchSettings.json
├── Program.cs       # App startup/configuration
├── appsettings.json # Configuration (connection strings, secrets, mail, OAuth)
└── Mahalak.csproj
```

Each domain entity (User, Shop, Product, Rating, PCategory, PCondition, SCategory, SCountry, SCity, SArea, ProductImage) generally has a matching Repository, Manager, DTO, View Model, and Controller, keeping data access, business logic, and presentation concerns separated.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or Azure SQL / any SQL Server–compatible instance)
- A Cloudinary account (for image uploads)
- A Google Cloud project with OAuth 2.0 credentials (for Google sign-in / Gmail API)
- An SMTP-capable email account (e.g. Gmail with an app password) for outgoing mail

## Configuration

Configure the following in `appsettings.json` (or better, in `dotnet user-secrets` / environment variables for local development):

```json
{
  "ConnectionStrings": {
    "Mahalak_CS": "Server=YOUR_SERVER;Database=Mahalak;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  },
  "Authentication": {
    "Google": {
      "ClientId": "YOUR_GOOGLE_CLIENT_ID",
      "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
    }
  },
  "MailSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Mahalak",
    "SenderEmail": "YOUR_EMAIL",
    "UserName": "YOUR_EMAIL",
    "Password": "YOUR_APP_PASSWORD"
  },
  "Gmail": {
    "ClientId": "YOUR_GMAIL_CLIENT_ID",
    "ClientSecret": "YOUR_GMAIL_CLIENT_SECRET",
    "RefreshToken": "YOUR_GMAIL_REFRESH_TOKEN",
    "SenderEmail": "YOUR_EMAIL",
    "RedirectUri": "https://localhost:YOUR_PORT/signin-google"
  },
  "Cloudinary": {
    "Cloud": "YOUR_CLOUD_ID",
    "ApiKey": "YOUR_API_KEY",
    "ApiSecret": "YOUR_API_SECRET"
  }
}
```
## Getting Started

1. **Clone/extract the project** and open `Mahalak.sln` (or the `Mahalak` folder) in your IDE of choice (Visual Studio, Rider, or VS Code).

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure secrets** as described above (connection string, Google OAuth, mail settings, Cloudinary).

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```
   (Requires the `dotnet-ef` tool: `dotnet tool install --global dotnet-ef` if not already installed.)

5. **Run the application**
   ```bash
   dotnet run
   ```
   Or press F5 in Visual Studio. On first run, the seeder (`MahalakDbSeeder`) will populate default roles/data.

6. **Browse the app** at the URL shown in the console (see `Properties/launchSettings.json` for configured ports, e.g. `http://localhost:5052`).

## Project Structure Notes

- Some files include stray backup copies (e.g. `*.cshtml#old`, `*#unused`, `Views/Product/Create.cshtml#okd`) left over from development. These are not used by the build and can be cleaned up or removed.