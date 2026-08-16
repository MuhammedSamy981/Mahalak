using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class SAreaConfiguration : IEntityTypeConfiguration<SArea>
{
    public void Configure(EntityTypeBuilder<SArea> builder)
    {
    // Egypt 
    // ══════════════════════════════════════════════════════════
        var areas = new List<SArea>
        {
/* Start Cairo Id:1 */
           new SArea{Id=1,CityId=1,Name="15 مايو"},
           new SArea{Id=2,CityId=1,Name="الازبكية"},
           new SArea{Id=3,CityId=1,Name="البساتين"},
           new SArea{Id=4,CityId=1,Name="التبين"},
           new SArea{Id=5,CityId=1,Name="الخليفة"},
           new SArea{Id=6,CityId=1,Name="الدراسة"},
           new SArea{Id=7,CityId=1,Name="الدرب الاحمر"},
           new SArea{Id=8,CityId=1,Name="الزاوية الحمراء"},
           new SArea{Id=9,CityId=1,Name="الزيتون"},
           new SArea{Id=10,CityId=1,Name="الساحل"},
           new SArea{Id=11,CityId=1,Name="السلام"},
           new SArea{Id=12,CityId=1,Name="السيدة زينب"},
           new SArea{Id=13,CityId=1,Name="الشرابية"},
           new SArea{Id=14,CityId=1,Name="مدينة الشروق"},
           new SArea{Id=15,CityId=1,Name="الظاهر"},
           new SArea{Id=16,CityId=1,Name="العتبة"},
           new SArea{Id=17,CityId=1,Name="القاهرة الجديدة"},
           new SArea{Id=18,CityId=1,Name="المرج"},
           new SArea{Id=19,CityId=1,Name="عزبة النخل"},
           new SArea{Id=20,CityId=1,Name="المطرية"},
           new SArea{Id=21,CityId=1,Name="المعادى"},
           new SArea{Id=22,CityId=1,Name="المعصرة"},
           new SArea{Id=23,CityId=1,Name="المقطم"},
           new SArea{Id=24,CityId=1,Name="المنيل"},
           new SArea{Id=25,CityId=1,Name="الموسكى"},
           new SArea{Id=26,CityId=1,Name="النزهة"},
           new SArea{Id=27,CityId=1,Name="الوايلى"},
           new SArea{Id=28,CityId=1,Name="باب الشعرية"},
           new SArea{Id=29,CityId=1,Name="بولاق"},
           new SArea{Id=30,CityId=1,Name="جاردن سيتى"},
           new SArea{Id=31,CityId=1,Name="حدائق القبة"},
           new SArea{Id=32,CityId=1,Name="حلوان"},
           new SArea{Id=33,CityId=1,Name="دار السلام"},
           new SArea{Id=34,CityId=1,Name="شبرا"},
           new SArea{Id=35,CityId=1,Name="طره"},
           new SArea{Id=36,CityId=1,Name="عابدين"},
           new SArea{Id=37,CityId=1,Name="عباسية"},
           new SArea{Id=38,CityId=1,Name="عين شمس"},
           new SArea{Id=39,CityId=1,Name="مدينة نصر"},
           new SArea{Id=40,CityId=1,Name="مصر الجديدة"},
           new SArea{Id=41,CityId=1,Name="مصر القديمة"},
           new SArea{Id=42,CityId=1,Name="منشية ناصر"},
           new SArea{Id=43,CityId=1,Name="مدينة بدر"},
           new SArea{Id=44,CityId=1,Name="مدينة العبور"},
           new SArea{Id=45,CityId=1,Name="وسط البلد"},
           new SArea{Id=46,CityId=1,Name="الزمالك"},
           new SArea{Id=47,CityId=1,Name="قصر النيل"},
           new SArea{Id=48,CityId=1,Name="الرحاب"},
           new SArea{Id=49,CityId=1,Name="القطامية"},
           new SArea{Id=50,CityId=1,Name="مدينتي"},
           new SArea{Id=51,CityId=1,Name="روض الفرج"},
           new SArea{Id=52,CityId=1,Name="شيراتون"},
           new SArea{Id=53,CityId=1,Name="الجمالية"},
           new SArea{Id=54,CityId=1,Name="العاشر من رمضان"},
           new SArea{Id=55,CityId=1,Name="الحلمية"},
           new SArea{Id=56,CityId=1,Name="النزهة الجديدة"},
           new SArea{Id=57,CityId=1,Name="العاصمة الإدارية"},
/* End Cairo Id:1 */

/* Start Giza Id:2 */
           new SArea{Id=58,CityId=2,Name="الجيزة"},
           new SArea{Id=59,CityId=2,Name="السادس من أكتوبر"},
           new SArea{Id=60,CityId=2,Name="الشيخ زايد"},
           new SArea{Id=61,CityId=2,Name="الحوامدية"},
           new SArea{Id=62,CityId=2,Name="البدرشين"},
           new SArea{Id=63,CityId=2,Name="الصف"},
           new SArea{Id=64,CityId=2,Name="أطفيح"},
           new SArea{Id=65,CityId=2,Name="العياط"},
           new SArea{Id=66,CityId=2,Name="الباويطي"},
           new SArea{Id=67,CityId=2,Name="منشأة القناطر"},
           new SArea{Id=68,CityId=2,Name="أوسيم"},
           new SArea{Id=69,CityId=2,Name="كرداسة"},
           new SArea{Id=70,CityId=2,Name="أبو النمرس"},
           new SArea{Id=71,CityId=2,Name="كفر غطاطي"},
           new SArea{Id=72,CityId=2,Name="منشأة البكاري"},
           new SArea{Id=73,CityId=2,Name="الدقى"},
           new SArea{Id=74,CityId=2,Name="العجوزة"},
           new SArea{Id=75,CityId=2,Name="الهرم"},
           new SArea{Id=76,CityId=2,Name="الوراق"},
           new SArea{Id=77,CityId=2,Name="امبابة"},
           new SArea{Id=78,CityId=2,Name="بولاق الدكرور"},
           new SArea{Id=79,CityId=2,Name="الواحات البحرية"},
           new SArea{Id=80,CityId=2,Name="العمرانية"},
           new SArea{Id=81,CityId=2,Name="المنيب"},
           new SArea{Id=82,CityId=2,Name="بين السرايات"},
           new SArea{Id=83,CityId=2,Name="الكيت كات"},
           new SArea{Id=84,CityId=2,Name="المهندسين"},
           new SArea{Id=85,CityId=2,Name="فيصل"},
           new SArea{Id=86,CityId=2,Name="أبو رواش"},
           new SArea{Id=87,CityId=2,Name="حدائق الأهرام"},
           new SArea{Id=88,CityId=2,Name="الحرانية"},
           new SArea{Id=89,CityId=2,Name="حدائق اكتوبر"},
           new SArea{Id=90,CityId=2,Name="صفط اللبن"},
           new SArea{Id=91,CityId=2,Name="القرية الذكية"},
           new SArea{Id=92,CityId=2,Name="ارض اللواء"},
/* End Giza Id:2 */

/* Start Alexandria Id:3 */
           new SArea{Id=93,CityId=3,Name="ابو قير"},
           new SArea{Id=94,CityId=3,Name="الابراهيمية"},
           new SArea{Id=95,CityId=3,Name="الأزاريطة"},
           new SArea{Id=96,CityId=3,Name="الانفوشى"},
           new SArea{Id=97,CityId=3,Name="الدخيلة"},
           new SArea{Id=98,CityId=3,Name="السيوف"},
           new SArea{Id=99,CityId=3,Name="العامرية"},
           new SArea{Id=100,CityId=3,Name="اللبان"},
           new SArea{Id=101,CityId=3,Name="المفروزة"},
           new SArea{Id=102,CityId=3,Name="المنتزه"},
           new SArea{Id=103,CityId=3,Name="المنشية"},
           new SArea{Id=104,CityId=3,Name="الناصرية"},
           new SArea{Id=105,CityId=3,Name="امبروزو"},
           new SArea{Id=106,CityId=3,Name="باب شرق"},
           new SArea{Id=107,CityId=3,Name="برج العرب"},
           new SArea{Id=108,CityId=3,Name="ستانلى"},
           new SArea{Id=109,CityId=3,Name="سموحة"},
           new SArea{Id=110,CityId=3,Name="سيدى بشر"},
           new SArea{Id=111,CityId=3,Name="شدس"},
           new SArea{Id=112,CityId=3,Name="غيط العنب"},
           new SArea{Id=113,CityId=3,Name="فلمينج"},
           new SArea{Id=114,CityId=3,Name="فيكتوريا"},
           new SArea{Id=115,CityId=3,Name="كامب شيزار"},
           new SArea{Id=116,CityId=3,Name="كرموز"},
           new SArea{Id=117,CityId=3,Name="محطة الرمل"},
           new SArea{Id=118,CityId=3,Name="مينا البصل"},
           new SArea{Id=119,CityId=3,Name="العصافرة"},
           new SArea{Id=120,CityId=3,Name="العجمي"},
           new SArea{Id=121,CityId=3,Name="بكوس"},
           new SArea{Id=122,CityId=3,Name="بولكلي"},
           new SArea{Id=123,CityId=3,Name="كليوباترا"},
           new SArea{Id=124,CityId=3,Name="جليم"},
           new SArea{Id=125,CityId=3,Name="المعمورة"},
           new SArea{Id=126,CityId=3,Name="المندرة"},
           new SArea{Id=127,CityId=3,Name="محرم بك"},
           new SArea{Id=128,CityId=3,Name="الشاطبي"},
           new SArea{Id=129,CityId=3,Name="سيدي جابر"},
           new SArea{Id=130,CityId=3,Name="الساحل الشمالي"},
           new SArea{Id=131,CityId=3,Name="الحضرة"},
           new SArea{Id=132,CityId=3,Name="العطارين"},
           new SArea{Id=133,CityId=3,Name="سيدي كرير"},
           new SArea{Id=134,CityId=3,Name="الجمرك"},
           new SArea{Id=135,CityId=3,Name="المكس"},
           new SArea{Id=136,CityId=3,Name="مارينا"},
/* End Alexandria Id:3 */

/* Start Dakahlia Id:4 */
           new SArea{Id=137,CityId=4,Name="المنصورة"},
           new SArea{Id=138,CityId=4,Name="طلخا"},
           new SArea{Id=139,CityId=4,Name="ميت غمر"},
           new SArea{Id=140,CityId=4,Name="دكرنس"},
           new SArea{Id=141,CityId=4,Name="أجا"},
           new SArea{Id=142,CityId=4,Name="منية النصر"},
           new SArea{Id=143,CityId=4,Name="السنبلاوين"},
           new SArea{Id=144,CityId=4,Name="الكردي"},
           new SArea{Id=145,CityId=4,Name="بني عبيد"},
           new SArea{Id=146,CityId=4,Name="المنزلة"},
           new SArea{Id=147,CityId=4,Name="تمي الأمديد"},
           new SArea{Id=148,CityId=4,Name="الجمالية"},
           new SArea{Id=149,CityId=4,Name="شربين"},
           new SArea{Id=150,CityId=4,Name="المطرية"},
           new SArea{Id=151,CityId=4,Name="بلقاس"},
           new SArea{Id=152,CityId=4,Name="ميت سلسيل"},
           new SArea{Id=153,CityId=4,Name="جمصة"},
           new SArea{Id=154,CityId=4,Name="محلة دمنة"},
           new SArea{Id=155,CityId=4,Name="نبروه"},
/* End Dakahlia Id:4 */

/* Start Red Sea Id:5 */
           new SArea{Id=156,CityId=5,Name="الغردقة"},
           new SArea{Id=157,CityId=5,Name="رأس غارب"},
           new SArea{Id=158,CityId=5,Name="سفاجا"},
           new SArea{Id=159,CityId=5,Name="القصير"},
           new SArea{Id=160,CityId=5,Name="مرسى علم"},
           new SArea{Id=161,CityId=5,Name="الشلاتين"},
           new SArea{Id=162,CityId=5,Name="حلايب"},
           new SArea{Id=163,CityId=5,Name="الدهار"},
/* End Red Sea Id:5 */

/* Start Beheira Id:6 */
           new SArea{Id=164,CityId=6,Name="دمنهور"},
           new SArea{Id=165,CityId=6,Name="كفر الدوار"},
           new SArea{Id=166,CityId=6,Name="رشيد"},
           new SArea{Id=167,CityId=6,Name="إدكو"},
           new SArea{Id=168,CityId=6,Name="أبو المطامير"},
           new SArea{Id=169,CityId=6,Name="أبو حمص"},
           new SArea{Id=170,CityId=6,Name="الدلنجات"},
           new SArea{Id=171,CityId=6,Name="المحمودية"},
           new SArea{Id=172,CityId=6,Name="الرحمانية"},
           new SArea{Id=173,CityId=6,Name="إيتاي البارود"},
           new SArea{Id=174,CityId=6,Name="حوش عيسى"},
           new SArea{Id=175,CityId=6,Name="شبراخيت"},
           new SArea{Id=176,CityId=6,Name="كوم حمادة"},
           new SArea{Id=177,CityId=6,Name="بدر"},
           new SArea{Id=178,CityId=6,Name="وادي النطرون"},
           new SArea{Id=179,CityId=6,Name="النوبارية الجديدة"},
           new SArea{Id=180,CityId=6,Name="النوبارية"},
/* End Beheira Id:6 */

/* Start Fayoum Id:7 */
           new SArea{Id=181,CityId=7,Name="الفيوم"},
           new SArea{Id=182,CityId=7,Name="الفيوم الجديدة"},
           new SArea{Id=183,CityId=7,Name="طامية"},
           new SArea{Id=184,CityId=7,Name="سنورس"},
           new SArea{Id=185,CityId=7,Name="إطسا"},
           new SArea{Id=186,CityId=7,Name="إبشواي"},
           new SArea{Id=187,CityId=7,Name="يوسف الصديق"},
           new SArea{Id=188,CityId=7,Name="الحادقة"},
           new SArea{Id=189,CityId=7,Name="اطسا"},
           new SArea{Id=190,CityId=7,Name="الجامعة"},
           new SArea{Id=191,CityId=7,Name="السيالة"},
/* End Fayoum Id:7 */

/* Start Gharbia Id:8 */
           new SArea{Id=192,CityId=8,Name="طنطا"},
           new SArea{Id=193,CityId=8,Name="المحلة الكبرى"},
           new SArea{Id=194,CityId=8,Name="كفر الزيات"},
           new SArea{Id=195,CityId=8,Name="زفتى"},
           new SArea{Id=196,CityId=8,Name="السنطة"},
           new SArea{Id=197,CityId=8,Name="قطور"},
           new SArea{Id=198,CityId=8,Name="بسيون"},
           new SArea{Id=199,CityId=8,Name="سمنود"},
/* End Gharbia Id:8 */

/* Start Ismailia Id:9 */
           new SArea{Id=200,CityId=9,Name="الإسماعيلية"},
           new SArea{Id=201,CityId=9,Name="فايد"},
           new SArea{Id=202,CityId=9,Name="القنطرة شرق"},
           new SArea{Id=203,CityId=9,Name="القنطرة غرب"},
           new SArea{Id=204,CityId=9,Name="التل الكبير"},
           new SArea{Id=205,CityId=9,Name="أبو صوير"},
           new SArea{Id=206,CityId=9,Name="القصاصين الجديدة"},
           new SArea{Id=207,CityId=9,Name="نفيشة"},
           new SArea{Id=208,CityId=9,Name="الشيخ زايد"},
/* End Ismailia Id:9 */

/* Start Monufya Id:10 */
           new SArea{Id=209,CityId=10,Name="شبين الكوم"},
           new SArea{Id=210,CityId=10,Name="مدينة السادات"},
           new SArea{Id=211,CityId=10,Name="منوف"},
           new SArea{Id=212,CityId=10,Name="سرس الليان"},
           new SArea{Id=213,CityId=10,Name="أشمون"},
           new SArea{Id=214,CityId=10,Name="الباجور"},
           new SArea{Id=215,CityId=10,Name="قويسنا"},
           new SArea{Id=216,CityId=10,Name="بركة السبع"},
           new SArea{Id=217,CityId=10,Name="تلا"},
           new SArea{Id=218,CityId=10,Name="الشهداء"},
/* Start Monufya Id:10 */

/* Start Minya Id:11 */
           new SArea{Id=219,CityId=11,Name="المنيا"},
           new SArea{Id=220,CityId=11,Name="المنيا الجديدة"},
           new SArea{Id=221,CityId=11,Name="العدوة"},
           new SArea{Id=222,CityId=11,Name="مغاغة"},
           new SArea{Id=223,CityId=11,Name="بني مزار"},
           new SArea{Id=224,CityId=11,Name="مطاي"},
           new SArea{Id=225,CityId=11,Name="سمالوط"},
           new SArea{Id=226,CityId=11,Name="المدينة الفكرية"},
           new SArea{Id=227,CityId=11,Name="ملوي"},
           new SArea{Id=228,CityId=11,Name="دير مواس"},
           new SArea{Id=229,CityId=11,Name="ابو قرقاص"},
           new SArea{Id=230,CityId=11,Name="ارض سلطان"},
/* End Minya Id:11 */

/* Start Qalubia Id:12 */
           new SArea{Id=231,CityId=12,Name="بنها"},
           new SArea{Id=232,CityId=12,Name="قليوب"},
           new SArea{Id=233,CityId=12,Name="شبرا الخيمة"},
           new SArea{Id=234,CityId=12,Name="القناطر الخيرية"},
           new SArea{Id=235,CityId=12,Name="الخانكة"},
           new SArea{Id=236,CityId=12,Name="كفر شكر"},
           new SArea{Id=237,CityId=12,Name="طوخ"},
           new SArea{Id=238,CityId=12,Name="قها"},
           new SArea{Id=239,CityId=12,Name="العبور"},
           new SArea{Id=240,CityId=12,Name="الخصوص"},
           new SArea{Id=241,CityId=12,Name="شبين القناطر"},
           new SArea{Id=242,CityId=12,Name="مسطرد"},
/* End Qalubia Id:12 */

/* Start New Valley Id:13 */
           new SArea{Id=243,CityId=13,Name="الخارجة"},
           new SArea{Id=244,CityId=13,Name="باريس"},
           new SArea{Id=245,CityId=13,Name="موط"},
           new SArea{Id=246,CityId=13,Name="الفرافرة"},
           new SArea{Id=247,CityId=13,Name="بلاط"},
           new SArea{Id=248,CityId=13,Name="الداخلة"},
/* End New Valley Id:13 */

/* Start South Sinai Id:14 */
           new SArea{Id=249,CityId=14,Name="السويس"},
           new SArea{Id=250,CityId=14,Name="الجناين"},
           new SArea{Id=251,CityId=14,Name="عتاقة"},
           new SArea{Id=252,CityId=14,Name="العين السخنة"},
           new SArea{Id=253,CityId=14,Name="فيصل"},
/* End South Sinai Id:14 */

/* Start Aswan Id:15 */
           new SArea{Id=254,CityId=15,Name="أسوان"},
           new SArea{Id=255,CityId=15,Name="أسوان الجديدة"},
           new SArea{Id=256,CityId=15,Name="دراو"},
           new SArea{Id=257,CityId=15,Name="كوم أمبو"},
           new SArea{Id=258,CityId=15,Name="نصر النوبة"},
           new SArea{Id=259,CityId=15,Name="كلابشة"},
           new SArea{Id=260,CityId=15,Name="إدفو"},
           new SArea{Id=261,CityId=15,Name="الرديسية"},
           new SArea{Id=262,CityId=15,Name="البصيلية"},
           new SArea{Id=263,CityId=15,Name="السباعية"},
           new SArea{Id=264,CityId=15,Name="ابوسمبل السياحية"},
           new SArea{Id=265,CityId=15,Name="مرسى علم"},
/* End Aswan Id:15 */

/* Start Assiut Id:16 */
           new SArea{Id=266,CityId=16,Name="أسيوط"},
           new SArea{Id=267,CityId=16,Name="أسيوط الجديدة"},
           new SArea{Id=268,CityId=16,Name="ديروط"},
           new SArea{Id=269,CityId=16,Name="منفلوط"},
           new SArea{Id=270,CityId=16,Name="القوصية"},
           new SArea{Id=271,CityId=16,Name="أبنوب"},
           new SArea{Id=272,CityId=16,Name="أبو تيج"},
           new SArea{Id=273,CityId=16,Name="الغنايم"},
           new SArea{Id=274,CityId=16,Name="ساحل سليم"},
           new SArea{Id=275,CityId=16,Name="البداري"},
           new SArea{Id=276,CityId=16,Name="صدفا"},
/* End Assiut Id:16 */

/* Start Bani Sweif Id:17 */
           new SArea{Id=277,CityId=17,Name="بني سويف"},
           new SArea{Id=278,CityId=17,Name="بني سويف الجديدة"},
           new SArea{Id=279,CityId=17,Name="الواسطى"},
           new SArea{Id=280,CityId=17,Name="ناصر"},
           new SArea{Id=281,CityId=17,Name="إهناسيا"},
           new SArea{Id=282,CityId=17,Name="ببا"},
           new SArea{Id=283,CityId=17,Name="الفشن"},
           new SArea{Id=284,CityId=17,Name="سمسطا"},
           new SArea{Id=285,CityId=17,Name="الاباصيرى"},
           new SArea{Id=286,CityId=17,Name="مقبل"},
/* End Bani Sweif Id:17 */

/* Start PorSaId Id:18 */
           new SArea{Id=287,CityId=18,Name="بورسعيد"},
           new SArea{Id=288,CityId=18,Name="بورفؤاد"},
           new SArea{Id=289,CityId=18,Name="العرب"},
           new SArea{Id=290,CityId=18,Name="حى الزهور"},
           new SArea{Id=291,CityId=18,Name="حى الشرق"},
           new SArea{Id=292,CityId=18,Name="حى الضواحى"},
           new SArea{Id=293,CityId=18,Name="حى المناخ"},
           new SArea{Id=294,CityId=18,Name="حى مبارك"},
/* End PorSaId Id:18 */

/* Start Damietta Id:19 */
           new SArea{Id=295,CityId=19,Name="دمياط"},
           new SArea{Id=296,CityId=19,Name="دمياط الجديدة"},
           new SArea{Id=297,CityId=19,Name="رأس البر"},
           new SArea{Id=298,CityId=19,Name="فارسكور"},
           new SArea{Id=299,CityId=19,Name="الزرقا"},
           new SArea{Id=300,CityId=19,Name="السرو"},
           new SArea{Id=301,CityId=19,Name="الروضة"},
           new SArea{Id=302,CityId=19,Name="كفر البطيخ"},
           new SArea{Id=303,CityId=19,Name="عزبة البرج"},
           new SArea{Id=304,CityId=19,Name="ميت أبو غالب"},
           new SArea{Id=305,CityId=19,Name="كفر سعد"},
/* End Damietta Id:19 */

/* Start Sharqia Id:20 */
           new SArea{Id=306,CityId=20,Name="الزقازيق"},
           new SArea{Id=307,CityId=20,Name="العاشر من رمضان"},
           new SArea{Id=308,CityId=20,Name="منيا القمح"},
           new SArea{Id=309,CityId=20,Name="بلبيس"},
           new SArea{Id=310,CityId=20,Name="مشتول السوق"},
           new SArea{Id=311,CityId=20,Name="القنايات"},
           new SArea{Id=312,CityId=20,Name="أبو حماد"},
           new SArea{Id=313,CityId=20,Name="القرين"},
           new SArea{Id=314,CityId=20,Name="ههيا"},
           new SArea{Id=315,CityId=20,Name="أبو كبير"},
           new SArea{Id=316,CityId=20,Name="فاقوس"},
           new SArea{Id=317,CityId=20,Name="الصالحية الجديدة"},
           new SArea{Id=318,CityId=20,Name="الإبراهيمية"},
           new SArea{Id=319,CityId=20,Name="ديرب نجم"},
           new SArea{Id=320,CityId=20,Name="كفر صقر"},
           new SArea{Id=321,CityId=20,Name="أولاد صقر"},
           new SArea{Id=322,CityId=20,Name="الحسينية"},
           new SArea{Id=323,CityId=20,Name="صان الحجر القبلية"},
           new SArea{Id=324,CityId=20,Name="منشأة أبو عمر"},
/* End Sharqia Id:20 */

/* Start South Sinai Id:21 */
           new SArea{Id=325,CityId=21,Name="الطور"},
           new SArea{Id=326,CityId=21,Name="شرم الشيخ"},
           new SArea{Id=327,CityId=21,Name="دهب"},
           new SArea{Id=328,CityId=21,Name="نويبع"},
           new SArea{Id=329,CityId=21,Name="طابا"},
           new SArea{Id=330,CityId=21,Name="سانت كاترين"},
           new SArea{Id=331,CityId=21,Name="أبو رديس"},
           new SArea{Id=332,CityId=21,Name="أبو زنيمة"},
           new SArea{Id=333,CityId=21,Name="رأس سدر"},
/* End South Sinai Id:21 */

/* Start Kafr El Sheikh Id:22 */
           new SArea{Id=334,CityId=22,Name="كفر الشيخ"},
           new SArea{Id=335,CityId=22,Name="وسط البلد كفر الشيخ"},
           new SArea{Id=336,CityId=22,Name="دسوق"},
           new SArea{Id=337,CityId=22,Name="فوه"},
           new SArea{Id=338,CityId=22,Name="مطوبس"},
           new SArea{Id=339,CityId=22,Name="برج البرلس"},
           new SArea{Id=340,CityId=22,Name="بلطيم"},
           new SArea{Id=341,CityId=22,Name="مصيف بلطيم"},
           new SArea{Id=342,CityId=22,Name="الحامول"},
           new SArea{Id=343,CityId=22,Name="بيلا"},
           new SArea{Id=344,CityId=22,Name="الرياض"},
           new SArea{Id=345,CityId=22,Name="سيدي سالم"},
           new SArea{Id=346,CityId=22,Name="قلين"},
           new SArea{Id=347,CityId=22,Name="سيدي غازي"},
/* End Kafr El Sheikh Id:22 */

/* Start Matrouh Id:23 */
           new SArea{Id=348,CityId=23,Name="مرسى مطروح"},
           new SArea{Id=349,CityId=23,Name="الحمام"},
           new SArea{Id=350,CityId=23,Name="العلمين"},
           new SArea{Id=351,CityId=23,Name="الضبعة"},
           new SArea{Id=352,CityId=23,Name="النجيلة"},
           new SArea{Id=353,CityId=23,Name="سيدي براني"},
           new SArea{Id=354,CityId=23,Name="السلوم"},
           new SArea{Id=355,CityId=23,Name="سيوة"},
           new SArea{Id=356,CityId=23,Name="مارينا"},
           new SArea{Id=357,CityId=23,Name="الساحل الشمالى"},
/* End Matrouh Id:23 */

/* Start Luxor Id:24 */
           new SArea{Id=358,CityId=24,Name="الأقصر"},
           new SArea{Id=359,CityId=24,Name="الأقصر الجديدة"},
           new SArea{Id=360,CityId=24,Name="إسنا"},
           new SArea{Id=361,CityId=24,Name="طيبة الجديدة"},
           new SArea{Id=362,CityId=24,Name="الزينية"},
           new SArea{Id=363,CityId=24,Name="البياضية"},
           new SArea{Id=364,CityId=24,Name="القرنة"},
           new SArea{Id=365,CityId=24,Name="أرمنت"},
           new SArea{Id=366,CityId=24,Name="الطود"},
/* End Luxor Id:24 */

/* Start Qena Id:25 */
           new SArea{Id=367,CityId=25,Name="قنا"},
           new SArea{Id=368,CityId=25,Name="قنا الجديدة"},
           new SArea{Id=369,CityId=25,Name="ابو طشت"},
           new SArea{Id=370,CityId=25,Name="نجع حمادي"},
           new SArea{Id=371,CityId=25,Name="دشنا"},
           new SArea{Id=372,CityId=25,Name="الوقف"},
           new SArea{Id=373,CityId=25,Name="قفط"},
           new SArea{Id=374,CityId=25,Name="نقادة"},
           new SArea{Id=375,CityId=25,Name="فرشوط"},
           new SArea{Id=376,CityId=25,Name="قوص"},
/* End Qena Id:25 */

/* Start North Sinai Id:26 */
           new SArea{Id=377,CityId=26,Name="العريش"},
           new SArea{Id=378,CityId=26,Name="الشيخ زويد"},
           new SArea{Id=379,CityId=26,Name="نخل"},
           new SArea{Id=380,CityId=26,Name="رفح"},
           new SArea{Id=381,CityId=26,Name="بئر العبد"},
           new SArea{Id=382,CityId=26,Name="الحسنة"},
/* End North Sinai Id:26 */

/* Start Sohag Id:27 */
           new SArea{Id=383,CityId=27,Name="سوهاج"},
           new SArea{Id=384,CityId=27,Name="سوهاج الجديدة"},
           new SArea{Id=385,CityId=27,Name="أخميم"},
           new SArea{Id=386,CityId=27,Name="أخميم الجديدة"},
           new SArea{Id=387,CityId=27,Name="البلينا"},
           new SArea{Id=388,CityId=27,Name="المراغة"},
           new SArea{Id=389,CityId=27,Name="المنشأة"},
           new SArea{Id=390,CityId=27,Name="دار السلام"},
           new SArea{Id=391,CityId=27,Name="جرجا"},
           new SArea{Id=392,CityId=27,Name="جهينة الغربية"},
           new SArea{Id=393,CityId=27,Name="ساقلته"},
           new SArea{Id=394,CityId=27,Name="طما"},
           new SArea{Id=395,CityId=27,Name="طهطا"},
           new SArea{Id=396,CityId=27,Name="الكوثر"},
/* End Sharqia Id:27 */
// ══════════════════════════════════════════════════════════
    // SAUDI ARABIA
    // ══════════════════════════════════════════════════════════
    /* Start Riyadh Id:28 */
    new SArea{Id=397, CityId=28, Name="العليا"},
    new SArea{Id=398, CityId=28, Name="النخيل"},
    new SArea{Id=399, CityId=28, Name="الملقا"},
    new SArea{Id=400, CityId=28, Name="الرحمانية"},
    new SArea{Id=401, CityId=28, Name="الياسمين"},
    new SArea{Id=402, CityId=28, Name="حي الورود"},
    new SArea{Id=403, CityId=28, Name="حي السفارات"},
    new SArea{Id=404, CityId=28, Name="الربيع"},
    new SArea{Id=405, CityId=28, Name="الروضة"},
    new SArea{Id=406, CityId=28, Name="المروج"},
    new SArea{Id=407, CityId=28, Name="الغدير"},
    new SArea{Id=408, CityId=28, Name="النزهة"},
    new SArea{Id=409, CityId=28, Name="الفلاح"},
    new SArea{Id=410, CityId=28, Name="بدر"},
    new SArea{Id=411, CityId=28, Name="الدرعية"},
    new SArea{Id=412, CityId=28, Name="شرق الرياض"},
    new SArea{Id=413, CityId=28, Name="غرب الرياض"},
    new SArea{Id=414, CityId=28, Name="جنوب الرياض"},
    new SArea{Id=415, CityId=28, Name="نيوم"},
    new SArea{Id=416, CityId=28, Name="الدوحة الشمالية"},
    /* End Riyadh Id:28 */
    /* Start Jeddah Id:29 */
    new SArea{Id=417, CityId=29, Name="البلد"},
    new SArea{Id=418, CityId=29, Name="الروضة"},
    new SArea{Id=419, CityId=29, Name="الزهراء"},
    new SArea{Id=420, CityId=29, Name="الصفا"},
    new SArea{Id=421, CityId=29, Name="الفيصلية"},
    new SArea{Id=422, CityId=29, Name="النزهة"},
    new SArea{Id=423, CityId=29, Name="المحمدية"},
    new SArea{Id=424, CityId=29, Name="الشرفية"},
    new SArea{Id=425, CityId=29, Name="أم السلم"},
    new SArea{Id=426, CityId=29, Name="الكندرة"},
    new SArea{Id=427, CityId=29, Name="بحرة"},
    new SArea{Id=428, CityId=29, Name="رابغ"},
    new SArea{Id=429, CityId=29, Name="الحمدانية"},
    new SArea{Id=430, CityId=29, Name="التيسير"},
    new SArea{Id=431, CityId=29, Name="الفيحاء"},
    /* End Jeddah Id:29 */
    /* Start Makkah Id:30 */
    new SArea{Id=432, CityId=30, Name="الحرم المكي"},
    new SArea{Id=433, CityId=30, Name="العزيزية"},
    new SArea{Id=434, CityId=30, Name="الشوقية"},
    new SArea{Id=435, CityId=30, Name="النوارية"},
    new SArea{Id=436, CityId=30, Name="جرهم"},
    new SArea{Id=437, CityId=30, Name="التنعيم"},
    new SArea{Id=438, CityId=30, Name="العمرة"},
    new SArea{Id=439, CityId=30, Name="الهجرة"},
    new SArea{Id=440, CityId=30, Name="الزاهر"},
    new SArea{Id=441, CityId=30, Name="المعابدة"},
    /* End Makkah Id:30 */
    /* Start Madinah Id:31 */
    new SArea{Id=442, CityId=31, Name="المسجد النبوي"},
    new SArea{Id=443, CityId=31, Name="قباء"},
    new SArea{Id=444, CityId=31, Name="العوالي"},
    new SArea{Id=445, CityId=31, Name="الحرة الغربية"},
    new SArea{Id=446, CityId=31, Name="بئر علي"},
    new SArea{Id=447, CityId=31, Name="العقيق"},
    new SArea{Id=448, CityId=31, Name="النقاء"},
    new SArea{Id=449, CityId=31, Name="الأزهري"},
    /* End Madinah Id:31 */
    /* Start Dammam Id:32 */
    new SArea{Id=450, CityId=32, Name="العنود"},
    new SArea{Id=451, CityId=32, Name="الفيصلية"},
    new SArea{Id=452, CityId=32, Name="الروابي"},
    new SArea{Id=453, CityId=32, Name="الشاطئ"},
    new SArea{Id=454, CityId=32, Name="النور"},
    new SArea{Id=455, CityId=32, Name="الجلوية"},
    new SArea{Id=456, CityId=32, Name="المزروعية"},
    new SArea{Id=457, CityId=32, Name="النهضة"},
    new SArea{Id=458, CityId=32, Name="أبو حدرية"},
    /* End Dammam Id:32 */
    /* Start Khobar Id:33 */
    new SArea{Id=459, CityId=33, Name="الراكة"},
    new SArea{Id=460, CityId=33, Name="العقربية"},
    new SArea{Id=461, CityId=33, Name="الكورنيش"},
    new SArea{Id=462, CityId=33, Name="الثقبة"},
    new SArea{Id=463, CityId=33, Name="الخبر الشمالية"},
    new SArea{Id=464, CityId=33, Name="الإسكان"},
    /* End Khobar Id:33 */
    /* Start Dhahran Id:34 */
    new SArea{Id=465, CityId=34, Name="أرامكو"},
    new SArea{Id=466, CityId=34, Name="الجامعة"},
    new SArea{Id=467, CityId=34, Name="الدوحة"},
    /* End Dhahran Id:34 */
    /* Start Tabuk Id:35 */
    new SArea{Id=468, CityId=35, Name="الأندلس"},
    new SArea{Id=469, CityId=35, Name="الروابي"},
    new SArea{Id=470, CityId=35, Name="الفيصلية"},
    new SArea{Id=471, CityId=35, Name="الوادي"},
    new SArea{Id=472, CityId=35, Name="قيال"},
    /* End Tabuk Id:35 */
    /* Start Abha Id:36 */
    new SArea{Id=473, CityId=36, Name="المنهل"},
    new SArea{Id=474, CityId=36, Name="السلامة"},
    new SArea{Id=475, CityId=36, Name="النماص"},
    new SArea{Id=476, CityId=36, Name="خميس مشيط"},
    new SArea{Id=477, CityId=36, Name="بللسمر"},
    /* End Abha Id:36 */
    /* Start Najran Id:37 */
    new SArea{Id=478, CityId=37, Name="الفيصلية"},
    new SArea{Id=479, CityId=37, Name="بدر الجنوب"},
    new SArea{Id=480, CityId=37, Name="شرورة"},
    new SArea{Id=481, CityId=37, Name="حبونا"},
    /* End Najran Id:37 */
    /* Start Jazan Id:38 */
    new SArea{Id=482, CityId=38, Name="صبيا"},
    new SArea{Id=483, CityId=38, Name="أبو عريش"},
    new SArea{Id=484, CityId=38, Name="صامطة"},
    new SArea{Id=485, CityId=38, Name="العارضة"},
    new SArea{Id=486, CityId=38, Name="فيفا"},
    /* End Jazan Id:38 */
    /* Start Hail Id:39 */
    new SArea{Id=487, CityId=39, Name="موقق"},
    new SArea{Id=488, CityId=39, Name="الغزالة"},
    new SArea{Id=489, CityId=39, Name="بقعاء"},
    new SArea{Id=490, CityId=39, Name="الشنان"},
    /* End Hail Id:39 */
    /* Start Al Jawf Id:40 */
    new SArea{Id=491, CityId=40, Name="سكاكا"},
    new SArea{Id=492, CityId=40, Name="دومة الجندل"},
    new SArea{Id=493, CityId=40, Name="القريات"},
    new SArea{Id=494, CityId=40, Name="طبرجل"},
    /* End Al Jawf Id:40 */
    /* Start Taif Id:41 */
    new SArea{Id=495, CityId=41, Name="الهضبة"},
    new SArea{Id=496, CityId=41, Name="الشفا"},
    new SArea{Id=497, CityId=41, Name="الهدا"},
    new SArea{Id=498, CityId=41, Name="الكر"},
    new SArea{Id=499, CityId=41, Name="المفجر"},
    /* End Taif Id:41 */
    /* Start Buraidah Id:42 */
    new SArea{Id=500, CityId=42, Name="الروضة"},
    new SArea{Id=501, CityId=42, Name="الفهد"},
    new SArea{Id=502, CityId=42, Name="الشفاء"},
    new SArea{Id=503, CityId=42, Name="عنيزة"},
    new SArea{Id=504, CityId=42, Name="الرس"},
    /* End Buraidah Id:42 */
    /* Start Qatif Id:43 */
    new SArea{Id=505, CityId=43, Name="العوامية"},
    new SArea{Id=506, CityId=43, Name="سيهات"},
    new SArea{Id=507, CityId=43, Name="صفوى"},
    new SArea{Id=508, CityId=43, Name="تاروت"},
    /* End Qatif Id:43 */
 
    // ══════════════════════════════════════════════════════════
    // UAE
    // ══════════════════════════════════════════════════════════
    /* Start Abu Dhabi Id:44 */
    new SArea{Id=509, CityId=44, Name="الوسط"},
    new SArea{Id=510, CityId=44, Name="المصفح"},
    new SArea{Id=511, CityId=44, Name="خليفة سيتي"},
    new SArea{Id=512, CityId=44, Name="الريف"},
    new SArea{Id=513, CityId=44, Name="شاطئ الراحة"},
    new SArea{Id=514, CityId=44, Name="مدينة محمد بن زايد"},
    new SArea{Id=515, CityId=44, Name="الرحبة"},
    new SArea{Id=516, CityId=44, Name="العين"},
    new SArea{Id=517, CityId=44, Name="ليوا"},
    new SArea{Id=518, CityId=44, Name="الغريبة"},
    new SArea{Id=519, CityId=44, Name="جزيرة ياس"},
    new SArea{Id=520, CityId=44, Name="جزيرة السعديات"},
    /* End Abu Dhabi Id:44 */
    /* Start Dubai Id:45 */
    new SArea{Id=521, CityId=45, Name="ديرة"},
    new SArea{Id=522, CityId=45, Name="بر دبي"},
    new SArea{Id=523, CityId=45, Name="جميرا"},
    new SArea{Id=524, CityId=45, Name="المرسى"},
    new SArea{Id=525, CityId=45, Name="الخليج التجاري"},
    new SArea{Id=526, CityId=45, Name="وسط مدينة دبي"},
    new SArea{Id=527, CityId=45, Name="نخلة جميرا"},
    new SArea{Id=528, CityId=45, Name="دبي مارينا"},
    new SArea{Id=529, CityId=45, Name="المدينة العالمية"},
    new SArea{Id=530, CityId=45, Name="القوز"},
    new SArea{Id=531, CityId=45, Name="الورقاء"},
    new SArea{Id=532, CityId=45, Name="الروضة"},
    new SArea{Id=533, CityId=45, Name="مردف"},
    new SArea{Id=534, CityId=45, Name="دبي لاند"},
    new SArea{Id=535, CityId=45, Name="قرية جميرا الدائرية"},
    new SArea{Id=536, CityId=45, Name="أكاديمية هارتلاند"},
    new SArea{Id=537, CityId=45, Name="الفرجان"},
    new SArea{Id=538, CityId=45, Name="مجمع دبي للاستثمار"},
    /* End Dubai Id:45 */
    /* Start Sharjah Id:46 */
    new SArea{Id=539, CityId=46, Name="الخان"},
    new SArea{Id=540, CityId=46, Name="المجاز"},
    new SArea{Id=541, CityId=46, Name="النهدة"},
    new SArea{Id=542, CityId=46, Name="القاسمية"},
    new SArea{Id=543, CityId=46, Name="الرملة"},
    new SArea{Id=544, CityId=46, Name="الجرف"},
    new SArea{Id=545, CityId=46, Name="المويهات"},
    new SArea{Id=546, CityId=46, Name="التعاون"},
    /* End Sharjah Id:46 */
    /* Start Ajman Id:47 */
    new SArea{Id=547, CityId=47, Name="الرميلة"},
    new SArea{Id=548, CityId=47, Name="الراشدية"},
    new SArea{Id=549, CityId=47, Name="مدينة الزاهر"},
    new SArea{Id=550, CityId=47, Name="النعيمية"},
    new SArea{Id=551, CityId=47, Name="مصفوت"},
    /* End Ajman Id:47 */
    /* Start Ras Al Khaimah Id:48 */
    new SArea{Id=552, CityId=48, Name="الجزيرة الحمراء"},
    new SArea{Id=553, CityId=48, Name="خور خوير"},
    new SArea{Id=554, CityId=48, Name="دقداقة"},
    new SArea{Id=555, CityId=48, Name="شعم"},
    new SArea{Id=556, CityId=48, Name="الغيل"},
    /* End Ras Al Khaimah Id:48 */
    /* Start Fujairah Id:49 */
    new SArea{Id=557, CityId=49, Name="ضبا"},
    new SArea{Id=558, CityId=49, Name="خورفكان"},
    new SArea{Id=559, CityId=49, Name="كلباء"},
    new SArea{Id=560, CityId=49, Name="الفجيرة المدينة"},
    /* End Fujairah Id:49 */
    /* Start Umm Al Quwain Id:50 */
    new SArea{Id=561, CityId=50, Name="السلمة"},
    new SArea{Id=562, CityId=50, Name="الرعية"},
    new SArea{Id=563, CityId=50, Name="فلج المعلا"},
    /* End Umm Al Quwain Id:50 */
 
    // ══════════════════════════════════════════════════════════
    // KUWAIT
    // ══════════════════════════════════════════════════════════
    /* Start Kuwait City Id:51 */
    new SArea{Id=564, CityId=51, Name="شرق"},
    new SArea{Id=565, CityId=51, Name="قبلة"},
    new SArea{Id=566, CityId=51, Name="مرقاب"},
    new SArea{Id=567, CityId=51, Name="الدسمة"},
    new SArea{Id=568, CityId=51, Name="ميناء عبدالله"},
    new SArea{Id=569, CityId=51, Name="الصالحية"},
    /* End Kuwait City Id:51 */
    /* Start Hawalli Id:52 */
    new SArea{Id=570, CityId=52, Name="حولي"},
    new SArea{Id=571, CityId=52, Name="الرميثية"},
    new SArea{Id=572, CityId=52, Name="سلوى"},
    new SArea{Id=573, CityId=52, Name="الجابرية"},
    new SArea{Id=574, CityId=52, Name="بيان"},
    new SArea{Id=575, CityId=52, Name="الشعب"},
    new SArea{Id=576, CityId=52, Name="الرقعي"},
    /* End Hawalli Id:52 */
    /* Start Farwaniya Id:53 */
    new SArea{Id=577, CityId=53, Name="الفروانية"},
    new SArea{Id=578, CityId=53, Name="العارضية"},
    new SArea{Id=579, CityId=53, Name="خيطان"},
    new SArea{Id=580, CityId=53, Name="الرقعي"},
    new SArea{Id=581, CityId=53, Name="أبو فطيرة"},
    new SArea{Id=582, CityId=53, Name="جليب الشيوخ"},
    /* End Farwaniya Id:53 */
    /* Start Mubarak Al-Kabeer Id:54 */
    new SArea{Id=583, CityId=54, Name="مبارك الكبير"},
    new SArea{Id=584, CityId=54, Name="أبو الحصانية"},
    new SArea{Id=585, CityId=54, Name="القصور"},
    new SArea{Id=586, CityId=54, Name="صباح السالم"},
    /* End Mubarak Al-Kabeer Id:54 */
    /* Start Ahmadi Id:55 */
    new SArea{Id=587, CityId=55, Name="الأحمدي"},
    new SArea{Id=588, CityId=55, Name="الفنطاس"},
    new SArea{Id=589, CityId=55, Name="ميناء عبدالله"},
    new SArea{Id=590, CityId=55, Name="الزور"},
    new SArea{Id=591, CityId=55, Name="الوفرة"},
    /* End Ahmadi Id:55 */
    /* Start Jahra Id:56 */
    new SArea{Id=592, CityId=56, Name="الجهراء"},
    new SArea{Id=593, CityId=56, Name="النسيم"},
    new SArea{Id=594, CityId=56, Name="القصر"},
    new SArea{Id=595, CityId=56, Name="تيماء"},
    new SArea{Id=596, CityId=56, Name="الروضتين"},
    /* End Jahra Id:56 */
 
    // ══════════════════════════════════════════════════════════
    // QATAR
    // ══════════════════════════════════════════════════════════
    /* Start Doha Id:57 */
    new SArea{Id=597, CityId=57, Name="الدوحة الجديدة"},
    new SArea{Id=598, CityId=57, Name="العزيزية"},
    new SArea{Id=599, CityId=57, Name="الخليج"},
    new SArea{Id=600, CityId=57, Name="لوسيل"},
    new SArea{Id=601, CityId=57, Name="مشيرب"},
    new SArea{Id=602, CityId=57, Name="الغانم"},
    new SArea{Id=603, CityId=57, Name="المطار"},
    new SArea{Id=604, CityId=57, Name="أم غويلينا"},
    new SArea{Id=605, CityId=57, Name="فريج عبد العزيز"},
    /* End Doha Id:57 */
    /* Start Al Rayyan Id:58 */
    new SArea{Id=606, CityId=58, Name="الريان"},
    new SArea{Id=607, CityId=58, Name="المدينة التعليمية"},
    new SArea{Id=608, CityId=58, Name="المرخية"},
    new SArea{Id=609, CityId=58, Name="أم الحيول"},
    new SArea{Id=610, CityId=58, Name="المطار القديم"},
    /* End Al Rayyan Id:58 */
    /* Start Al Wakra Id:59 */
    new SArea{Id=611, CityId=59, Name="الوكرة"},
    new SArea{Id=612, CityId=59, Name="الوكير"},
    new SArea{Id=613, CityId=59, Name="أبو نخلة"},
    /* End Al Wakra Id:59 */
    /* Start Umm Salal Id:60 */
    new SArea{Id=614, CityId=60, Name="أم صلال محمد"},
    new SArea{Id=615, CityId=60, Name="أم صلال علي"},
    new SArea{Id=616, CityId=60, Name="سيلية"},
    /* End Umm Salal Id:60 */
    /* Start Al Shamal Id:61 */
    new SArea{Id=617, CityId=61, Name="الشمال"},
    new SArea{Id=618, CityId=61, Name="الرويس"},
    new SArea{Id=619, CityId=61, Name="فريحة"},
    /* End Al Shamal Id:61 */
    /* Start Al Khor Id:62 */
    new SArea{Id=620, CityId=62, Name="الخور"},
    new SArea{Id=621, CityId=62, Name="الذخيرة"},
    /* End Al Khor Id:62 */
    /* Start Al Daayen Id:63 */
    new SArea{Id=622, CityId=63, Name="الظعاين"},
    new SArea{Id=623, CityId=63, Name="الخيسة"},
    new SArea{Id=624, CityId=63, Name="المعامير"},
    /* End Al Daayen Id:63 */
 
    // ══════════════════════════════════════════════════════════
    // BAHRAIN
    // ══════════════════════════════════════════════════════════
    /* Start Manama Id:64 */
    new SArea{Id=625, CityId=64, Name="المنامة القديمة"},
    new SArea{Id=626, CityId=64, Name="السيف"},
    new SArea{Id=627, CityId=64, Name="القضيبية"},
    new SArea{Id=628, CityId=64, Name="الفاتح"},
    new SArea{Id=629, CityId=64, Name="جفير"},
    new SArea{Id=630, CityId=64, Name="الدبلوماسي"},
    new SArea{Id=631, CityId=64, Name="الجفير"},
    new SArea{Id=632, CityId=64, Name="المحرق الجنوبية"},
    /* End Manama Id:64 */
    /* Start Muharraq Id:65 */
    new SArea{Id=633, CityId=65, Name="المحرق"},
    new SArea{Id=634, CityId=65, Name="عراد"},
    new SArea{Id=635, CityId=65, Name="البسيتين"},
    new SArea{Id=636, CityId=65, Name="دار كليب"},
    /* End Muharraq Id:65 */
    /* Start Riffa Id:66 */
    new SArea{Id=637, CityId=66, Name="الرفاع الشرقي"},
    new SArea{Id=638, CityId=66, Name="الرفاع الغربي"},
    new SArea{Id=639, CityId=66, Name="نويدرات"},
    new SArea{Id=640, CityId=66, Name="العكر"},
    /* End Riffa Id:66 */
    /* Start Hamad Id:67 */
    new SArea{Id=641, CityId=67, Name="مدينة حمد"},
    new SArea{Id=642, CityId=67, Name="سلماباد"},
    new SArea{Id=643, CityId=67, Name="صنابيس"},
    /* End Hamad Id:67 */
    /* Start Isa Id:68 */
    new SArea{Id=644, CityId=68, Name="مدينة عيسى"},
    new SArea{Id=645, CityId=68, Name="الحجيات"},
    /* End Isa Id:68 */
    /* Start Sitra Id:69 */
    new SArea{Id=646, CityId=69, Name="سترة"},
    new SArea{Id=647, CityId=69, Name="الدور"},
    /* End Sitra Id:69 */
    /* Start Ali Id:70 */
    new SArea{Id=648, CityId=70, Name="عالي"},
    new SArea{Id=649, CityId=70, Name="أبو صيبع"},
    new SArea{Id=650, CityId=70, Name="بني جمرة"},
    /* End Ali Id:70 */
 
    // ══════════════════════════════════════════════════════════
    // OMAN
    // ══════════════════════════════════════════════════════════
    /* Start Muscat Id:71 */
    new SArea{Id=651, CityId=71, Name="روي"},
    new SArea{Id=652, CityId=71, Name="بوشر"},
    new SArea{Id=653, CityId=71, Name="مطرح"},
    new SArea{Id=654, CityId=71, Name="قريات"},
    new SArea{Id=655, CityId=71, Name="العامرات"},
    new SArea{Id=656, CityId=71, Name="مسقط القديمة"},
    new SArea{Id=657, CityId=71, Name="الموالح"},
    new SArea{Id=658, CityId=71, Name="الخوير"},
    new SArea{Id=659, CityId=71, Name="المعبيلة"},
    new SArea{Id=660, CityId=71, Name="الأزيبة"},
    /* End Muscat Id:71 */
    /* Start Salalah Id:72 */
    new SArea{Id=661, CityId=72, Name="صلالة"},
    new SArea{Id=662, CityId=72, Name="طاقة"},
    new SArea{Id=663, CityId=72, Name="مرباط"},
    new SArea{Id=664, CityId=72, Name="ثمريت"},
    /* End Salalah Id:72 */
    /* Start Sohar Id:73 */
    new SArea{Id=665, CityId=73, Name="صحار"},
    new SArea{Id=666, CityId=73, Name="شناص"},
    new SArea{Id=667, CityId=73, Name="لوى"},
    /* End Sohar Id:73 */
    /* Start Nizwa Id:74 */
    new SArea{Id=668, CityId=74, Name="نزوى"},
    new SArea{Id=669, CityId=74, Name="بهلاء"},
    new SArea{Id=670, CityId=74, Name="منح"},
    new SArea{Id=671, CityId=74, Name="الحمراء"},
    /* End Nizwa Id:74 */
    /* Start Seeb Id:75 */
    new SArea{Id=672, CityId=75, Name="السيب"},
    new SArea{Id=673, CityId=75, Name="الخابورة"},
    new SArea{Id=674, CityId=75, Name="المصنعة"},
    /* End Seeb Id:75 */
    /* Start Sur Id:76 */
    new SArea{Id=675, CityId=76, Name="صور"},
    new SArea{Id=676, CityId=76, Name="الكامل والوافي"},
    new SArea{Id=677, CityId=76, Name="جعلان بني بو علي"},
    /* End Sur Id:76 */
    /* Start Buraimi Id:77 */
    new SArea{Id=678, CityId=77, Name="البريمي"},
    new SArea{Id=679, CityId=77, Name="محضة"},
    /* End Buraimi Id:77 */
    /* Start Ibri Id:78 */
    new SArea{Id=680, CityId=78, Name="عبري"},
    new SArea{Id=681, CityId=78, Name="ينقل"},
    /* End Ibri Id:78 */
    /* Start Ibra Id:79 */
    new SArea{Id=682, CityId=79, Name="إبراء"},
    new SArea{Id=683, CityId=79, Name="المضيبي"},
    /* End Ibra Id:79 */
 
    // ══════════════════════════════════════════════════════════
    // JORDAN
    // ══════════════════════════════════════════════════════════
    /* Start Amman Id:80 */
    new SArea{Id=684, CityId=80, Name="وسط البلد"},
    new SArea{Id=685, CityId=80, Name="جبل عمان"},
    new SArea{Id=686, CityId=80, Name="الشميساني"},
    new SArea{Id=687, CityId=80, Name="الرابية"},
    new SArea{Id=688, CityId=80, Name="دابوق"},
    new SArea{Id=689, CityId=80, Name="الجبيهة"},
    new SArea{Id=690, CityId=80, Name="مرج الحمام"},
    new SArea{Id=691, CityId=80, Name="الجاردنز"},
    new SArea{Id=692, CityId=80, Name="تلاع العلي"},
    new SArea{Id=693, CityId=80, Name="أبو نصير"},
    new SArea{Id=694, CityId=80, Name="خلدا"},
    new SArea{Id=695, CityId=80, Name="صويلح"},
    new SArea{Id=696, CityId=80, Name="طارق"},
    new SArea{Id=697, CityId=80, Name="العبدلي"},
    new SArea{Id=698, CityId=80, Name="الهاشمي الشمالي"},
    new SArea{Id=699, CityId=80, Name="ماركا"},
    /* End Amman Id:80 */
    /* Start Zarqa Id:81 */
    new SArea{Id=700, CityId=81, Name="الزرقاء الجديدة"},
    new SArea{Id=701, CityId=81, Name="الرصيفة"},
    new SArea{Id=702, CityId=81, Name="الهاشمية"},
    new SArea{Id=703, CityId=81, Name="ضليل"},
    /* End Zarqa Id:81 */
    /* Start Irbid Id:82 */
    new SArea{Id=704, CityId=82, Name="إربد"},
    new SArea{Id=705, CityId=82, Name="الرمثا"},
    new SArea{Id=706, CityId=82, Name="بني عبيد"},
    new SArea{Id=707, CityId=82, Name="الحصن"},
    /* End Irbid Id:82 */
    /* Start Aqaba Id:83 */
    new SArea{Id=708, CityId=83, Name="شاطئ العقبة"},
    new SArea{Id=709, CityId=83, Name="المدينة الصناعية"},
    new SArea{Id=710, CityId=83, Name="النخيل"},
    /* End Aqaba Id:83 */
    /* Start Salt Id:84 */
    new SArea{Id=711, CityId=84, Name="السلط"},
    new SArea{Id=712, CityId=84, Name="عين الباشا"},
    new SArea{Id=713, CityId=84, Name="دير علا"},
    /* End Salt Id:84 */
    /* Start Madaba Id:85 */
    new SArea{Id=714, CityId=85, Name="مادبا"},
    new SArea{Id=715, CityId=85, Name="ذيبان"},
    new SArea{Id=716, CityId=85, Name="الفيصلية"},
    /* End Madaba Id:85 */
    /* Start Karak Id:86 */
    new SArea{Id=717, CityId=86, Name="الكرك"},
    new SArea{Id=718, CityId=86, Name="الغور"},
    new SArea{Id=719, CityId=86, Name="مؤتة"},
    /* End Karak Id:86 */
    /* Start Jerash Id:87 */
    new SArea{Id=720, CityId=87, Name="جرش"},
    new SArea{Id=721, CityId=87, Name="برما"},
    /* End Jerash Id:87 */
    /* Start Mafraq Id:88 */
    new SArea{Id=722, CityId=88, Name="المفرق"},
    new SArea{Id=723, CityId=88, Name="الرويشد"},
    new SArea{Id=724, CityId=88, Name="الزعتري"},
    /* End Mafraq Id:88 */
    /* Start Tafilah Id:89 */
    new SArea{Id=725, CityId=89, Name="الطفيلة"},
    new SArea{Id=726, CityId=89, Name="بصيرا"},
    /* End Tafilah Id:89 */
    /* Start Maan Id:90 */
    new SArea{Id=727, CityId=90, Name="معان"},
    new SArea{Id=728, CityId=90, Name="البتراء"},
    new SArea{Id=729, CityId=90, Name="وادي موسى"},
    /* End Maan Id:90 */
    /* Start Ajloun Id:91 */
    new SArea{Id=730, CityId=91, Name="عجلون"},
    new SArea{Id=731, CityId=91, Name="كفرنجة"},
    /* End Ajloun Id:91 */
 
    // ══════════════════════════════════════════════════════════
    // IRAQ
    // ══════════════════════════════════════════════════════════
    /* Start Baghdad Id:92 */
    new SArea{Id=732, CityId=92, Name="الكرخ"},
    new SArea{Id=733, CityId=92, Name="الرصافة"},
    new SArea{Id=734, CityId=92, Name="الأعظمية"},
    new SArea{Id=735, CityId=92, Name="الكاظمية"},
    new SArea{Id=736, CityId=92, Name="المنصور"},
    new SArea{Id=737, CityId=92, Name="الكرادة"},
    new SArea{Id=738, CityId=92, Name="الزعفرانية"},
    new SArea{Id=739, CityId=92, Name="الدورة"},
    new SArea{Id=740, CityId=92, Name="الشعب"},
    new SArea{Id=741, CityId=92, Name="المدائن"},
    new SArea{Id=742, CityId=92, Name="الوزيرية"},
    new SArea{Id=743, CityId=92, Name="العطيفية"},
    new SArea{Id=744, CityId=92, Name="الجادرية"},
    new SArea{Id=745, CityId=92, Name="صدر سيتي"},
    /* End Baghdad Id:92 */
    /* Start Basra Id:93 */
    new SArea{Id=746, CityId=93, Name="أبو الخصيب"},
    new SArea{Id=747, CityId=93, Name="الزبير"},
    new SArea{Id=748, CityId=93, Name="القرنة"},
    new SArea{Id=749, CityId=93, Name="شط العرب"},
    new SArea{Id=750, CityId=93, Name="المدينة"},
    /* End Basra Id:93 */
    /* Start Mosul Id:94 */
    new SArea{Id=751, CityId=94, Name="الجانب الأيمن"},
    new SArea{Id=752, CityId=94, Name="الجانب الأيسر"},
    new SArea{Id=753, CityId=94, Name="بعشيقة"},
    new SArea{Id=754, CityId=94, Name="تلعفر"},
    /* End Mosul Id:94 */
    /* Start Erbil Id:95 */
    new SArea{Id=755, CityId=95, Name="أربيل"},
    new SArea{Id=756, CityId=95, Name="كويسنجق"},
    new SArea{Id=757, CityId=95, Name="رواندوز"},
    new SArea{Id=758, CityId=95, Name="شقلاوة"},
    /* End Erbil Id:95 */
    /* Start Najaf Id:96 */
    new SArea{Id=759, CityId=96, Name="النجف"},
    new SArea{Id=760, CityId=96, Name="الكوفة"},
    new SArea{Id=761, CityId=96, Name="المناذرة"},
    /* End Najaf Id:96 */
    /* Start Karbala Id:97 */
    new SArea{Id=762, CityId=97, Name="كربلاء"},
    new SArea{Id=763, CityId=97, Name="الهندية"},
    /* End Karbala Id:97 */
    /* Start Kirkuk Id:98 */
    new SArea{Id=764, CityId=98, Name="كركوك"},
    new SArea{Id=765, CityId=98, Name="دبس"},
    new SArea{Id=766, CityId=98, Name="الحويجة"},
    /* End Kirkuk Id:98 */
    /* Start Sulaymaniyah Id:99 */
    new SArea{Id=767, CityId=99, Name="السليمانية"},
    new SArea{Id=768, CityId=99, Name="حلبجة"},
    new SArea{Id=769, CityId=99, Name="جمجمال"},
    /* End Sulaymaniyah Id:99 */
    /* Start Hilla Id:100 */
    new SArea{Id=770, CityId=100, Name="الحلة"},
    new SArea{Id=771, CityId=100, Name="المحاويل"},
    new SArea{Id=772, CityId=100, Name="المسيب"},
    /* End Hilla Id:100 */
    /* Start Nasiriyah Id:101 */
    new SArea{Id=773, CityId=101, Name="الناصرية"},
    new SArea{Id=774, CityId=101, Name="سوق الشيوخ"},
    new SArea{Id=775, CityId=101, Name="الرفاعي"},
    /* End Nasiriyah Id:101 */
    /* Start Amarah Id:102 */
    new SArea{Id=776, CityId=102, Name="العمارة"},
    new SArea{Id=777, CityId=102, Name="علي الغربي"},
    new SArea{Id=778, CityId=102, Name="قلعة صالح"},
    /* End Amarah Id:102 */
    /* Start Diwaniyah Id:103 */
    new SArea{Id=779, CityId=103, Name="الديوانية"},
    new SArea{Id=780, CityId=103, Name="الشامية"},
    new SArea{Id=781, CityId=103, Name="الحمزة"},
    /* End Diwaniyah Id:103 */
    /* Start Ramadi Id:104 */
    new SArea{Id=782, CityId=104, Name="الرمادي"},
    new SArea{Id=783, CityId=104, Name="الفلوجة"},
    new SArea{Id=784, CityId=104, Name="هيت"},
    /* End Ramadi Id:104 */
    /* Start Kut Id:105 */
    new SArea{Id=785, CityId=105, Name="الكوت"},
    new SArea{Id=786, CityId=105, Name="العزيزية"},
    new SArea{Id=787, CityId=105, Name="النعمانية"},
    /* End Kut Id:105 */
    /* Start Duhok Id:106 */
    new SArea{Id=788, CityId=106, Name="دهوك"},
    new SArea{Id=789, CityId=106, Name="زاخو"},
    new SArea{Id=790, CityId=106, Name="عقرة"},
    /* End Duhok Id:106 */
    /* Start Samarra Id:107 */
    new SArea{Id=791, CityId=107, Name="سامراء"},
    new SArea{Id=792, CityId=107, Name="بيجي"},
    new SArea{Id=793, CityId=107, Name="الدجيل"},
    /* End Samarra Id:107 */
 
    // ══════════════════════════════════════════════════════════
    // SYRIA
    // ══════════════════════════════════════════════════════════
    /* Start Damascus Id:108 */
    new SArea{Id=794, CityId=108, Name="المزة"},
    new SArea{Id=795, CityId=108, Name="المالكي"},
    new SArea{Id=796, CityId=108, Name="أبو رمانة"},
    new SArea{Id=797, CityId=108, Name="الشعلان"},
    new SArea{Id=798, CityId=108, Name="باب توما"},
    new SArea{Id=799, CityId=108, Name="جرمانا"},
    new SArea{Id=800, CityId=108, Name="داريا"},
    new SArea{Id=801, CityId=108, Name="الزبلطاني"},
    new SArea{Id=802, CityId=108, Name="القابون"},
    new SArea{Id=803, CityId=108, Name="دمر"},
    new SArea{Id=804, CityId=108, Name="المزرعة"},
    new SArea{Id=805, CityId=108, Name="الصالحية"},
    /* End Damascus Id:108 */
    /* Start Aleppo Id:109 */
    new SArea{Id=806, CityId=109, Name="العزيزية"},
    new SArea{Id=807, CityId=109, Name="السريان"},
    new SArea{Id=808, CityId=109, Name="الجميلية"},
    new SArea{Id=809, CityId=109, Name="شارع النيل"},
    new SArea{Id=810, CityId=109, Name="المدينة القديمة"},
    new SArea{Id=811, CityId=109, Name="حي الفرقان"},
    /* End Aleppo Id:109 */
    /* Start Homs Id:110 */
    new SArea{Id=812, CityId=110, Name="الوعر"},
    new SArea{Id=813, CityId=110, Name="الخالدية"},
    new SArea{Id=814, CityId=110, Name="باب عمرو"},
    new SArea{Id=815, CityId=110, Name="حي الزهرة"},
    /* End Homs Id:110 */
    /* Start Hama Id:111 */
    new SArea{Id=816, CityId=111, Name="حماة"},
    new SArea{Id=817, CityId=111, Name="مصياف"},
    new SArea{Id=818, CityId=111, Name="السلمية"},
    /* End Hama Id:111 */
    /* Start Latakia Id:112 */
    new SArea{Id=819, CityId=112, Name="اللاذقية"},
    new SArea{Id=820, CityId=112, Name="جبلة"},
    new SArea{Id=821, CityId=112, Name="القرداحة"},
    /* End Latakia Id:112 */
    /* Start Deir ez-Zor Id:113 */
    new SArea{Id=822, CityId=113, Name="دير الزور"},
    new SArea{Id=823, CityId=113, Name="الميادين"},
    new SArea{Id=824, CityId=113, Name="البوكمال"},
    /* End Deir ez-Zor Id:113 */
    /* Start Raqqa Id:114 */
    new SArea{Id=825, CityId=114, Name="الرقة"},
    new SArea{Id=826, CityId=114, Name="الطبقة"},
    /* End Raqqa Id:114 */
    /* Start Idlib Id:115 */
    new SArea{Id=827, CityId=115, Name="إدلب"},
    new SArea{Id=828, CityId=115, Name="جسر الشغور"},
    new SArea{Id=829, CityId=115, Name="معرة النعمان"},
    new SArea{Id=830, CityId=115, Name="أريحا"},
    /* End Idlib Id:115 */
    /* Start Daraa Id:116 */
    new SArea{Id=831, CityId=116, Name="درعا"},
    new SArea{Id=832, CityId=116, Name="السويداء"},
    new SArea{Id=833, CityId=116, Name="بصرى الشام"},
    /* End Daraa Id:116 */
    /* Start As-Suwayda Id:117 */
    new SArea{Id=834, CityId=117, Name="السويداء"},
    new SArea{Id=835, CityId=117, Name="شهبا"},
    new SArea{Id=836, CityId=117, Name="صلخد"},
    /* End As-Suwayda Id:117 */
    /* Start Qamishli Id:118 */
    new SArea{Id=837, CityId=118, Name="القامشلي"},
    new SArea{Id=838, CityId=118, Name="عامودا"},
    new SArea{Id=839, CityId=118, Name="الحسكة"},
    /* End Qamishli Id:118 */
    /* Start Tartus Id:119 */
    new SArea{Id=840, CityId=119, Name="طرطوس"},
    new SArea{Id=841, CityId=119, Name="صافيتا"},
    new SArea{Id=842, CityId=119, Name="بانياس"},
    /* End Tartus Id:119 */
 
    // ══════════════════════════════════════════════════════════
    // LEBANON
    // ══════════════════════════════════════════════════════════
    /* Start Beirut Id:120 */
    new SArea{Id=843, CityId=120, Name="الحمرا"},
    new SArea{Id=844, CityId=120, Name="الروشة"},
    new SArea{Id=845, CityId=120, Name="الأشرفية"},
    new SArea{Id=846, CityId=120, Name="الجميزة"},
    new SArea{Id=847, CityId=120, Name="وسط بيروت"},
    new SArea{Id=848, CityId=120, Name="الكولا"},
    new SArea{Id=849, CityId=120, Name="المزرعة"},
    new SArea{Id=850, CityId=120, Name="الطريق الجديدة"},
    new SArea{Id=851, CityId=120, Name="رأس النبع"},
    new SArea{Id=852, CityId=120, Name="المصيطبة"},
    /* End Beirut Id:120 */
    /* Start Tripoli Id:121 */
    new SArea{Id=853, CityId=121, Name="طرابلس الفيحاء"},
    new SArea{Id=854, CityId=121, Name="البداوي"},
    new SArea{Id=855, CityId=121, Name="القبة"},
    new SArea{Id=856, CityId=121, Name="المنية"},
    /* End Tripoli Id:121 */
    /* Start Sidon Id:122 */
    new SArea{Id=857, CityId=122, Name="صيدا"},
    new SArea{Id=858, CityId=122, Name="الزهراني"},
    new SArea{Id=859, CityId=122, Name="صاريتا"},
    /* End Sidon Id:122 */
    /* Start Tyre Id:123 */
    new SArea{Id=860, CityId=123, Name="صور"},
    new SArea{Id=861, CityId=123, Name="القليعة"},
    new SArea{Id=862, CityId=123, Name="العباسية"},
    /* End Tyre Id:123 */
    /* Start Jounieh Id:124 */
    new SArea{Id=863, CityId=124, Name="جونية"},
    new SArea{Id=864, CityId=124, Name="كسروان"},
    new SArea{Id=865, CityId=124, Name="الجبيل"},
    /* End Jounieh Id:124 */
    /* Start Zahle Id:125 */
    new SArea{Id=866, CityId=125, Name="زحلة"},
    new SArea{Id=867, CityId=125, Name="البر الياس"},
    new SArea{Id=868, CityId=125, Name="تعلبايا"},
    /* End Zahle Id:125 */
    /* Start Nabatieh Id:126 */
    new SArea{Id=869, CityId=126, Name="النبطية"},
    new SArea{Id=870, CityId=126, Name="بنت جبيل"},
    new SArea{Id=871, CityId=126, Name="حاصبيا"},
    /* End Nabatieh Id:126 */
    /* Start Baalbek Id:127 */
    new SArea{Id=872, CityId=127, Name="بعلبك"},
    new SArea{Id=873, CityId=127, Name="الهرمل"},
    new SArea{Id=874, CityId=127, Name="يونين"},
    /* End Baalbek Id:127 */
    /* Start Aley Id:128 */
    new SArea{Id=875, CityId=128, Name="عاليه"},
    new SArea{Id=876, CityId=128, Name="بحمدون"},
    new SArea{Id=877, CityId=128, Name="الشويفات"},
    /* End Aley Id:128 */
 
    // ══════════════════════════════════════════════════════════
    // PALESTINE
    // ══════════════════════════════════════════════════════════
    /* Start Gaza Id:129 */
    new SArea{Id=878, CityId=129, Name="الشجاعية"},
    new SArea{Id=879, CityId=129, Name="الرمال"},
    new SArea{Id=880, CityId=129, Name="التفاح"},
    new SArea{Id=881, CityId=129, Name="الزيتون"},
    new SArea{Id=882, CityId=129, Name="النصر"},
    /* End Gaza Id:129 */
    /* Start Ramallah Id:130 */
    new SArea{Id=883, CityId=130, Name="البيرة"},
    new SArea{Id=884, CityId=130, Name="بيت ايل"},
    new SArea{Id=885, CityId=130, Name="الباسة"},
    /* End Ramallah Id:130 */
    /* Start Nablus Id:131 */
    new SArea{Id=886, CityId=131, Name="نابلس"},
    new SArea{Id=887, CityId=131, Name="بيت فوريك"},
    new SArea{Id=888, CityId=131, Name="حوارة"},
    /* End Nablus Id:131 */
    /* Start Hebron Id:132 */
    new SArea{Id=889, CityId=132, Name="الخليل"},
    new SArea{Id=890, CityId=132, Name="يطا"},
    new SArea{Id=891, CityId=132, Name="دورا"},
    /* End Hebron Id:132 */
    /* Start Jerusalem Id:133 */
    new SArea{Id=892, CityId=133, Name="البلدة القديمة"},
    new SArea{Id=893, CityId=133, Name="الشيخ جراح"},
    new SArea{Id=894, CityId=133, Name="سلوان"},
    new SArea{Id=895, CityId=133, Name="رأس العامود"},
    /* End Jerusalem Id:133 */
    /* Start Jenin Id:134 */
    new SArea{Id=896, CityId=134, Name="جنين"},
    new SArea{Id=897, CityId=134, Name="مخيم جنين"},
    new SArea{Id=898, CityId=134, Name="يعبد"},
    /* End Jenin Id:134 */
    /* Start Tulkarm Id:135 */
    new SArea{Id=899, CityId=135, Name="طولكرم"},
    new SArea{Id=900, CityId=135, Name="عنبتا"},
    new SArea{Id=901, CityId=135, Name="قلقيلية"},
    /* End Tulkarm Id:135 */
    /* Start Jericho Id:136 */
    new SArea{Id=902, CityId=136, Name="أريحا"},
    new SArea{Id=903, CityId=136, Name="النويعمة"},
    /* End Jericho Id:136 */
    /* Start Bethlehem Id:137 */
    new SArea{Id=904, CityId=137, Name="بيت لحم"},
    new SArea{Id=905, CityId=137, Name="بيت جالا"},
    new SArea{Id=906, CityId=137, Name="بيت ساحور"},
    /* End Bethlehem Id:137 */
    /* Start Rafah Id:138 */
    new SArea{Id=907, CityId=138, Name="رفح"},
    new SArea{Id=908, CityId=138, Name="المصطبة"},
    /* End Rafah Id:138 */
    /* Start Khan Yunis Id:139 */
    new SArea{Id=909, CityId=139, Name="خان يونس"},
    new SArea{Id=910, CityId=139, Name="الزوايدة"},
    new SArea{Id=911, CityId=139, Name="عبسان"},
    /* End Khan Yunis Id:139 */
 
    // ══════════════════════════════════════════════════════════
    // LIBYA
    // ══════════════════════════════════════════════════════════
    /* Start Tripoli Id:140 */
    new SArea{Id=912, CityId=140, Name="طرابلس المركز"},
    new SArea{Id=913, CityId=140, Name="حي الأندلس"},
    new SArea{Id=914, CityId=140, Name="سوق الجمعة"},
    new SArea{Id=915, CityId=140, Name="حي الدهماني"},
    new SArea{Id=916, CityId=140, Name="قرجي"},
    new SArea{Id=917, CityId=140, Name="عين زارة"},
    new SArea{Id=918, CityId=140, Name="الفرناج"},
    /* End Tripoli Id:140 */
    /* Start Benghazi Id:141 */
    new SArea{Id=919, CityId=141, Name="بنغازي المركز"},
    new SArea{Id=920, CityId=141, Name="حي المقيف"},
    new SArea{Id=921, CityId=141, Name="السابع"},
    new SArea{Id=922, CityId=141, Name="الصابري"},
    new SArea{Id=923, CityId=141, Name="بوعطني"},
    /* End Benghazi Id:141 */
    /* Start Misrata Id:142 */
    new SArea{Id=924, CityId=142, Name="مصراتة المركز"},
    new SArea{Id=925, CityId=142, Name="القربولي"},
    new SArea{Id=926, CityId=142, Name="بوسيف"},
    /* End Misrata Id:142 */
    /* Start Zawiya Id:143 */
    new SArea{Id=927, CityId=143, Name="الزاوية"},
    new SArea{Id=928, CityId=143, Name="صرمان"},
    /* End Zawiya Id:143 */
    /* Start Al Bayda Id:144 */
    new SArea{Id=929, CityId=144, Name="البيضاء"},
    new SArea{Id=930, CityId=144, Name="المرج"},
    /* End Al Bayda Id:144 */
    /* Start Sabha Id:145 */
    new SArea{Id=931, CityId=145, Name="سبها"},
    new SArea{Id=932, CityId=145, Name="مرزق"},
    /* End Sabha Id:145 */
    /* Start Tobruk Id:146 */
    new SArea{Id=933, CityId=146, Name="طبرق"},
    new SArea{Id=934, CityId=146, Name="البردية"},
    /* End Tobruk Id:146 */
    /* Start Khoms Id:147 */
    new SArea{Id=935, CityId=147, Name="الخمس"},
    new SArea{Id=936, CityId=147, Name="ترهونة"},
    /* End Khoms Id:147 */
    /* Start Zliten Id:148 */
    new SArea{Id=937, CityId=148, Name="زليتن"},
    new SArea{Id=938, CityId=148, Name="بني وليد"},
    /* End Zliten Id:148 */
    /* Start Derna Id:149 */
    new SArea{Id=939, CityId=149, Name="درنة"},
    new SArea{Id=940, CityId=149, Name="سوسة"},
    /* End Derna Id:149 */
 
    // ══════════════════════════════════════════════════════════
    // TUNISIA
    // ══════════════════════════════════════════════════════════
    /* Start Tunis Id:150 */
    new SArea{Id=941, CityId=150, Name="المدينة العتيقة"},
    new SArea{Id=942, CityId=150, Name="الكرم"},
    new SArea{Id=943, CityId=150, Name="باردو"},
    new SArea{Id=944, CityId=150, Name="حمام الأنف"},
    new SArea{Id=945, CityId=150, Name="المرسى"},
    new SArea{Id=946, CityId=150, Name="قرطاج"},
    new SArea{Id=947, CityId=150, Name="سيدي بوسعيد"},
    new SArea{Id=948, CityId=150, Name="العمران"},
    new SArea{Id=949, CityId=150, Name="منوبة"},
    /* End Tunis Id:150 */
    /* Start Sfax Id:151 */
    new SArea{Id=950, CityId=151, Name="صفاقس المدينة"},
    new SArea{Id=951, CityId=151, Name="ساقية الداير"},
    new SArea{Id=952, CityId=151, Name="طينة"},
    /* End Sfax Id:151 */
    /* Start Sousse Id:152 */
    new SArea{Id=953, CityId=152, Name="سوسة المدينة"},
    new SArea{Id=954, CityId=152, Name="مساكن"},
    new SArea{Id=955, CityId=152, Name="المنتزه"},
    /* End Sousse Id:152 */
    /* Start Kairouan Id:153 */
    new SArea{Id=956, CityId=153, Name="القيروان"},
    new SArea{Id=957, CityId=153, Name="حفوز"},
    /* End Kairouan Id:153 */
    /* Start Bizerte Id:154 */
    new SArea{Id=958, CityId=154, Name="بنزرت"},
    new SArea{Id=959, CityId=154, Name="منزل بورقيبة"},
    /* End Bizerte Id:154 */
    /* Start Gabes Id:155 */
    new SArea{Id=960, CityId=155, Name="قابس"},
    new SArea{Id=961, CityId=155, Name="مطماطة"},
    /* End Gabes Id:155 */
    /* Start Nabeul Id:156 */
    new SArea{Id=962, CityId=156, Name="نابل"},
    new SArea{Id=963, CityId=156, Name="الحمامات"},
    new SArea{Id=964, CityId=156, Name="قربة"},
    /* End Nabeul Id:156 */
    /* Start Gafsa Id:157 */
    new SArea{Id=965, CityId=157, Name="قفصة"},
    new SArea{Id=966, CityId=157, Name="الرديف"},
    /* End Gafsa Id:157 */
    /* Start Monastir Id:158 */
    new SArea{Id=967, CityId=158, Name="المنستير"},
    new SArea{Id=968, CityId=158, Name="المكنين"},
    new SArea{Id=969, CityId=158, Name="قصر هلال"},
    /* End Monastir Id:158 */
    /* Start Mahdia Id:159 */
    new SArea{Id=970, CityId=159, Name="المهدية"},
    new SArea{Id=971, CityId=159, Name="قصور الساف"},
    /* End Mahdia Id:159 */
    /* Start Beja Id:160 */
    new SArea{Id=972, CityId=160, Name="باجة"},
    new SArea{Id=973, CityId=160, Name="جندوبة"},
    /* End Beja Id:160 */
    /* Start Tozeur Id:161 */
    new SArea{Id=974, CityId=161, Name="توزر"},
    new SArea{Id=975, CityId=161, Name="دقاش"},
    /* End Tozeur Id:161 */
    /* Start Medenine Id:162 */
    new SArea{Id=976, CityId=162, Name="مدنين"},
    new SArea{Id=977, CityId=162, Name="جرجيس"},
    new SArea{Id=978, CityId=162, Name="جربة"},
    /* End Medenine Id:162 */
    /* Start Zaghouan Id:163 */
    new SArea{Id=979, CityId=163, Name="زغوان"},
    new SArea{Id=980, CityId=163, Name="الفحص"},
    /* End Zaghouan Id:163 */
 
    // ══════════════════════════════════════════════════════════
    // ALGERIA
    // ══════════════════════════════════════════════════════════
    /* Start Algiers Id:164 */
    new SArea{Id=981,  CityId=164, Name="وسط الجزائر"},
    new SArea{Id=982,  CityId=164, Name="باب الوادي"},
    new SArea{Id=983,  CityId=164, Name="القصبة"},
    new SArea{Id=984,  CityId=164, Name="الحراش"},
    new SArea{Id=985,  CityId=164, Name="بئر مراد رايس"},
    new SArea{Id=986,  CityId=164, Name="بن عكنون"},
    new SArea{Id=987,  CityId=164, Name="الدار البيضاء"},
    new SArea{Id=988,  CityId=164, Name="حيدرة"},
    new SArea{Id=989,  CityId=164, Name="الرغاية"},
    new SArea{Id=990,  CityId=164, Name="دالي إبراهيم"},
    new SArea{Id=991,  CityId=164, Name="سيدي موسى"},
    new SArea{Id=992,  CityId=164, Name="بوزريعة"},
    /* End Algiers Id:164 */
    /* Start Oran Id:165 */
    new SArea{Id=993,  CityId=165, Name="وهران المركز"},
    new SArea{Id=994,  CityId=165, Name="سيدي الشحمي"},
    new SArea{Id=995,  CityId=165, Name="أرزيو"},
    new SArea{Id=996,  CityId=165, Name="مرسى الكبير"},
    new SArea{Id=997,  CityId=165, Name="بئر الجير"},
    /* End Oran Id:165 */
    /* Start Constantine Id:166 */
    new SArea{Id=998,  CityId=166, Name="قسنطينة المركز"},
    new SArea{Id=999,  CityId=166, Name="عين سمارة"},
    new SArea{Id=1000, CityId=166, Name="الخروب"},
    new SArea{Id=1001, CityId=166, Name="حامة بوزيان"},
    /* End Constantine Id:166 */
    /* Start Annaba Id:167 */
    new SArea{Id=1002, CityId=167, Name="عنابة المركز"},
    new SArea{Id=1003, CityId=167, Name="سيدي عمار"},
    new SArea{Id=1004, CityId=167, Name="البوني"},
    /* End Annaba Id:167 */
    /* Start Sidi Bel Abbes Id:168 */
    new SArea{Id=1005, CityId=168, Name="سيدي بلعباس"},
    new SArea{Id=1006, CityId=168, Name="سفيزف"},
    /* End Sidi Bel Abbes Id:168 */
    /* Start Setif Id:169 */
    new SArea{Id=1007, CityId=169, Name="سطيف"},
    new SArea{Id=1008, CityId=169, Name="عين أولمان"},
    new SArea{Id=1009, CityId=169, Name="برج بوعريريج"},
    /* End Setif Id:169 */
    /* Start Batna Id:170 */
    new SArea{Id=1010, CityId=170, Name="باتنة"},
    new SArea{Id=1011, CityId=170, Name="بريكة"},
    new SArea{Id=1012, CityId=170, Name="عين التوتة"},
    /* End Batna Id:170 */
    /* Start Bejaia Id:171 */
    new SArea{Id=1013, CityId=171, Name="بجاية"},
    new SArea{Id=1014, CityId=171, Name="أقبو"},
    new SArea{Id=1015, CityId=171, Name="الفنار"},
    /* End Bejaia Id:171 */
    /* Start Tlemcen Id:172 */
    new SArea{Id=1016, CityId=172, Name="تلمسان"},
    new SArea{Id=1017, CityId=172, Name="مغنية"},
    new SArea{Id=1018, CityId=172, Name="الغزوات"},
    /* End Tlemcen Id:172 */
    /* Start Biskra Id:173 */
    new SArea{Id=1019, CityId=173, Name="بسكرة"},
    new SArea{Id=1020, CityId=173, Name="طولقة"},
    new SArea{Id=1021, CityId=173, Name="أوماش"},
    /* End Biskra Id:173 */
    /* Start Tiaret Id:174 */
    new SArea{Id=1022, CityId=174, Name="تيارت"},
    new SArea{Id=1023, CityId=174, Name="سوق أهراس"},
    /* End Tiaret Id:174 */
    /* Start Chlef Id:175 */
    new SArea{Id=1024, CityId=175, Name="الشلف"},
    new SArea{Id=1025, CityId=175, Name="تنس"},
    /* End Chlef Id:175 */
    /* Start Tizi Ouzou Id:176 */
    new SArea{Id=1026, CityId=176, Name="تيزي وزو"},
    new SArea{Id=1027, CityId=176, Name="ذراع بن خدة"},
    new SArea{Id=1028, CityId=176, Name="بودواو"},
    /* End Tizi Ouzou Id:176 */
 
    // ══════════════════════════════════════════════════════════
    // MOROCCO
    // ══════════════════════════════════════════════════════════
    /* Start Rabat Id:177 */
    new SArea{Id=1029, CityId=177, Name="أكدال"},
    new SArea{Id=1030, CityId=177, Name="السويسي"},
    new SArea{Id=1031, CityId=177, Name="حسان"},
    new SArea{Id=1032, CityId=177, Name="يعقوب المنصور"},
    new SArea{Id=1033, CityId=177, Name="الرياض"},
    new SArea{Id=1034, CityId=177, Name="المدينة القديمة"},
    new SArea{Id=1035, CityId=177, Name="أنفا"},
    /* End Rabat Id:177 */
    /* Start Casablanca Id:178 */
    new SArea{Id=1036, CityId=178, Name="المدينة القديمة"},
    new SArea{Id=1037, CityId=178, Name="حي المعاريف"},
    new SArea{Id=1038, CityId=178, Name="عين الديب"},
    new SArea{Id=1039, CityId=178, Name="حي الحسن"},
    new SArea{Id=1040, CityId=178, Name="برنوسي"},
    new SArea{Id=1041, CityId=178, Name="ابن مسيك"},
    new SArea{Id=1042, CityId=178, Name="الفداء"},
    new SArea{Id=1043, CityId=178, Name="الليمون"},
    new SArea{Id=1044, CityId=178, Name="حي الهلال"},
    new SArea{Id=1045, CityId=178, Name="مرتيل"},
    /* End Casablanca Id:178 */
    /* Start Fes Id:179 */
    new SArea{Id=1046, CityId=179, Name="فاس البالي"},
    new SArea{Id=1047, CityId=179, Name="فاس الجديد"},
    new SArea{Id=1048, CityId=179, Name="عين الشكف"},
    new SArea{Id=1049, CityId=179, Name="ولاد تايمة"},
    /* End Fes Id:179 */
    /* Start Marrakesh Id:180 */
    new SArea{Id=1050, CityId=180, Name="المدينة"},
    new SArea{Id=1051, CityId=180, Name="جيليز"},
    new SArea{Id=1052, CityId=180, Name="هيبرونديرج"},
    new SArea{Id=1053, CityId=180, Name="المنارة"},
    new SArea{Id=1054, CityId=180, Name="الطحانة"},
    /* End Marrakesh Id:180 */
    /* Start Tangier Id:181 */
    new SArea{Id=1055, CityId=181, Name="المدينة القديمة"},
    new SArea{Id=1056, CityId=181, Name="المنطقة الحرة"},
    new SArea{Id=1057, CityId=181, Name="مالاباتا"},
    /* End Tangier Id:181 */
    /* Start Agadir Id:182 */
    new SArea{Id=1058, CityId=182, Name="أكادير"},
    new SArea{Id=1059, CityId=182, Name="إينزكان"},
    new SArea{Id=1060, CityId=182, Name="أيت ملول"},
    /* End Agadir Id:182 */
    /* Start Meknes Id:183 */
    new SArea{Id=1061, CityId=183, Name="مكناس العتيقة"},
    new SArea{Id=1062, CityId=183, Name="الحمرية"},
    new SArea{Id=1063, CityId=183, Name="ملولة"},
    /* End Meknes Id:183 */
    /* Start Oujda Id:184 */
    new SArea{Id=1064, CityId=184, Name="وجدة"},
    new SArea{Id=1065, CityId=184, Name="الناضور"},
    new SArea{Id=1066, CityId=184, Name="بركان"},
    /* End Oujda Id:184 */
    /* Start Kenitra Id:185 */
    new SArea{Id=1067, CityId=185, Name="القنيطرة"},
    new SArea{Id=1068, CityId=185, Name="مهدية"},
    new SArea{Id=1069, CityId=185, Name="سيدي قاسم"},
    /* End Kenitra Id:185 */
    /* Start Tetouan Id:186 */
    new SArea{Id=1070, CityId=186, Name="تطوان"},
    new SArea{Id=1071, CityId=186, Name="مرتيل"},
    new SArea{Id=1072, CityId=186, Name="الحسيمة"},
    /* End Tetouan Id:186 */
    /* Start Sale Id:187 */
    new SArea{Id=1073, CityId=187, Name="سلا المدينة"},
    new SArea{Id=1074, CityId=187, Name="تابريكت"},
    new SArea{Id=1075, CityId=187, Name="بيت الواد"},
    /* End Sale Id:187 */
    /* Start El Jadida Id:188 */
    new SArea{Id=1076, CityId=188, Name="الجديدة"},
    new SArea{Id=1077, CityId=188, Name="أزمور"},
    /* End El Jadida Id:188 */
 
    // ══════════════════════════════════════════════════════════
    // SUDAN
    // ══════════════════════════════════════════════════════════
    /* Start Khartoum Id:189 */
    new SArea{Id=1078, CityId=189, Name="الخرطوم"},
    new SArea{Id=1079, CityId=189, Name="بحري"},
    new SArea{Id=1080, CityId=189, Name="الكلاكلة"},
    new SArea{Id=1081, CityId=189, Name="حي العرب"},
    new SArea{Id=1082, CityId=189, Name="الرياض"},
    new SArea{Id=1083, CityId=189, Name="الخرطوم 2"},
    /* End Khartoum Id:189 */
    /* Start Omdurman Id:190 */
    new SArea{Id=1084, CityId=190, Name="أم درمان"},
    new SArea{Id=1085, CityId=190, Name="الثورة"},
    new SArea{Id=1086, CityId=190, Name="ودنوباوي"},
    /* End Omdurman Id:190 */
    /* Start Port Sudan Id:191 */
    new SArea{Id=1087, CityId=191, Name="بورتسودان"},
    new SArea{Id=1088, CityId=191, Name="طوكر"},
    /* End Port Sudan Id:191 */
    /* Start Kassala Id:192 */
    new SArea{Id=1089, CityId=192, Name="كسلا"},
    new SArea{Id=1090, CityId=192, Name="الروصيرص"},
    /* End Kassala Id:192 */
    /* Start El Obeid Id:193 */
    new SArea{Id=1091, CityId=193, Name="الأبيض"},
    new SArea{Id=1092, CityId=193, Name="الرهد"},
    /* End El Obeid Id:193 */
    /* Start Gedaref Id:194 */
    new SArea{Id=1093, CityId=194, Name="القضارف"},
    new SArea{Id=1094, CityId=194, Name="الحوادة"},
    /* End Gedaref Id:194 */
    /* Start Wau Id:195 */
    new SArea{Id=1095, CityId=195, Name="واو"},
    new SArea{Id=1096, CityId=195, Name="رجاء"},
    /* End Wau Id:195 */
    /* Start Juba Id:196 */
    new SArea{Id=1097, CityId=196, Name="جوبا"},
    new SArea{Id=1098, CityId=196, Name="مالاكال"},
    /* End Juba Id:196 */
    /* Start Atbara Id:197 */
    new SArea{Id=1099, CityId=197, Name="عطبرة"},
    new SArea{Id=1100, CityId=197, Name="دامر"},
    /* End Atbara Id:197 */
 
    // ══════════════════════════════════════════════════════════
    // YEMEN
    // ══════════════════════════════════════════════════════════
    /* Start Sanaa Id:198 */
    new SArea{Id=1101, CityId=198, Name="المدينة القديمة"},
    new SArea{Id=1102, CityId=198, Name="حدة"},
    new SArea{Id=1103, CityId=198, Name="صنعاء الجديدة"},
    new SArea{Id=1104, CityId=198, Name="شعوب"},
    new SArea{Id=1105, CityId=198, Name="السبعين"},
    new SArea{Id=1106, CityId=198, Name="الروضة"},
    new SArea{Id=1107, CityId=198, Name="الجراف"},
    /* End Sanaa Id:198 */
    /* Start Aden Id:199 */
    new SArea{Id=1108, CityId=199, Name="كريتر"},
    new SArea{Id=1109, CityId=199, Name="المنصورة"},
    new SArea{Id=1110, CityId=199, Name="الشيخ عثمان"},
    new SArea{Id=1111, CityId=199, Name="التواهي"},
    new SArea{Id=1112, CityId=199, Name="البريقة"},
    new SArea{Id=1113, CityId=199, Name="خورمكسر"},
    /* End Aden Id:199 */
    /* Start Taiz Id:200 */
    new SArea{Id=1114, CityId=200, Name="تعز"},
    new SArea{Id=1115, CityId=200, Name="صالة"},
    new SArea{Id=1116, CityId=200, Name="المسمح"},
    /* End Taiz Id:200 */
    /* Start Hudaydah Id:201 */
    new SArea{Id=1117, CityId=201, Name="الحديدة"},
    new SArea{Id=1118, CityId=201, Name="الدريهمي"},
    new SArea{Id=1119, CityId=201, Name="باجل"},
    /* End Hudaydah Id:201 */
    /* Start Ibb Id:202 */
    new SArea{Id=1120, CityId=202, Name="إب"},
    new SArea{Id=1121, CityId=202, Name="يريم"},
    new SArea{Id=1122, CityId=202, Name="جبلة"},
    /* End Ibb Id:202 */
    /* Start Dhamar Id:203 */
    new SArea{Id=1123, CityId=203, Name="ذمار"},
    new SArea{Id=1124, CityId=203, Name="عتق"},
    /* End Dhamar Id:203 */
    /* Start Mukalla Id:204 */
    new SArea{Id=1125, CityId=204, Name="المكلا"},
    new SArea{Id=1126, CityId=204, Name="ريدة"},
    /* End Mukalla Id:204 */
    /* Start Hadhramaut Id:205 */
    new SArea{Id=1127, CityId=205, Name="سيئون"},
    new SArea{Id=1128, CityId=205, Name="شبام"},
    new SArea{Id=1129, CityId=205, Name="تريم"},
    /* End Hadhramaut Id:205 */
    /* Start Marib Id:206 */
    new SArea{Id=1130, CityId=206, Name="مأرب"},
    new SArea{Id=1131, CityId=206, Name="صرواح"},
    /* End Marib Id:206 */
    /* Start Seiyun Id:207 */
    new SArea{Id=1132, CityId=207, Name="سيئون"},
    new SArea{Id=1133, CityId=207, Name="القطن"},
    /* End Seiyun Id:207 */
 
    // ══════════════════════════════════════════════════════════
    // MAURITANIA
    // ══════════════════════════════════════════════════════════
    /* Start Nouakchott Id:208 */
    new SArea{Id=1134, CityId=208, Name="تيارت"},
    new SArea{Id=1135, CityId=208, Name="كيفه"},
    new SArea{Id=1136, CityId=208, Name="الميناء"},
    new SArea{Id=1137, CityId=208, Name="تيفرت"},
    /* End Nouakchott Id:208 */
    /* Start Nouadhibou Id:209 */
    new SArea{Id=1138, CityId=209, Name="نواذيبو"},
    new SArea{Id=1139, CityId=209, Name="كانصادو"},
    /* End Nouadhibou Id:209 */
    /* Start Rosso Id:210 */
    new SArea{Id=1140, CityId=210, Name="روصو"},
    new SArea{Id=1141, CityId=210, Name="بوكي"},
    /* End Rosso Id:210 */
    /* Start Kiffa Id:211 */
    new SArea{Id=1142, CityId=211, Name="كيفه"},
    new SArea{Id=1143, CityId=211, Name="تمبدغة"},
    /* End Kiffa Id:211 */
    /* Start Zouerate Id:212 */
    new SArea{Id=1144, CityId=212, Name="زويرات"},
    new SArea{Id=1145, CityId=212, Name="أطار"},
    /* End Zouerate Id:212 */
 
    // ══════════════════════════════════════════════════════════
    // SOMALIA
    // ══════════════════════════════════════════════════════════
    /* Start Mogadishu Id:213 */
    new SArea{Id=1146, CityId=213, Name="حوادلي"},
    new SArea{Id=1147, CityId=213, Name="بندر"},
    new SArea{Id=1148, CityId=213, Name="وابري"},
    new SArea{Id=1149, CityId=213, Name="حمرويين"},
    /* End Mogadishu Id:213 */
    /* Start Hargeisa Id:214 */
    new SArea{Id=1150, CityId=214, Name="هرجيسا"},
    new SArea{Id=1151, CityId=214, Name="إيريجاو"},
    /* End Hargeisa Id:214 */
    /* Start Kismayo Id:215 */
    new SArea{Id=1152, CityId=215, Name="كيسمايو"},
    new SArea{Id=1153, CityId=215, Name="جوبا الأسفل"},
    /* End Kismayo Id:215 */
    /* Start Bosaso Id:216 */
    new SArea{Id=1154, CityId=216, Name="بوصاصو"},
    new SArea{Id=1155, CityId=216, Name="قاردو"},
    /* End Bosaso Id:216 */
    /* Start Berbera Id:217 */
    new SArea{Id=1156, CityId=217, Name="بربرة"},
    new SArea{Id=1157, CityId=217, Name="بلدة"},
    /* End Berbera Id:217 */
 
    // ══════════════════════════════════════════════════════════
    // COMOROS
    // ══════════════════════════════════════════════════════════
    /* Start Moroni Id:218 */
    new SArea{Id=1158, CityId=218, Name="موروني"},
    new SArea{Id=1159, CityId=218, Name="إيتساندراني"},
    /* End Moroni Id:218 */
    /* Start Mutsamudu Id:219 */
    new SArea{Id=1160, CityId=219, Name="موتسامودو"},
    new SArea{Id=1161, CityId=219, Name="دوميني"},
    /* End Mutsamudu Id:219 */
    /* Start Fomboni Id:220 */
    new SArea{Id=1162, CityId=220, Name="فومبوني"},
    new SArea{Id=1163, CityId=220, Name="نيوماشوا"},
    /* End Fomboni Id:220 */
 
    // ══════════════════════════════════════════════════════════
    // DJIBOUTI
    // ══════════════════════════════════════════════════════════
    /* Start Djibouti City Id:221 */
    new SArea{Id=1164, CityId=221, Name="الجديدة"},
    new SArea{Id=1165, CityId=221, Name="المدينة"},
    new SArea{Id=1166, CityId=221, Name="حيبوبالي"},
    new SArea{Id=1167, CityId=221, Name="بالبالة"},
    /* End Djibouti City Id:221 */
    /* Start Ali Sabieh Id:222 */
    new SArea{Id=1168, CityId=222, Name="علي صبيح"},
    new SArea{Id=1169, CityId=222, Name="هول هول"},
    /* End Ali Sabieh Id:222 */
    /* Start Dikhil Id:223 */
    new SArea{Id=1170, CityId=223, Name="ديخيل"},
    new SArea{Id=1171, CityId=223, Name="رندا"},
    /* End Dikhil Id:223 */
    /* Start Tadjourah Id:224 */
    new SArea{Id=1172, CityId=224, Name="تاجورة"},
    new SArea{Id=1173, CityId=224, Name="روانباد"},
    /* End Tadjourah Id:224 */
    /* Start Obock Id:225 */
    new SArea{Id=1174, CityId=225, Name="عوبوك"},
    new SArea{Id=1175, CityId=225, Name="درقوس"},
    /* End Obock Id:225 */
        
    };
        builder.HasData(areas);
    }
}
