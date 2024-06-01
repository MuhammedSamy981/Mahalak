using System.Reflection;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AnalysisServices.Core;
namespace Mahalak;
public class MahalakContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<SCategory> SCategories { get; set; }
    public DbSet<SCountry> SCountries { get; set; }
    public DbSet<SCity> SCities { get; set; }
    public DbSet<SArea> SAreas { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PCategory> PCategories { get; set; }
    public DbSet<PCondition> PConditions { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public MahalakContext(DbContextOptions options) : base(options)
    {
    

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<SCountry>()
        .HasMany(s=>s.Shops).WithOne(c=>c.Country).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SCity>()
        .HasMany(s=>s.Shops).WithOne(c=>c.City).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<PCategory>()
        .HasMany(p=>p.Products).WithOne(s=>s.Category).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
        .HasMany(r=>r.Ratings).WithOne(u=>u.User).OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}
