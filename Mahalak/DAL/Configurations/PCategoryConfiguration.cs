using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;

public class PCategoryConfiguration : IEntityTypeConfiguration<PCategory>
{
  public void Configure(EntityTypeBuilder<PCategory> builder)
  {
    var categories = new List<PCategory>()
    {
      new PCategory()
      {
        Id = 1,
        Name = "ثلاجات و ديب فريزر",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 2,
        Name = "بوتاجازات وأفران ومايكروويف",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 3,
        Name = "غسالات ومجففات",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 4,
        Name = "تكييفات ومراوح",
        SCategoryId = 1
      },
      new PCategory() { Id = 5, Name = "سخانات", SCategoryId = 1 },
      new PCategory() { Id = 6, Name = "دفايات", SCategoryId = 1 },
      new PCategory()
      {
        Id = 7,
        Name = "مكانس كهرباىية",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 8,
        Name = "تلفزيونات و شاشات",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 9,
        Name = "أجهزة كهربائية أخرى",
        SCategoryId = 1
      },
      new PCategory()
      {
        Id = 10,
        Name = "ملابس رجالى",
        SCategoryId = 2
      },
      new PCategory()
      {
        Id = 11,
        Name = "ملابس حريمى",
        SCategoryId = 2
      },
      new PCategory()
      {
        Id = 12,
        Name = "ملابس أطفال",
        SCategoryId = 2
      },
      new PCategory()
      {
        Id = 13,
        Name = "بهارات و توابل",
        SCategoryId = 3
      },
      new PCategory() { Id = 14, Name = "أعشاب", SCategoryId = 3 },
      new PCategory() { Id = 15, Name = "حبوب", SCategoryId = 3 },
      new PCategory()
      {
        Id = 16 /*0x10*/,
        Name = "بقوليات جافة",
        SCategoryId = 3
      },
      new PCategory() { Id = 17, Name = "زيوت", SCategoryId = 3 },
      new PCategory()
      {
        Id = 18,
        Name = "مشروبات بودر",
        SCategoryId = 3
      },
      new PCategory() { Id = 19, Name = "بخور", SCategoryId = 3 },
      new PCategory() { Id = 20, Name = "فطط", SCategoryId = 4 },
      new PCategory() { Id = 21, Name = "كلاب", SCategoryId = 4 },
      new PCategory() { Id = 22, Name = "سلاحف", SCategoryId = 4 },
      new PCategory() { Id = 23, Name = "طيور", SCategoryId = 4 },
      new PCategory()
      {
        Id = 24,
        Name = "هامستر",
        SCategoryId = 4
      },
      new PCategory()
      {
        Id = 25,
        Name = "سمك زينة",
        SCategoryId = 4
      },
      new PCategory()
      {
        Id = 26,
        Name = "موبايلات",
        SCategoryId = 5
      },
      new PCategory() { Id = 27, Name = "تابلت", SCategoryId = 5 },
      new PCategory()
      {
        Id = 28,
        Name = "أكسسوارات موبيل وتابلت",
        SCategoryId = 5
      },
      new PCategory()
      {
        Id = 29,
        Name = "خطوط موبيل",
        SCategoryId = 5
      },
      new PCategory()
      {
        Id = 30,
        Name = "كمبيوتر",
        SCategoryId = 6
      },
      new PCategory()
      {
        Id = 31 /*0x1F*/,
        Name = "لاب توب",
        SCategoryId = 6
      },
      new PCategory()
      {
        Id = 32 /*0x20*/,
        Name = "أكسسوارات و قطع غيار كمبيوتر",
        SCategoryId = 6
      },
      new PCategory()
      {
        Id = 33,
        Name = "شنط سفر",
        SCategoryId = 7
      },
      new PCategory()
      {
        Id = 34,
        Name = "شنط رجالى",
        SCategoryId = 7
      },
      new PCategory()
      {
        Id = 35,
        Name = "شنط حريمى",
        SCategoryId = 7
      },
      new PCategory()
      {
        Id = 36,
        Name = "شنط أطفال",
        SCategoryId = 7
      },
      new PCategory()
      {
        Id = 37,
        Name = "شنط ظهر",
        SCategoryId = 7
      },
      new PCategory()
      {
        Id = 38,
        Name = "شنط مكتب",
        SCategoryId = 7
      },
      new PCategory() { Id = 39, Name = "معالق", SCategoryId = 8 },
      new PCategory() { Id = 40, Name = "شوك", SCategoryId = 8 },
      new PCategory()
      {
        Id = 41,
        Name = "سكاكين",
        SCategoryId = 8
      },
      new PCategory() { Id = 42, Name = "أطباق", SCategoryId = 8 },
      new PCategory()
      {
        Id = 43,
        Name = "كوبيات",
        SCategoryId = 8
      },
      new PCategory() { Id = 44, Name = "صوانى", SCategoryId = 8 },
      new PCategory()
      {
        Id = 45,
        Name = "مبشرة و أدوات تقشير",
        SCategoryId = 8
      },
      new PCategory()
      {
        Id = 46,
        Name = "صفايات",
        SCategoryId = 8
      },
      new PCategory()
      {
        Id = 47,
        Name = "طاسات و حلل",
        SCategoryId = 8
      },
      new PCategory()
      {
        Id = 48 /*0x30*/,
        Name = "أدوات مطبخ أخرى",
        SCategoryId = 8
      },
      new PCategory()
      {
        Id = 49,
        Name = "العاب ورق",
        SCategoryId = 9
      },
      new PCategory()
      {
        Id = 50,
        Name = "العاب بلاستيك",
        SCategoryId = 9
      },
      new PCategory()
      {
        Id = 51,
        Name = "العاب طاولة",
        SCategoryId = 9
      },
      new PCategory()
      {
        Id = 52,
        Name = "العاب أخرى",
        SCategoryId = 9
      },
      new PCategory()
      {
        Id = 53,
        Name = "كتب مناهج دراسية",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 54,
        Name = "أقلام رصاص و فحم",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 55,
        Name = "أقلام جاف و حبر",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 56,
        Name = "أقلام تلوين",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 57,
        Name = "مساطر",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 58,
        Name = "برايات",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 59,
        Name = "مسّاحات",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 60,
        Name = "أدوات هندسية",
        SCategoryId = 10
      },
      new PCategory()
      {
        Id = 61,
        Name = "ألالات حاسبة",
        SCategoryId = 10
      },
      new PCategory() { Id = 62, Name = "أدوات مدرسيةأخرى", SCategoryId = 10 },
      new PCategory()
      {
        Id = 63 /*0x3F*/,
        Name = "كتب دينية",
        SCategoryId = 11
      },
      new PCategory()
      {
        Id = 64 /*0x40*/,
        Name = "كتب علمية",
        SCategoryId = 11
      },
      new PCategory()
      {
        Id = 65,
        Name = "كتب أدبية",
        SCategoryId = 11
      },
      new PCategory()
      {
        Id = 66,
        Name = "قصص و روايات",
        SCategoryId = 11
      },
      new PCategory()
      {
        Id = 67,
        Name = "قصص مصورة",
        SCategoryId = 11
      },
      new PCategory() { Id = 68, Name = "كنب", SCategoryId = 12 },
      new PCategory()
      {
        Id = 69,
        Name = "سراير",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 70,
        Name = "ترابيزات",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 71,
        Name = "مكاتب",
        SCategoryId = 12
      },
      new PCategory() { Id = 72, Name = "نجف", SCategoryId = 12 },
      new PCategory()
      {
        Id = 73,
        Name = "دواليب",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 74,
        Name = "كراسى",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 75,
        Name = "أبواب وشبابيك",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 76,
        Name = "أضاءة",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 77,
        Name = "ساعات حائط",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 78,
        Name = "برواز ولوحات مناظر طبيعية",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 79,
        Name = "فازات ورود",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 80 /*0x50*/,
        Name = "أثاثات و ديكورات أخرى",
        SCategoryId = 12
      },
      new PCategory()
      {
        Id = 81,
        Name = "مراتب و مخدات",
        SCategoryId = 13
      },
      new PCategory()
      {
        Id = 82,
        Name = "ملايات وبطاطين",
        SCategoryId = 13
      },
      new PCategory()
      {
        Id = 83,
        Name = "فواط و مناشف",
        SCategoryId = 13
      },
      new PCategory()
      {
        Id = 84,
        Name = "مفارش كنب وكراسى",
        SCategoryId = 13
      },
      new PCategory()
      {
        Id = 85,
        Name = "مفارش ترابيزات",
        SCategoryId = 13
      },
      new PCategory() { Id = 86, Name = "أقمشة و مفروشات أخرى", SCategoryId = 13 },
      new PCategory()
      {
        Id = 87,
        Name = "سجاجيد و موكتات",
        SCategoryId = 14
      },
      new PCategory()
      {
        Id = 88,
        Name = "برفنات رجالى",
        SCategoryId = 15
      },
      new PCategory()
      {
        Id = 89,
        Name = "برفانات حريمى",
        SCategoryId = 15
      },
      new PCategory()
      {
        Id = 90,
        Name = "مسك و زيوت عطرية",
        SCategoryId = 15
      },
      new PCategory() { Id = 91, Name = "عطور أخرى", SCategoryId = 15 },
      new PCategory()
      {
        Id = 92,
        Name = "أوانى فخارية",
        SCategoryId = 16 /*0x10*/
      },
      new PCategory()
      {
        Id = 93,
        Name = "ملابس كروشيه",
        SCategoryId = 16 /*0x10*/
      },
      new PCategory()
      {
        Id = 94,
        Name = " حرف يدوية أخرى",
        SCategoryId = 16 /*0x10*/
      },
      new PCategory()
      {
        Id = 95,
        Name = "كور قدم",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 96 /*0x60*/,
        Name = "كور طيارة",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 97,
        Name = "كور سلة",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 98,
        Name = "مضارب و كور للتنس",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 99,
        Name = "مضارب و كور و ترابيزات للبينج",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 100,
        Name = "ملابس و معدات غوص و سباحة",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 101,
        Name = "معدات و مستلزمات ركوب الخيل",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 102,
        Name = "مستلزمات وثب و جري",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 103,
        Name = "مستلزمات رياضية أخرى",
        SCategoryId = 17
      },
      new PCategory()
      {
        Id = 104,
        Name = "حفاضات",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 105,
        Name = "بزازات و بيبرونات",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 106,
        Name = "منتجات استحمام وعناية بالبشرة",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 107,
        Name = "ملابس رضع",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 108,
        Name = "سراير أطفال",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 109,
        Name = "مستلزمات أطفال أخرى",
        SCategoryId = 18
      },
      new PCategory()
      {
        Id = 110,
        Name = "منتجات ألبان",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 111,
        Name = "أطعمة معلبة",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 112 /*0x70*/,
        Name = "سناكس و مقرمشات",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 113,
        Name = "بسكوتات و كيكات",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 114,
        Name = "شكولاتات و حلويات صناعية",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 115,
        Name = "خضار و فواكه محفوظة",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 116,
        Name = "لحوم مجففة ومصنعة",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 117,
        Name = "عصائر ومشروبات معلبة",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 118,
        Name = "سمن و زيوت صناعية",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 119,
        Name = "بقالة و مواد غذائية أخرى",
        SCategoryId = 19
      },
      new PCategory()
      {
        Id = 120,
        Name = "ساعات يد رجالى",
        SCategoryId = 20
      },
      new PCategory()
      {
        Id = 121,
        Name = "ساعات يد حريمى",
        SCategoryId = 20
      },
      new PCategory()
      {
        Id = 122,
        Name = "ساعات يد رقمية",
        SCategoryId = 20
      },
      new PCategory()
      {
        Id = 123,
        Name = "ساعات أخرى",
        SCategoryId = 20
      },
      new PCategory()
      {
        Id = 124,
        Name = "نظارات طبية رجالى",
        SCategoryId = 21
      },
      new PCategory()
      {
        Id = 125,
        Name = "نظارات طبية حريمى",
        SCategoryId = 21
      },
      new PCategory()
      {
        Id = 126,
        Name = "نظارات شمسية رجالى",
        SCategoryId = 21
      },
      new PCategory()
      {
        Id = (int) sbyte.MaxValue,
        Name = "نظارات شمسية حريمى",
        SCategoryId = 21
      },
      new PCategory()
      {
        Id = 128 /*0x80*/,
        Name = "نظرات أخرى",
        SCategoryId = 21
      },
      new PCategory()
      {
        Id = 129,
        Name = "كاميرات فيلمية",
        SCategoryId = 22
      },
      new PCategory()
      {
        Id = 130,
        Name = "كاميرات رقمية",
        SCategoryId = 22
      },
      new PCategory()
      {
        Id = 131,
        Name = "كاميرات مراقبة",
        SCategoryId = 22
      },
      new PCategory()
      {
        Id = 132,
        Name = "كاميرات أخرى",
        SCategoryId = 22
      },
      new PCategory()
      {
        Id = 133,
        Name = "اقلام شفاه",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 134,
        Name = "طلاء الأظافر",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 135,
        Name = "عدسات لاصقة",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 136,
        Name = "مساحيق التجميل",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 137,
        Name = "منتجات وكريمات عناية بالبشرة",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 138,
        Name = "زيوت وكريمات للشعر",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 139,
        Name = "حنة و صبغات للشعر",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 140,
        Name = "كحل ومسكرة",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 141,
        Name = "مزيلات العرق",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 142,
        Name = "أدوات تجميل أخرى",
        SCategoryId = 23
      },
      new PCategory()
      {
        Id = 143,
        Name = "عيش فينو",
        SCategoryId = 24
      },
      new PCategory()
      {
        Id = 144 /*0x90*/,
        Name = "عيش سن",
        SCategoryId = 24
      },
      new PCategory()
      {
        Id = 145,
        Name = "بقسماط و مقرمشات",
        SCategoryId = 24
      },
      new PCategory()
      {
        Id = 146,
        Name = "قرص ( سادة - عجوة - ملبن )",
        SCategoryId = 24
      },
      new PCategory()
      {
        Id = 147,
        Name = "مخبوزات أخرى",
        SCategoryId = 24
      },
      new PCategory()
      {
        Id = 148,
        Name = "تورتات و جاتو",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 149,
        Name = "بقلاوة",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 150,
        Name = "هريسة و بسبوسة",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 151,
        Name = "كنافة",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 152,
        Name = "حجازية",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 153,
        Name = "زلابية و بلح الشام",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 154,
        Name = "حلويات العيد و المواسم",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 155,
        Name = "حلويات أخرى",
        SCategoryId = 25
      },
      new PCategory()
      {
        Id = 156,
        Name = "سوائل و أدوات تنظيف الصحون",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 157,
        Name = "صابون و شامبو و شور جيل",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 158,
        Name = "مساحيق و سوائل تنظيف الملابس",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 159,
        Name = "منظفات للأرضيات و الحمام والمراحيض",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 160 /*0xA0*/,
        Name = "معطرات جو",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 161,
        Name = "معطرات سجاد و أرضيات",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 162,
        Name = "منظفات زجاج",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 163,
        Name = "منظفات أخرى",
        SCategoryId = 26
      },
      new PCategory()
      {
        Id = 164,
        Name = "دهانات للجدران والرفوف",
        SCategoryId = 27
      },
      new PCategory()
      {
        Id = 165,
        Name = "دهانات للخشب و الشبابيك و الأبواب ",
        SCategoryId = 27
      },
      new PCategory()
      {
        Id = 166,
        Name = "دهانات أخرى",
        SCategoryId = 27
      },
      new PCategory()
      {
        Id = 167,
        Name = "مواتير مياه",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 168,
        Name = "حنفيات و قطع غيرها",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 169,
        Name = "مواسير و قطع غيارها",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 170,
        Name = "أحواض و بانيو وجاكوزى",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 171,
        Name = "تواليتات ومستلزمتها",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 172,
        Name = "سراميك و بورسلين",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 173,
        Name = "أدوات سباكة أخرى",
        SCategoryId = 28
      },
      new PCategory()
      {
        Id = 174,
        Name = "عربيات ملاكى",
        SCategoryId = 29
      },
      new PCategory()
      {
        Id = 175,
        Name = "عربيات نقل و شاحنات",
        SCategoryId = 29
      },
      new PCategory()
      {
        Id = 176 /*0xB0*/,
        Name = "وسائل مواصلات",
        SCategoryId = 29
      },
      new PCategory()
      {
        Id = 177,
        Name = "رافعات و حفارات",
        SCategoryId = 29
      },
      new PCategory()
      {
        Id = 178,
        Name = "عربيات وقطع غيار أخرى",
        SCategoryId = 29
      },
      new PCategory()
      {
        Id = 179,
        Name = "ألات ومعدات مصانع و قطع غيرها",
        SCategoryId = 30
      },
      new PCategory()
      {
        Id = 180,
        Name = "معدات صناعية أخرى",
        SCategoryId = 30
      },
      new PCategory()
      {
        Id = 181,
        Name = "أسمدة كيماوية",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 182,
        Name = "مبيدات حشرية",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 183,
        Name = "بذور و محاصيل للزراعة",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 184,
        Name = "جرارات",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 185,
        Name = "معدات وأدوات زراعية",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 186,
        Name = "مسلزمات زراعية أخرى",
        SCategoryId = 31 /*0x1F*/
      },
      new PCategory()
      {
        Id = 187,
        Name = "صنارات",
        SCategoryId = 32 /*0x20*/
      },
      new PCategory()
      {
        Id = 188,
        Name = "شبكات صيد",
        SCategoryId = 32 /*0x20*/
      },
      new PCategory()
      {
        Id = 189,
        Name = "أطعم للصيد",
        SCategoryId = 32 /*0x20*/
      },
      new PCategory()
      {
        Id = 190,
        Name = "أدوات صيد أخرى",
        SCategoryId = 32 /*0x20*/
      },
      new PCategory()
      {
        Id = 191,
        Name = "طوب",
        SCategoryId = 33
      },
            new PCategory()
      {
        Id = 192,
        Name = "أسمنت",
        SCategoryId = 33
      },
            new PCategory()
      {
        Id = 193,
        Name = "حديد تسليح",
        SCategoryId = 33
      },
            new PCategory()
      {
        Id = 194,
        Name = "مستلزمات بناء أخرى",
        SCategoryId = 33
      },
      new PCategory()
      {
        Id = 195,
        Name = "سماعات طبية",
        SCategoryId = 34
      },
      new PCategory()
      {
        Id = 196,
        Name = "أجهزة قياس ضغط",
        SCategoryId = 34
      },
      new PCategory()
      {
        Id = 197,
        Name = "أجهزة قياس سكر",
        SCategoryId = 34
      },
      new PCategory()
      {
        Id = 198,
        Name = "أجهزة أشعة",
        SCategoryId = 34
      },
      new PCategory()
      {
        Id = 199,
        Name = "مستلزمات طبية أخرى",
        SCategoryId = 34
      },
      new PCategory()
      {
        Id = 200,
        Name = "بلاى ستيشن",
        SCategoryId = 35
      },
      new PCategory()
      {
        Id = 201,
        Name = "أكس بوكس",
        SCategoryId = 35
      },
      new PCategory() 
      { Id = 202,
       Name = "وي",
        SCategoryId = 35 },
      new PCategory()
      {
        Id = 203,
        Name = "العاب إلكتروية أخرى",
        SCategoryId = 35
      }
    };
   builder.HasData(categories);
  }
}
