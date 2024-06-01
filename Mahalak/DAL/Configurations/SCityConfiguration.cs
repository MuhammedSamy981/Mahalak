using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class SCityConfiguration : IEntityTypeConfiguration<SCity>
{
    public void Configure(EntityTypeBuilder<SCity> builder)
    {
        var cities = new List<SCity>
         {
            new SCity{ID=1,Name="القاهرة",CountryID=1},
            new SCity{ID=2,Name="الجيزة",CountryID=1},
            new SCity{ID=3,Name="الأسكندرية",CountryID=1},
            new SCity{ID=4,Name="الدقهلية",CountryID=1},
            new SCity{ID=5,Name="البحر الأحمر",CountryID=1},
            new SCity{ID=6,Name="البحيرة",CountryID=1},
            new SCity{ID=7,Name="الفيوم",CountryID=1},
            new SCity{ID=8,Name="الغربية",CountryID=1},
            new SCity{ID=9,Name="الإسماعلية",CountryID=1},
            new SCity{ID=10,Name="المنوفية",CountryID=1},
            new SCity{ID=11,Name="المنيا",CountryID=1},
            new SCity{ID=12,Name="القليوبية",CountryID=1},
            new SCity{ID=13,Name="الوادي الجديد",CountryID=1},
            new SCity{ID=14,Name="السويس",CountryID=1},
            new SCity{ID=15,Name="اسوان",CountryID=1},
            new SCity{ID=16,Name="اسيوط",CountryID=1},
            new SCity{ID=17,Name="بني سويف",CountryID=1},
            new SCity{ID=18,Name="بورسعيد",CountryID=1},
            new SCity{ID=19,Name="دمياط",CountryID=1},
            new SCity{ID=20,Name="الشرقية",CountryID=1},
            new SCity{ID=21,Name="جنوب سيناء",CountryID=1},
            new SCity{ID=22,Name="كفر الشيخ",CountryID=1},
            new SCity{ID=23,Name="مطروح",CountryID=1},
            new SCity{ID=24,Name="الأقصر",CountryID=1},
            new SCity{ID=25,Name="قنا",CountryID=1},
            new SCity{ID=26,Name="شمال سيناء",CountryID=1},
            new SCity{ID=27,Name="سوهاج", CountryID=1}
        };
        builder.HasData(cities);
    }
}
