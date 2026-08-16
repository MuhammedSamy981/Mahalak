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
            // ── Egypt (CountryId=1) ──
            new SCity{Id=1,Name="القاهرة",CountryId=1},
            new SCity{Id=2,Name="الجيزة",CountryId=1},
            new SCity{Id=3,Name="الأسكندرية",CountryId=1},
            new SCity{Id=4,Name="الدقهلية",CountryId=1},
            new SCity{Id=5,Name="البحر الأحمر",CountryId=1},
            new SCity{Id=6,Name="البحيرة",CountryId=1},
            new SCity{Id=7,Name="الفيوم",CountryId=1},
            new SCity{Id=8,Name="الغربية",CountryId=1},
            new SCity{Id=9,Name="الإسماعلية",CountryId=1},
            new SCity{Id=10,Name="المنوفية",CountryId=1},
            new SCity{Id=11,Name="المنيا",CountryId=1},
            new SCity{Id=12,Name="القليوبية",CountryId=1},
            new SCity{Id=13,Name="الوادي الجديد",CountryId=1},
            new SCity{Id=14,Name="السويس",CountryId=1},
            new SCity{Id=15,Name="اسوان",CountryId=1},
            new SCity{Id=16,Name="اسيوط",CountryId=1},
            new SCity{Id=17,Name="بني سويف",CountryId=1},
            new SCity{Id=18,Name="بورسعيد",CountryId=1},
            new SCity{Id=19,Name="دمياط",CountryId=1},
            new SCity{Id=20,Name="الشرقية",CountryId=1},
            new SCity{Id=21,Name="جنوب سيناء",CountryId=1},
            new SCity{Id=22,Name="كفر الشيخ",CountryId=1},
            new SCity{Id=23,Name="مطروح",CountryId=1},
            new SCity{Id=24,Name="الأقصر",CountryId=1},
            new SCity{Id=25,Name="قنا",CountryId=1},
            new SCity{Id=26,Name="شمال سيناء",CountryId=1},
            new SCity{Id=27,Name="سوهاج", CountryId=1},

            // ── Saudi Arabia (CountryId=2) ──
    new SCity{Id=28, Name="الرياض",        CountryId=2},
    new SCity{Id=29, Name="جدة",           CountryId=2},
    new SCity{Id=30, Name="مكة المكرمة",   CountryId=2},
    new SCity{Id=31, Name="المدينة المنورة",CountryId=2},
    new SCity{Id=32, Name="الدمام",        CountryId=2},
    new SCity{Id=33, Name="الخبر",         CountryId=2},
    new SCity{Id=34, Name="الظهران",       CountryId=2},
    new SCity{Id=35, Name="تبوك",          CountryId=2},
    new SCity{Id=36, Name="أبها",          CountryId=2},
    new SCity{Id=37, Name="نجران",         CountryId=2},
    new SCity{Id=38, Name="جازان",         CountryId=2},
    new SCity{Id=39, Name="حائل",          CountryId=2},
    new SCity{Id=40, Name="الجوف",         CountryId=2},
    new SCity{Id=41, Name="الطائف",        CountryId=2},
    new SCity{Id=42, Name="بريدة",         CountryId=2},
    new SCity{Id=43, Name="القطيف",        CountryId=2},
 
    // ── UAE (CountryId=3) ──
    new SCity{Id=44, Name="أبوظبي",        CountryId=3},
    new SCity{Id=45, Name="دبي",           CountryId=3},
    new SCity{Id=46, Name="الشارقة",       CountryId=3},
    new SCity{Id=47, Name="عجمان",         CountryId=3},
    new SCity{Id=48, Name="رأس الخيمة",    CountryId=3},
    new SCity{Id=49, Name="الفجيرة",       CountryId=3},
    new SCity{Id=50, Name="أم القيوين",    CountryId=3},
 
    // ── Kuwait (CountryId=4) ──
    new SCity{Id=51, Name="مدينة الكويت",  CountryId=4},
    new SCity{Id=52, Name="حولي",          CountryId=4},
    new SCity{Id=53, Name="الفروانية",     CountryId=4},
    new SCity{Id=54, Name="مبارك الكبير",  CountryId=4},
    new SCity{Id=55, Name="الأحمدي",       CountryId=4},
    new SCity{Id=56, Name="الجهراء",       CountryId=4},
 
    // ── Qatar (CountryId=5) ──
    new SCity{Id=57, Name="الدوحة",        CountryId=5},
    new SCity{Id=58, Name="الريان",        CountryId=5},
    new SCity{Id=59, Name="الوكرة",        CountryId=5},
    new SCity{Id=60, Name="أم صلال",       CountryId=5},
    new SCity{Id=61, Name="الشمال",        CountryId=5},
    new SCity{Id=62, Name="الخور",         CountryId=5},
    new SCity{Id=63, Name="الظعاين",       CountryId=5},
 
    // ── Bahrain (CountryId=6) ──
    new SCity{Id=64, Name="المنامة",       CountryId=6},
    new SCity{Id=65, Name="المحرق",        CountryId=6},
    new SCity{Id=66, Name="الرفاع",        CountryId=6},
    new SCity{Id=67, Name="مدينة حمد",     CountryId=6},
    new SCity{Id=68, Name="مدينة عيسى",    CountryId=6},
    new SCity{Id=69, Name="سترة",          CountryId=6},
    new SCity{Id=70, Name="عالي",          CountryId=6},
 
    // ── Oman (CountryId=7) ──
    new SCity{Id=71, Name="مسقط",          CountryId=7},
    new SCity{Id=72, Name="صلالة",         CountryId=7},
    new SCity{Id=73, Name="صحار",          CountryId=7},
    new SCity{Id=74, Name="نزوى",          CountryId=7},
    new SCity{Id=75, Name="السيب",         CountryId=7},
    new SCity{Id=76, Name="صور",           CountryId=7},
    new SCity{Id=77, Name="البريمي",       CountryId=7},
    new SCity{Id=78, Name="عبري",          CountryId=7},
    new SCity{Id=79, Name="إبراء",         CountryId=7},
 
    // ── Jordan (CountryId=8) ──
    new SCity{Id=80, Name="عمان",          CountryId=8},
    new SCity{Id=81, Name="الزرقاء",       CountryId=8},
    new SCity{Id=82, Name="إربد",          CountryId=8},
    new SCity{Id=83, Name="العقبة",        CountryId=8},
    new SCity{Id=84, Name="السلط",         CountryId=8},
    new SCity{Id=85, Name="مادبا",         CountryId=8},
    new SCity{Id=86, Name="الكرك",         CountryId=8},
    new SCity{Id=87, Name="جرش",           CountryId=8},
    new SCity{Id=88, Name="المفرق",        CountryId=8},
    new SCity{Id=89, Name="الطفيلة",       CountryId=8},
    new SCity{Id=90, Name="معان",          CountryId=8},
    new SCity{Id=91, Name="عجلون",         CountryId=8},
 
    // ── Iraq (CountryId=9) ──
    new SCity{Id=92,  Name="بغداد",        CountryId=9},
    new SCity{Id=93,  Name="البصرة",       CountryId=9},
    new SCity{Id=94,  Name="الموصل",       CountryId=9},
    new SCity{Id=95,  Name="أربيل",        CountryId=9},
    new SCity{Id=96,  Name="النجف",        CountryId=9},
    new SCity{Id=97,  Name="كربلاء",       CountryId=9},
    new SCity{Id=98,  Name="كركوك",        CountryId=9},
    new SCity{Id=99,  Name="السليمانية",   CountryId=9},
    new SCity{Id=100, Name="الحلة",        CountryId=9},
    new SCity{Id=101, Name="الناصرية",     CountryId=9},
    new SCity{Id=102, Name="العمارة",      CountryId=9},
    new SCity{Id=103, Name="الديوانية",    CountryId=9},
    new SCity{Id=104, Name="الرمادي",      CountryId=9},
    new SCity{Id=105, Name="الكوت",        CountryId=9},
    new SCity{Id=106, Name="دهوك",         CountryId=9},
    new SCity{Id=107, Name="سامراء",       CountryId=9},
 
    // ── Syria (CountryId=10) ──
    new SCity{Id=108, Name="دمشق",         CountryId=10},
    new SCity{Id=109, Name="حلب",          CountryId=10},
    new SCity{Id=110, Name="حمص",          CountryId=10},
    new SCity{Id=111, Name="حماة",         CountryId=10},
    new SCity{Id=112, Name="اللاذقية",     CountryId=10},
    new SCity{Id=113, Name="دير الزور",    CountryId=10},
    new SCity{Id=114, Name="الرقة",        CountryId=10},
    new SCity{Id=115, Name="إدلب",         CountryId=10},
    new SCity{Id=116, Name="درعا",         CountryId=10},
    new SCity{Id=117, Name="السويداء",     CountryId=10},
    new SCity{Id=118, Name="القامشلي",     CountryId=10},
    new SCity{Id=119, Name="طرطوس",        CountryId=10},
 
    // ── Lebanon (CountryId=11) ──
    new SCity{Id=120, Name="بيروت",        CountryId=11},
    new SCity{Id=121, Name="طرابلس",       CountryId=11},
    new SCity{Id=122, Name="صيدا",         CountryId=11},
    new SCity{Id=123, Name="صور",          CountryId=11},
    new SCity{Id=124, Name="جونية",        CountryId=11},
    new SCity{Id=125, Name="زحلة",         CountryId=11},
    new SCity{Id=126, Name="النبطية",      CountryId=11},
    new SCity{Id=127, Name="بعلبك",        CountryId=11},
    new SCity{Id=128, Name="عاليه",        CountryId=11},
 
    // ── Palestine (CountryId=12) ──
    new SCity{Id=129, Name="غزة",          CountryId=12},
    new SCity{Id=130, Name="رام الله",     CountryId=12},
    new SCity{Id=131, Name="نابلس",        CountryId=12},
    new SCity{Id=132, Name="الخليل",       CountryId=12},
    new SCity{Id=133, Name="القدس",        CountryId=12},
    new SCity{Id=134, Name="جنين",         CountryId=12},
    new SCity{Id=135, Name="طولكرم",       CountryId=12},
    new SCity{Id=136, Name="أريحا",        CountryId=12},
    new SCity{Id=137, Name="بيت لحم",      CountryId=12},
    new SCity{Id=138, Name="رفح",          CountryId=12},
    new SCity{Id=139, Name="خان يونس",     CountryId=12},
 
    // ── Libya (CountryId=13) ──
    new SCity{Id=140, Name="طرابلس",       CountryId=13},
    new SCity{Id=141, Name="بنغازي",       CountryId=13},
    new SCity{Id=142, Name="مصراتة",       CountryId=13},
    new SCity{Id=143, Name="الزاوية",      CountryId=13},
    new SCity{Id=144, Name="البيضاء",      CountryId=13},
    new SCity{Id=145, Name="سبها",         CountryId=13},
    new SCity{Id=146, Name="طبرق",         CountryId=13},
    new SCity{Id=147, Name="الخمس",        CountryId=13},
    new SCity{Id=148, Name="زليتن",        CountryId=13},
    new SCity{Id=149, Name="درنة",         CountryId=13},
 
    // ── Tunisia (CountryId=14) ──
    new SCity{Id=150, Name="تونس",         CountryId=14},
    new SCity{Id=151, Name="صفاقس",        CountryId=14},
    new SCity{Id=152, Name="سوسة",         CountryId=14},
    new SCity{Id=153, Name="القيروان",     CountryId=14},
    new SCity{Id=154, Name="بنزرت",        CountryId=14},
    new SCity{Id=155, Name="قابس",         CountryId=14},
    new SCity{Id=156, Name="نابل",         CountryId=14},
    new SCity{Id=157, Name="قفصة",         CountryId=14},
    new SCity{Id=158, Name="المنستير",     CountryId=14},
    new SCity{Id=159, Name="المهدية",      CountryId=14},
    new SCity{Id=160, Name="باجة",         CountryId=14},
    new SCity{Id=161, Name="توزر",         CountryId=14},
    new SCity{Id=162, Name="مدنين",        CountryId=14},
    new SCity{Id=163, Name="زغوان",        CountryId=14},
 
    // ── Algeria (CountryId=15) ──
    new SCity{Id=164, Name="الجزائر العاصمة", CountryId=15},
    new SCity{Id=165, Name="وهران",           CountryId=15},
    new SCity{Id=166, Name="قسنطينة",         CountryId=15},
    new SCity{Id=167, Name="عنابة",           CountryId=15},
    new SCity{Id=168, Name="بلعباس",          CountryId=15},
    new SCity{Id=169, Name="سطيف",            CountryId=15},
    new SCity{Id=170, Name="باتنة",           CountryId=15},
    new SCity{Id=171, Name="بجاية",           CountryId=15},
    new SCity{Id=172, Name="تلمسان",          CountryId=15},
    new SCity{Id=173, Name="بسكرة",           CountryId=15},
    new SCity{Id=174, Name="تيارت",           CountryId=15},
    new SCity{Id=175, Name="الشلف",           CountryId=15},
    new SCity{Id=176, Name="تيزي وزو",        CountryId=15},
 
    // ── Morocco (CountryId=16) ──
    new SCity{Id=177, Name="الرباط",       CountryId=16},
    new SCity{Id=178, Name="الدار البيضاء",CountryId=16},
    new SCity{Id=179, Name="فاس",          CountryId=16},
    new SCity{Id=180, Name="مراكش",        CountryId=16},
    new SCity{Id=181, Name="طنجة",         CountryId=16},
    new SCity{Id=182, Name="أكادير",       CountryId=16},
    new SCity{Id=183, Name="مكناس",        CountryId=16},
    new SCity{Id=184, Name="وجدة",         CountryId=16},
    new SCity{Id=185, Name="القنيطرة",     CountryId=16},
    new SCity{Id=186, Name="تطوان",        CountryId=16},
    new SCity{Id=187, Name="سلا",          CountryId=16},
    new SCity{Id=188, Name="الجديدة",      CountryId=16},
 
    // ── Sudan (CountryId=17) ──
    new SCity{Id=189, Name="الخرطوم",      CountryId=17},
    new SCity{Id=190, Name="أم درمان",     CountryId=17},
    new SCity{Id=191, Name="بورتسودان",    CountryId=17},
    new SCity{Id=192, Name="كسلا",         CountryId=17},
    new SCity{Id=193, Name="الأبيض",       CountryId=17},
    new SCity{Id=194, Name="القضارف",      CountryId=17},
    new SCity{Id=195, Name="واو",          CountryId=17},
    new SCity{Id=196, Name="جوبا",         CountryId=17},
    new SCity{Id=197, Name="عطبرة",        CountryId=17},
 
    // ── Yemen (CountryId=18) ──
    new SCity{Id=198, Name="صنعاء",        CountryId=18},
    new SCity{Id=199, Name="عدن",          CountryId=18},
    new SCity{Id=200, Name="تعز",          CountryId=18},
    new SCity{Id=201, Name="الحديدة",      CountryId=18},
    new SCity{Id=202, Name="إب",           CountryId=18},
    new SCity{Id=203, Name="ذمار",         CountryId=18},
    new SCity{Id=204, Name="المكلا",       CountryId=18},
    new SCity{Id=205, Name="حضرموت",       CountryId=18},
    new SCity{Id=206, Name="مأرب",         CountryId=18},
    new SCity{Id=207, Name="سيئون",        CountryId=18},
 
    // ── Mauritania (CountryId=19) ──
    new SCity{Id=208, Name="نواكشوط",      CountryId=19},
    new SCity{Id=209, Name="نواذيبو",      CountryId=19},
    new SCity{Id=210, Name="روصو",         CountryId=19},
    new SCity{Id=211, Name="كيفه",         CountryId=19},
    new SCity{Id=212, Name="زويرات",       CountryId=19},
 
    // ── Somalia (CountryId=20) ──
    new SCity{Id=213, Name="مقديشو",       CountryId=20},
    new SCity{Id=214, Name="هرجيسا",       CountryId=20},
    new SCity{Id=215, Name="كيسمايو",      CountryId=20},
    new SCity{Id=216, Name="بوصاصو",       CountryId=20},
    new SCity{Id=217, Name="بربرة",        CountryId=20},
 
    // ── Comoros (CountryId=21) ──
    new SCity{Id=218, Name="موروني",       CountryId=21},
    new SCity{Id=219, Name="موتسامودو",    CountryId=21},
    new SCity{Id=220, Name="فومبوني",      CountryId=21},
 
    // ── Djibouti (CountryId=22) ──
    new SCity{Id=221, Name="جيبوتي",       CountryId=22},
    new SCity{Id=222, Name="علي صبيح",     CountryId=22},
    new SCity{Id=223, Name="ديخيل",        CountryId=22},
    new SCity{Id=224, Name="تاجورة",       CountryId=22},
    new SCity{Id=225, Name="عوبوك",        CountryId=22},
        };
        builder.HasData(cities);
    }
}
