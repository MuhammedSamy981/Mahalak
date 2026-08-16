using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class SCategoryConfiguration : IEntityTypeConfiguration<SCategory>
{
    public void Configure(EntityTypeBuilder<SCategory> builder)
    {
        var categories=new List<SCategory>
        {
           new SCategory{Id=1,Name="أجهزة كهربائية"},
           new SCategory{Id=2,Name="ملابس"},
           new SCategory{Id=3,Name="عطارة"},
           new SCategory{Id=4,Name="حيوانات أليفة"},
           new SCategory{Id=5,Name="موبايلات و تابلت و إكسسواراتهما"},
           new SCategory{Id=6,Name="كمبيوتر و إكسسواراته"},
           new SCategory{Id=7,Name="شنط و أحذية"},
           new SCategory{Id=8,Name="أدوات مطبخ"},
           new SCategory{Id=9,Name="العاب أطفال"},
           new SCategory{Id=10,Name="أدوات مدرسية"},//مكتبة
           new SCategory{Id=11,Name="كتب"},//مكتبة
           new SCategory{Id=12,Name="أثاث و ديكور"},
           new SCategory{Id=13,Name="أقمشة و مفروشات"},
           new SCategory{Id=14,Name="سجاجيد و موكتات"},
           new SCategory{Id=15,Name="عطور"},
           new SCategory{Id=16,Name="حرف يدوية"},
           new SCategory{Id=17,Name="مستلزمات رياضية"},
           new SCategory{Id=18,Name="مستلزمات أطفال رضع"},
           new SCategory{Id=19,Name="بقالة و مواد غذائية"},
           new SCategory{Id=20,Name="ساعات"},
           new SCategory{Id=21,Name="نظرات"},
           new SCategory{Id=22,Name="كاميرات وأكسسوارتها"},
           new SCategory{Id=23,Name="أدوات تجميل"},
           new SCategory{Id=24,Name="مخبوزات"},
           new SCategory{Id=25,Name="حلويات"},
           new SCategory{Id=26,Name="منظفات"},
           new SCategory{Id=27,Name="دهانات"},
           new SCategory{Id=28,Name="سباكة"},
           new SCategory{Id=29,Name="عربيات وقطع غيار"},
           new SCategory{Id=30,Name="معدات صناعية"},
           new SCategory{Id=31,Name="مسلزمات زراعية"},
           new SCategory{Id=32,Name="أدوات صيد"},
           new SCategory{Id=33,Name="مستلزمات بناء"},
           new SCategory{Id=34,Name="مستلزمات طبية"},
           new SCategory{Id=35,Name="العاب إلكتروية"}
        };
        builder.HasData(categories);
    }
}
