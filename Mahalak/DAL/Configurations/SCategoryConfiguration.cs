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
           new SCategory{ID=1,Name="أجهزة كهربائية"},
           new SCategory{ID=2,Name="ملابس"},
           new SCategory{ID=3,Name="عطارة"},
           new SCategory{ID=4,Name="حيوانات أليفة"},
           new SCategory{ID=5,Name="موبايلات و تابلت و إكسسواراتهما"},
           new SCategory{ID=6,Name="كمبيوتر و إكسسواراته"},
           new SCategory{ID=7,Name="شنط و أحذية"},
           new SCategory{ID=8,Name="أدوات مطبخ"},
           new SCategory{ID=9,Name="العاب أطفال"},
           new SCategory{ID=10,Name="مكتبة أدوات مدرسية"},
           new SCategory{ID=11,Name="مكتبة كتب"},
           new SCategory{ID=12,Name="أثاث و ديكور"},
           new SCategory{ID=13,Name="أقمشة و مفروشات"},
           new SCategory{ID=14,Name="سجاجيد و موكتات"},
           new SCategory{ID=15,Name="عطور"},
           new SCategory{ID=16,Name="حرف يدوية"},
           new SCategory{ID=17,Name="مستلزمات رياضية"},
           new SCategory{ID=18,Name="مستلزمات أطفال رضع"},
           new SCategory{ID=19,Name="بقالة و مواد غذائية"},
           new SCategory{ID=20,Name="ساعات"},
           new SCategory{ID=21,Name="نظرات"},
           new SCategory{ID=22,Name="كاميرات وأكسسوارتها"},
           new SCategory{ID=23,Name="أدوات تجميل"},
           new SCategory{ID=24,Name="مخبوزات"},
           new SCategory{ID=25,Name="حلويات"},
           new SCategory{ID=26,Name="منظفات"},
           new SCategory{ID=27,Name="دهانات"},
           new SCategory{ID=28,Name="سباكة"},
           new SCategory{ID=29,Name="عربيات وقطع غيار"},
           new SCategory{ID=30,Name="معدات صناعية"},
           new SCategory{ID=31,Name="مسلزمات زراعية"},
           new SCategory{ID=32,Name="أدوات صيد"},
           new SCategory{ID=33,Name="مستلزمات بناء"},
           new SCategory{ID=34,Name="مستلزمات طبية"},
        };
        builder.HasData(categories);
    }
}
