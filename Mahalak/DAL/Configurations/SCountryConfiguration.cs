using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class SCountryConfiguration : IEntityTypeConfiguration<SCountry>
{
    public void Configure(EntityTypeBuilder<SCountry> builder)
    {
        var countries=new List<SCountry>
        {
           new SCountry{ID=1,Name="مصر"}
        };
        builder.HasData(countries);
    }
}
