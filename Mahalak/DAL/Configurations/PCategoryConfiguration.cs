using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class PCategoryConfiguration : IEntityTypeConfiguration<PCategory>
{
    public void Configure(EntityTypeBuilder<PCategory> builder)
    {
        var subCategories = new List<PCategory>
        {
           
           new PCategory{ID=1,Name="ثلاجات و ديب فريزر",SCategoryID=1},
           new PCategory{ID=2,Name="بوتاجازات وأفران ومايكروويف",SCategoryID=1},
           new PCategory{ID=3,Name="غسالات ومجففات",SCategoryID=1},
           new PCategory{ID=4,Name="تكييفات ومراوح",SCategoryID=1},
           new PCategory{ID=5,Name="سخانات",SCategoryID=1},
           new PCategory{ID=6,Name="دفايات",SCategoryID=1},
           new PCategory{ID=7,Name="مكانس كهرباىية",SCategoryID=1},
           new PCategory{ID=8,Name="تلفزيونات و شاشات",SCategoryID=1},
           new PCategory{ID=9,Name="أجهزة كهربائية أخرى",SCategoryID=1},
           new PCategory{ID=10,Name="ملابس رجالى",SCategoryID=2},
           new PCategory{ID=11,Name="ملابس حريمى",SCategoryID=2},
           new PCategory{ID=12,Name="ملابس أطفال",SCategoryID=2},
           new PCategory{ID=13,Name="بهارات و توابل",SCategoryID=3},
           new PCategory{ID=14,Name="أعشاب",SCategoryID=3},
           new PCategory{ID=15,Name="حبوب",SCategoryID=3},
           new PCategory{ID=16,Name="بقوليات جافة",SCategoryID=3},
           new PCategory{ID=17,Name="زيوت",SCategoryID=3},
           new PCategory{ID=18,Name="مشروبات بودر",SCategoryID=3},
           new PCategory{ID=19,Name="بخور",SCategoryID=3},
           new PCategory{ID=20,Name="فطط",SCategoryID=4},
           new PCategory{ID=21,Name="كلاب",SCategoryID=4},
           new PCategory{ID=22,Name="سلاحف",SCategoryID=4},
           new PCategory{ID=23,Name="طيور",SCategoryID=4},
           new PCategory{ID=24,Name="هامستر",SCategoryID=4},
           new PCategory{ID=25,Name="سمك زينة",SCategoryID=4},
           new PCategory{ID=26,Name="موبايلات",SCategoryID=5},
           new PCategory{ID=27,Name="تابلت",SCategoryID=5},
           new PCategory{ID=28,Name="أكسسوارات موبيل وتابلت",SCategoryID=5},
           new PCategory{ID=29,Name="خطوط موبيل",SCategoryID=5},
           new PCategory{ID=30,Name="كمبيوتر",SCategoryID=6},
           new PCategory{ID=31,Name="لاب توب",SCategoryID=6},
           new PCategory{ID=32,Name="أكسسوارات و قطع غيار كمبيوتر",SCategoryID=6},
           new PCategory{ID=33,Name="شنط سفر",SCategoryID=7},
           new PCategory{ID=34,Name="شنط رجالى",SCategoryID=7},
           new PCategory{ID=35,Name="شنط حريمى",SCategoryID=7},
           new PCategory{ID=36,Name="شنط أطفال",SCategoryID=7},
           new PCategory{ID=37,Name="شنط ظهر",SCategoryID=7},
           new PCategory{ID=38,Name="شنط مكتب",SCategoryID=7},
           new PCategory{ID=39,Name="معالق",SCategoryID=8},
           new PCategory{ID=40,Name="شوك",SCategoryID=8},
           new PCategory{ID=41,Name="سكاكين",SCategoryID=8},
           new PCategory{ID=42,Name="أطباق",SCategoryID=8},
           new PCategory{ID=43,Name="كوبيات",SCategoryID=8},
           new PCategory{ID=44,Name="صوانى",SCategoryID=8},
           new PCategory{ID=45,Name="مبشرة و أدوات تقشير",SCategoryID=8},
           new PCategory{ID=46,Name="صفايات",SCategoryID=8},
           new PCategory{ID=47,Name="طاسات و حلل",SCategoryID=8},
           new PCategory{ID=48,Name="أدوات مطبخ أخرى",SCategoryID=8},
           new PCategory{ID=49,Name="العاب ورق",SCategoryID=9},
           new PCategory{ID=50,Name="العاب بلاستيك",SCategoryID=9},
           new PCategory{ID=51,Name="العاب طاولة",SCategoryID=9},
           new PCategory{ID=52,Name="العاب إلكتروية",SCategoryID=9},
           new PCategory{ID=53,Name="كتب مناهج دراسية",SCategoryID=10},
           new PCategory{ID=54,Name="أقلام رصاص و فحم",SCategoryID=10},
           new PCategory{ID=55,Name="أقلام جاف و حبر",SCategoryID=10},
           new PCategory{ID=56,Name="أقلام تلوين",SCategoryID=10},
           new PCategory{ID=57,Name="مساطر",SCategoryID=10},
           new PCategory{ID=58,Name="برايات",SCategoryID=10},
           new PCategory{ID=59,Name="مسّاحات",SCategoryID=10},
           new PCategory{ID=60,Name="أدوات هندسية",SCategoryID=10},
           new PCategory{ID=61,Name="ألالات حاسبة",SCategoryID=10},
           new PCategory{ID=62,Name="أخرى",SCategoryID=10},
           new PCategory{ID=63,Name="كتب دينية",SCategoryID=11},
           new PCategory{ID=64,Name="كتب علمية",SCategoryID=11},
           new PCategory{ID=65,Name="كتب أدبية",SCategoryID=11},
           new PCategory{ID=66,Name="قصص و روايات",SCategoryID=11},
           new PCategory{ID=67,Name="قصص مصورة",SCategoryID=11},
           new PCategory{ID=68,Name="كنب",SCategoryID=12},
           new PCategory{ID=69,Name="سراير",SCategoryID=12},
           new PCategory{ID=70,Name="ترابيزات",SCategoryID=12},
           new PCategory{ID=71,Name="مكاتب",SCategoryID=12},
           new PCategory{ID=72,Name="نجف",SCategoryID=12},
           new PCategory{ID=73,Name="دواليب",SCategoryID=12},
           new PCategory{ID=74,Name="كراسى",SCategoryID=12},
           new PCategory{ID=75,Name="أبواب وشبابيك",SCategoryID=12},
           new PCategory{ID=76,Name="أضاءة",SCategoryID=12},
           new PCategory{ID=77,Name="ساعات حائط",SCategoryID=12},
           new PCategory{ID=78,Name="برواز ولوحات مناظر طبيعية",SCategoryID=12},
           new PCategory{ID=79,Name="فازات ورود",SCategoryID=12},
           new PCategory{ID=80,Name="أخرى",SCategoryID=12},
           new PCategory{ID=81,Name="مراتب و مخدات",SCategoryID=13},
           new PCategory{ID=82,Name="ملايات وبطاطين",SCategoryID=13},
           new PCategory{ID=83,Name="فواط و مناشف",SCategoryID=13},
           new PCategory{ID=84,Name="مفارش كنب وكراسى",SCategoryID=13},
           new PCategory{ID=85,Name="مفارش ترابيزات",SCategoryID=13},
           new PCategory{ID=86,Name="أخرى",SCategoryID=13},
           new PCategory{ID=87,Name="سجاجيد و موكتات",SCategoryID=14},
           new PCategory{ID=88,Name="برفنات رجالى",SCategoryID=15},
           new PCategory{ID=89,Name="برفانات حريمى",SCategoryID=15},
           new PCategory{ID=90,Name="مسك و زيوت عطرية",SCategoryID=15},
           new PCategory{ID=91,Name="أخرى",SCategoryID=15},
           new PCategory{ID=92,Name="أوانى فخارية",SCategoryID=16},
           new PCategory{ID=93,Name="ملابس كروشيه",SCategoryID=16},
           new PCategory{ID=94,Name="أخرى",SCategoryID=16},
           new PCategory{ID=95,Name="كور قدم",SCategoryID=17},
           new PCategory{ID=96,Name="كور طيارة",SCategoryID=17},
           new PCategory{ID=97,Name="كور سلة",SCategoryID=17},
           new PCategory{ID=98,Name="مضارب و كور للتنس",SCategoryID=17},
           new PCategory{ID=99,Name="مضارب و كور و ترابيزات للبينج",SCategoryID=17},
           new PCategory{ID=100,Name="ملابس و معدات غوص و سباحة",SCategoryID=17},
           new PCategory{ID=101,Name="معدات و مستلزمات ركوب الخيل",SCategoryID=17},
           new PCategory{ID=102,Name="مستلزمات وثب و جري",SCategoryID=17},
           new PCategory{ID=103,Name="أخرى",SCategoryID=17},
           new PCategory{ID=104,Name="حفاضات",SCategoryID=18},
           new PCategory{ID=105,Name="بزازات و بيبرونات",SCategoryID=18},
           new PCategory{ID=106,Name="منتجات استحمام وعناية بالبشرة",SCategoryID=18},
           new PCategory{ID=107,Name="ملابس رضع",SCategoryID=18},
           new PCategory{ID=108,Name="سراير أطفال",SCategoryID=18},
           new PCategory{ID=109,Name="أخرى",SCategoryID=18},
           new PCategory{ID=110,Name="منتجات ألبان",SCategoryID=19},
           new PCategory{ID=111,Name="أطعمة معلبة",SCategoryID=19},
           new PCategory{ID=112,Name="سناكس و مقرمشات",SCategoryID=19},
           new PCategory{ID=113,Name="بسكوتات و كيكات",SCategoryID=19},
           new PCategory{ID=114,Name="شكولاتات و حلويات صناعية",SCategoryID=19},
           new PCategory{ID=115,Name="خضار و فواكه محفوظة",SCategoryID=19},
           new PCategory{ID=116,Name="لحوم مجففة ومصنعة",SCategoryID=19},
           new PCategory{ID=117,Name="عصائر ومشروبات معلبة",SCategoryID=19},
           new PCategory{ID=118,Name="سمن و زيوت صناعية",SCategoryID=19},
           new PCategory{ID=119,Name="أخرى",SCategoryID=19},
           new PCategory{ID=120,Name="ساعات يد رجالى",SCategoryID=20},
           new PCategory{ID=121,Name="ساعات يد حريمى",SCategoryID=20},
           new PCategory{ID=122,Name="ساعات يد رقمية",SCategoryID=20},
           new PCategory{ID=123,Name="أخرى",SCategoryID=20},
           new PCategory{ID=124,Name="نظارات طبية رجالى",SCategoryID=21},
           new PCategory{ID=125,Name="نظارات طبية حريمى",SCategoryID=21},
           new PCategory{ID=126,Name="نظارات شمسية رجالى",SCategoryID=21},
           new PCategory{ID=127,Name="نظارات شمسية حريمى",SCategoryID=21},
           new PCategory{ID=128,Name="أخرى",SCategoryID=21},
           new PCategory{ID=129,Name="كاميرات فيلمية",SCategoryID=22},             
           new PCategory{ID=130,Name="كاميرات رقمية",SCategoryID=22},
           new PCategory{ID=131,Name="كاميرات مراقبة",SCategoryID=22},
           new PCategory{ID=132,Name="أخرى",SCategoryID=22},
           new PCategory{ID=133,Name="اقلام شفاه",SCategoryID=23},
           new PCategory{ID=134,Name="طلاء الأظافر",SCategoryID=23},
           new PCategory{ID=135,Name="عدسات لاصقة",SCategoryID=23},
           new PCategory{ID=136,Name="مساحيق التجميل",SCategoryID=23},
           new PCategory{ID=137,Name="منتجات وكريمات عناية بالبشرة",SCategoryID=23},
           new PCategory{ID=138,Name="زيوت وكريمات للشعر",SCategoryID=23},
           new PCategory{ID=139,Name="حنة و صبغات للشعر",SCategoryID=23},
           new PCategory{ID=140,Name="كحل ومسكرة",SCategoryID=23},
           new PCategory{ID=141,Name="مزيلات العرق",SCategoryID=23},
           new PCategory{ID=142,Name="أخرى",SCategoryID=23},
           new PCategory{ID=143,Name="عيش فينو",SCategoryID=24},
           new PCategory{ID=144,Name="عيش سن",SCategoryID=24},
           new PCategory{ID=145,Name="بقسماط و مقرمشات",SCategoryID=24},
           new PCategory{ID=146,Name="قرص ( سادة - عجوة - ملبن )",SCategoryID=24},
           new PCategory{ID=147,Name="أخرى",SCategoryID=24},
           new PCategory{ID=148,Name="تورتات و جاتو",SCategoryID=25},
           new PCategory{ID=149,Name="بقلاوة",SCategoryID=25},
           new PCategory{ID=150,Name="هريسة و بسبوسة",SCategoryID=25},
           new PCategory{ID=151,Name="كنافة",SCategoryID=25},
           new PCategory{ID=152,Name="حجازية",SCategoryID=25},
           new PCategory{ID=153,Name="زلابية و بلح الشام",SCategoryID=25},
           new PCategory{ID=154,Name="حلويات العيد و المواسم",SCategoryID=25},
           new PCategory{ID=155,Name="أخرى",SCategoryID=25},
           new PCategory{ID=156,Name="سوائل و أدوات تنظيف الصحون",SCategoryID=26},
           new PCategory{ID=157,Name="صابون و شامبو و شور جيل",SCategoryID=26},
           new PCategory{ID=158,Name="مساحيق و سوائل تنظيف الملابس",SCategoryID=26},
           new PCategory{ID=159,Name="منظفات للأرضيات و الحمام والمراحيض",SCategoryID=26},
           new PCategory{ID=160,Name="معطرات جو",SCategoryID=26},
           new PCategory{ID=161,Name="معطرات سجاد و أرضيات",SCategoryID=26},
           new PCategory{ID=162,Name="منظفات زجاج",SCategoryID=26},
           new PCategory{ID=163,Name="أخرى",SCategoryID=26},
           new PCategory{ID=164,Name="دهانات للجدران والرفوف",SCategoryID=27},
           new PCategory{ID=165,Name="دهانات للخشب و الشبابيك و الأبواب ",SCategoryID=27},
           new PCategory{ID=166,Name="أخرى",SCategoryID=27},
           new PCategory{ID=167,Name="مواتير مياه",SCategoryID=28},
           new PCategory{ID=168,Name="حنفيات و قطع غيرها",SCategoryID=28},
           new PCategory{ID=169,Name="مواسير و قطع غيارها",SCategoryID=28},
           new PCategory{ID=170,Name="أحواض و بانيو وجاكوزى",SCategoryID=28},
           new PCategory{ID=171,Name="تواليتات ومستلزمتها",SCategoryID=28},
           new PCategory{ID=172,Name="سراميك و بورسلين",SCategoryID=28},
           new PCategory{ID=173,Name="أخرى",SCategoryID=28},
           new PCategory{ID=174,Name="عربيات ملاكى",SCategoryID=29},
           new PCategory{ID=175,Name="عربيات نقل و شاحنات",SCategoryID=29},
           new PCategory{ID=176,Name="وسائل مواصلات",SCategoryID=29},
           new PCategory{ID=177,Name="رافعات و حفارات",SCategoryID=29},
           new PCategory{ID=178,Name="أخرى",SCategoryID=29},
           new PCategory{ID=179,Name="ألات ومعدات مصانع و قطع غيرها",SCategoryID=30},
           new PCategory{ID=180,Name="أخرى",SCategoryID=30},
           new PCategory{ID=181,Name="أسمدة كيماوية",SCategoryID=31},
           new PCategory{ID=182,Name="مبيدات حشرية",SCategoryID=31},
           new PCategory{ID=183,Name="بذور و محاصيل للزراعة",SCategoryID=31},
           new PCategory{ID=184,Name="جرارات",SCategoryID=31},
           new PCategory{ID=185,Name="معدات وأدوات زراعية",SCategoryID=31},
           new PCategory{ID=186,Name="أخرى",SCategoryID=31},
           new PCategory{ID=187,Name="صنارات",SCategoryID=32},
           new PCategory{ID=188,Name="شبكات صيد",SCategoryID=32},
           new PCategory{ID=189,Name="أطعم للصيد",SCategoryID=32},
           new PCategory{ID=190,Name="أخرى",SCategoryID=32},
           new PCategory{ID=191,Name="مستلزمات بناء",SCategoryID=33},
           new PCategory{ID=192,Name="سماعات طبية",SCategoryID=34},
           new PCategory{ID=193,Name="أجهزة قياس ضغط",SCategoryID=34},
           new PCategory{ID=194,Name="أجهزة قياس سكر",SCategoryID=34},
           new PCategory{ID=195,Name="أجهزة أشعة",SCategoryID=34},
           new PCategory{ID=196,Name="أخرى",SCategoryID=34},
        };
        builder.HasData(subCategories);
    }
}
