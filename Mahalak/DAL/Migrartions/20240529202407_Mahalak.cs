using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mahalak.DAL.Migrartions
{
    /// <inheritdoc />
    public partial class Mahalak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PConditions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PConditions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCountries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCountries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Birthdate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoginTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MaxShopNum = table.Column<int>(type: "int", nullable: false),
                    AddedShopsExpDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViolationsCount = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ExpDtOfBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PCategories_SCategories_SCategoryID",
                        column: x => x.SCategoryID,
                        principalTable: "SCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCities_SCountries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "SCountries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAreas_SCities_CityID",
                        column: x => x.CityID,
                        principalTable: "SCities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distinctive = table.Column<bool>(type: "bit", nullable: false),
                    ExpDtOfMark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxProductNum = table.Column<int>(type: "int", nullable: false),
                    CreatingDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shops_SAreas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "SAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_SCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "SCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_SCities_CityID",
                        column: x => x.CityID,
                        principalTable: "SCities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Shops_SCountries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "SCountries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Shops_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddingDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_PCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "PCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_PConditions_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "PConditions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Datetime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ratings_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PConditions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "جديد" },
                    { 2, "مستعمل" }
                });

            migrationBuilder.InsertData(
                table: "SCategories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "أجهزة كهربائية" },
                    { 2, "ملابس" },
                    { 3, "عطارة" },
                    { 4, "حيوانات أليفة" },
                    { 5, "موبايلات و تابلت و إكسسواراتهما" },
                    { 6, "كمبيوتر و إكسسواراته" },
                    { 7, "شنط و أحذية" },
                    { 8, "أدوات مطبخ" },
                    { 9, "العاب أطفال" },
                    { 10, "مكتبة أدوات مدرسية" },
                    { 11, "مكتبة كتب" },
                    { 12, "أثاث و ديكور" },
                    { 13, "أقمشة و مفروشات" },
                    { 14, "سجاجيد و موكتات" },
                    { 15, "عطور" },
                    { 16, "حرف يدوية" },
                    { 17, "مستلزمات رياضية" },
                    { 18, "مستلزمات أطفال رضع" },
                    { 19, "بقالة و مواد غذائية" },
                    { 20, "ساعات" },
                    { 21, "نظرات" },
                    { 22, "كاميرات وأكسسوارتها" },
                    { 23, "أدوات تجميل" },
                    { 24, "مخبوزات" },
                    { 25, "حلويات" },
                    { 26, "منظفات" },
                    { 27, "دهانات" },
                    { 28, "سباكة" },
                    { 29, "عربيات وقطع غيار" },
                    { 30, "معدات صناعية" },
                    { 31, "مسلزمات زراعية" },
                    { 32, "أدوات صيد" },
                    { 33, "مستلزمات بناء" },
                    { 34, "مستلزمات طبية" }
                });

            migrationBuilder.InsertData(
                table: "SCountries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "مصر" });

            migrationBuilder.InsertData(
                table: "PCategories",
                columns: new[] { "ID", "Name", "SCategoryID" },
                values: new object[,]
                {
                    { 1, "ثلاجات و ديب فريزر", 1 },
                    { 2, "بوتاجازات وأفران ومايكروويف", 1 },
                    { 3, "غسالات ومجففات", 1 },
                    { 4, "تكييفات ومراوح", 1 },
                    { 5, "سخانات", 1 },
                    { 6, "دفايات", 1 },
                    { 7, "مكانس كهرباىية", 1 },
                    { 8, "تلفزيونات و شاشات", 1 },
                    { 9, "أجهزة كهربائية أخرى", 1 },
                    { 10, "ملابس رجالى", 2 },
                    { 11, "ملابس حريمى", 2 },
                    { 12, "ملابس أطفال", 2 },
                    { 13, "بهارات و توابل", 3 },
                    { 14, "أعشاب", 3 },
                    { 15, "حبوب", 3 },
                    { 16, "بقوليات جافة", 3 },
                    { 17, "زيوت", 3 },
                    { 18, "مشروبات بودر", 3 },
                    { 19, "بخور", 3 },
                    { 20, "فطط", 4 },
                    { 21, "كلاب", 4 },
                    { 22, "سلاحف", 4 },
                    { 23, "طيور", 4 },
                    { 24, "هامستر", 4 },
                    { 25, "سمك زينة", 4 },
                    { 26, "موبايلات", 5 },
                    { 27, "تابلت", 5 },
                    { 28, "أكسسوارات موبيل وتابلت", 5 },
                    { 29, "خطوط موبيل", 5 },
                    { 30, "كمبيوتر", 6 },
                    { 31, "لاب توب", 6 },
                    { 32, "أكسسوارات و قطع غيار كمبيوتر", 6 },
                    { 33, "شنط سفر", 7 },
                    { 34, "شنط رجالى", 7 },
                    { 35, "شنط حريمى", 7 },
                    { 36, "شنط أطفال", 7 },
                    { 37, "شنط ظهر", 7 },
                    { 38, "شنط مكتب", 7 },
                    { 39, "معالق", 8 },
                    { 40, "شوك", 8 },
                    { 41, "سكاكين", 8 },
                    { 42, "أطباق", 8 },
                    { 43, "كوبيات", 8 },
                    { 44, "صوانى", 8 },
                    { 45, "مبشرة و أدوات تقشير", 8 },
                    { 46, "صفايات", 8 },
                    { 47, "طاسات و حلل", 8 },
                    { 48, "أدوات مطبخ أخرى", 8 },
                    { 49, "العاب ورق", 9 },
                    { 50, "العاب بلاستيك", 9 },
                    { 51, "العاب طاولة", 9 },
                    { 52, "العاب إلكتروية", 9 },
                    { 53, "كتب مناهج دراسية", 10 },
                    { 54, "أقلام رصاص و فحم", 10 },
                    { 55, "أقلام جاف و حبر", 10 },
                    { 56, "أقلام تلوين", 10 },
                    { 57, "مساطر", 10 },
                    { 58, "برايات", 10 },
                    { 59, "مسّاحات", 10 },
                    { 60, "أدوات هندسية", 10 },
                    { 61, "ألالات حاسبة", 10 },
                    { 62, "أخرى", 10 },
                    { 63, "كتب دينية", 11 },
                    { 64, "كتب علمية", 11 },
                    { 65, "كتب أدبية", 11 },
                    { 66, "قصص و روايات", 11 },
                    { 67, "قصص مصورة", 11 },
                    { 68, "كنب", 12 },
                    { 69, "سراير", 12 },
                    { 70, "ترابيزات", 12 },
                    { 71, "مكاتب", 12 },
                    { 72, "نجف", 12 },
                    { 73, "دواليب", 12 },
                    { 74, "كراسى", 12 },
                    { 75, "أبواب وشبابيك", 12 },
                    { 76, "أضاءة", 12 },
                    { 77, "ساعات حائط", 12 },
                    { 78, "برواز ولوحات مناظر طبيعية", 12 },
                    { 79, "فازات ورود", 12 },
                    { 80, "أخرى", 12 },
                    { 81, "مراتب و مخدات", 13 },
                    { 82, "ملايات وبطاطين", 13 },
                    { 83, "فواط و مناشف", 13 },
                    { 84, "مفارش كنب وكراسى", 13 },
                    { 85, "مفارش ترابيزات", 13 },
                    { 86, "أخرى", 13 },
                    { 87, "سجاجيد و موكتات", 14 },
                    { 88, "برفنات رجالى", 15 },
                    { 89, "برفانات حريمى", 15 },
                    { 90, "مسك و زيوت عطرية", 15 },
                    { 91, "أخرى", 15 },
                    { 92, "أوانى فخارية", 16 },
                    { 93, "ملابس كروشيه", 16 },
                    { 94, "أخرى", 16 },
                    { 95, "كور قدم", 17 },
                    { 96, "كور طيارة", 17 },
                    { 97, "كور سلة", 17 },
                    { 98, "مضارب و كور للتنس", 17 },
                    { 99, "مضارب و كور و ترابيزات للبينج", 17 },
                    { 100, "ملابس و معدات غوص و سباحة", 17 },
                    { 101, "معدات و مستلزمات ركوب الخيل", 17 },
                    { 102, "مستلزمات وثب و جري", 17 },
                    { 103, "أخرى", 17 },
                    { 104, "حفاضات", 18 },
                    { 105, "بزازات و بيبرونات", 18 },
                    { 106, "منتجات استحمام وعناية بالبشرة", 18 },
                    { 107, "ملابس رضع", 18 },
                    { 108, "سراير أطفال", 18 },
                    { 109, "أخرى", 18 },
                    { 110, "منتجات ألبان", 19 },
                    { 111, "أطعمة معلبة", 19 },
                    { 112, "سناكس و مقرمشات", 19 },
                    { 113, "بسكوتات و كيكات", 19 },
                    { 114, "شكولاتات و حلويات صناعية", 19 },
                    { 115, "خضار و فواكه محفوظة", 19 },
                    { 116, "لحوم مجففة ومصنعة", 19 },
                    { 117, "عصائر ومشروبات معلبة", 19 },
                    { 118, "سمن و زيوت صناعية", 19 },
                    { 119, "أخرى", 19 },
                    { 120, "ساعات يد رجالى", 20 },
                    { 121, "ساعات يد حريمى", 20 },
                    { 122, "ساعات يد رقمية", 20 },
                    { 123, "أخرى", 20 },
                    { 124, "نظارات طبية رجالى", 21 },
                    { 125, "نظارات طبية حريمى", 21 },
                    { 126, "نظارات شمسية رجالى", 21 },
                    { 127, "نظارات شمسية حريمى", 21 },
                    { 128, "أخرى", 21 },
                    { 129, "كاميرات فيلمية", 22 },
                    { 130, "كاميرات رقمية", 22 },
                    { 131, "كاميرات مراقبة", 22 },
                    { 132, "أخرى", 22 },
                    { 133, "اقلام شفاه", 23 },
                    { 134, "طلاء الأظافر", 23 },
                    { 135, "عدسات لاصقة", 23 },
                    { 136, "مساحيق التجميل", 23 },
                    { 137, "منتجات وكريمات عناية بالبشرة", 23 },
                    { 138, "زيوت وكريمات للشعر", 23 },
                    { 139, "حنة و صبغات للشعر", 23 },
                    { 140, "كحل ومسكرة", 23 },
                    { 141, "مزيلات العرق", 23 },
                    { 142, "أخرى", 23 },
                    { 143, "عيش فينو", 24 },
                    { 144, "عيش سن", 24 },
                    { 145, "بقسماط و مقرمشات", 24 },
                    { 146, "قرص ( سادة - عجوة - ملبن )", 24 },
                    { 147, "أخرى", 24 },
                    { 148, "تورتات و جاتو", 25 },
                    { 149, "بقلاوة", 25 },
                    { 150, "هريسة و بسبوسة", 25 },
                    { 151, "كنافة", 25 },
                    { 152, "حجازية", 25 },
                    { 153, "زلابية و بلح الشام", 25 },
                    { 154, "حلويات العيد و المواسم", 25 },
                    { 155, "أخرى", 25 },
                    { 156, "سوائل و أدوات تنظيف الصحون", 26 },
                    { 157, "صابون و شامبو و شور جيل", 26 },
                    { 158, "مساحيق و سوائل تنظيف الملابس", 26 },
                    { 159, "منظفات للأرضيات و الحمام والمراحيض", 26 },
                    { 160, "معطرات جو", 26 },
                    { 161, "معطرات سجاد و أرضيات", 26 },
                    { 162, "منظفات زجاج", 26 },
                    { 163, "أخرى", 26 },
                    { 164, "دهانات للجدران والرفوف", 27 },
                    { 165, "دهانات للخشب و الشبابيك و الأبواب ", 27 },
                    { 166, "أخرى", 27 },
                    { 167, "مواتير مياه", 28 },
                    { 168, "حنفيات و قطع غيرها", 28 },
                    { 169, "مواسير و قطع غيارها", 28 },
                    { 170, "أحواض و بانيو وجاكوزى", 28 },
                    { 171, "تواليتات ومستلزمتها", 28 },
                    { 172, "سراميك و بورسلين", 28 },
                    { 173, "أخرى", 28 },
                    { 174, "عربيات ملاكى", 29 },
                    { 175, "عربيات نقل و شاحنات", 29 },
                    { 176, "وسائل مواصلات", 29 },
                    { 177, "رافعات و حفارات", 29 },
                    { 178, "أخرى", 29 },
                    { 179, "ألات ومعدات مصانع و قطع غيرها", 30 },
                    { 180, "أخرى", 30 },
                    { 181, "أسمدة كيماوية", 31 },
                    { 182, "مبيدات حشرية", 31 },
                    { 183, "بذور و محاصيل للزراعة", 31 },
                    { 184, "جرارات", 31 },
                    { 185, "معدات وأدوات زراعية", 31 },
                    { 186, "أخرى", 31 },
                    { 187, "صنارات", 32 },
                    { 188, "شبكات صيد", 32 },
                    { 189, "أطعم للصيد", 32 },
                    { 190, "أخرى", 32 },
                    { 191, "مستلزمات بناء", 33 },
                    { 192, "سماعات طبية", 34 },
                    { 193, "أجهزة قياس ضغط", 34 },
                    { 194, "أجهزة قياس سكر", 34 },
                    { 195, "أجهزة أشعة", 34 },
                    { 196, "أخرى", 34 }
                });

            migrationBuilder.InsertData(
                table: "SCities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "القاهرة" },
                    { 2, 1, "الجيزة" },
                    { 3, 1, "الأسكندرية" },
                    { 4, 1, "الدقهلية" },
                    { 5, 1, "البحر الأحمر" },
                    { 6, 1, "البحيرة" },
                    { 7, 1, "الفيوم" },
                    { 8, 1, "الغربية" },
                    { 9, 1, "الإسماعلية" },
                    { 10, 1, "المنوفية" },
                    { 11, 1, "المنيا" },
                    { 12, 1, "القليوبية" },
                    { 13, 1, "الوادي الجديد" },
                    { 14, 1, "السويس" },
                    { 15, 1, "اسوان" },
                    { 16, 1, "اسيوط" },
                    { 17, 1, "بني سويف" },
                    { 18, 1, "بورسعيد" },
                    { 19, 1, "دمياط" },
                    { 20, 1, "الشرقية" },
                    { 21, 1, "جنوب سيناء" },
                    { 22, 1, "كفر الشيخ" },
                    { 23, 1, "مطروح" },
                    { 24, 1, "الأقصر" },
                    { 25, 1, "قنا" },
                    { 26, 1, "شمال سيناء" },
                    { 27, 1, "سوهاج" }
                });

            migrationBuilder.InsertData(
                table: "SAreas",
                columns: new[] { "ID", "CityID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "15 مايو" },
                    { 2, 1, "الازبكية" },
                    { 3, 1, "البساتين" },
                    { 4, 1, "التبين" },
                    { 5, 1, "الخليفة" },
                    { 6, 1, "الدراسة" },
                    { 7, 1, "الدرب الاحمر" },
                    { 8, 1, "الزاوية الحمراء" },
                    { 9, 1, "الزيتون" },
                    { 10, 1, "الساحل" },
                    { 11, 1, "السلام" },
                    { 12, 1, "السيدة زينب" },
                    { 13, 1, "الشرابية" },
                    { 14, 1, "مدينة الشروق" },
                    { 15, 1, "الظاهر" },
                    { 16, 1, "العتبة" },
                    { 17, 1, "القاهرة الجديدة" },
                    { 18, 1, "المرج" },
                    { 19, 1, "عزبة النخل" },
                    { 20, 1, "المطرية" },
                    { 21, 1, "المعادى" },
                    { 22, 1, "المعصرة" },
                    { 23, 1, "المقطم" },
                    { 24, 1, "المنيل" },
                    { 25, 1, "الموسكى" },
                    { 26, 1, "النزهة" },
                    { 27, 1, "الوايلى" },
                    { 28, 1, "باب الشعرية" },
                    { 29, 1, "بولاق" },
                    { 30, 1, "جاردن سيتى" },
                    { 31, 1, "حدائق القبة" },
                    { 32, 1, "حلوان" },
                    { 33, 1, "دار السلام" },
                    { 34, 1, "شبرا" },
                    { 35, 1, "طره" },
                    { 36, 1, "عابدين" },
                    { 37, 1, "عباسية" },
                    { 38, 1, "عين شمس" },
                    { 39, 1, "مدينة نصر" },
                    { 40, 1, "مصر الجديدة" },
                    { 41, 1, "مصر القديمة" },
                    { 42, 1, "منشية ناصر" },
                    { 43, 1, "مدينة بدر" },
                    { 44, 1, "مدينة العبور" },
                    { 45, 1, "وسط البلد" },
                    { 46, 1, "الزمالك" },
                    { 47, 1, "قصر النيل" },
                    { 48, 1, "الرحاب" },
                    { 49, 1, "القطامية" },
                    { 50, 1, "مدينتي" },
                    { 51, 1, "روض الفرج" },
                    { 52, 1, "شيراتون" },
                    { 53, 1, "الجمالية" },
                    { 54, 1, "العاشر من رمضان" },
                    { 55, 1, "الحلمية" },
                    { 56, 1, "النزهة الجديدة" },
                    { 57, 1, "العاصمة الإدارية" },
                    { 58, 2, "الجيزة" },
                    { 59, 2, "السادس من أكتوبر" },
                    { 60, 2, "الشيخ زايد" },
                    { 61, 2, "الحوامدية" },
                    { 62, 2, "البدرشين" },
                    { 63, 2, "الصف" },
                    { 64, 2, "أطفيح" },
                    { 65, 2, "العياط" },
                    { 66, 2, "الباويطي" },
                    { 67, 2, "منشأة القناطر" },
                    { 68, 2, "أوسيم" },
                    { 69, 2, "كرداسة" },
                    { 70, 2, "أبو النمرس" },
                    { 71, 2, "كفر غطاطي" },
                    { 72, 2, "منشأة البكاري" },
                    { 73, 2, "الدقى" },
                    { 74, 2, "العجوزة" },
                    { 75, 2, "الهرم" },
                    { 76, 2, "الوراق" },
                    { 77, 2, "امبابة" },
                    { 78, 2, "بولاق الدكرور" },
                    { 79, 2, "الواحات البحرية" },
                    { 80, 2, "العمرانية" },
                    { 81, 2, "المنيب" },
                    { 82, 2, "بين السرايات" },
                    { 83, 2, "الكيت كات" },
                    { 84, 2, "المهندسين" },
                    { 85, 2, "فيصل" },
                    { 86, 2, "أبو رواش" },
                    { 87, 2, "حدائق الأهرام" },
                    { 88, 2, "الحرانية" },
                    { 89, 2, "حدائق اكتوبر" },
                    { 90, 2, "صفط اللبن" },
                    { 91, 2, "القرية الذكية" },
                    { 92, 2, "ارض اللواء" },
                    { 93, 3, "ابو قير" },
                    { 94, 3, "الابراهيمية" },
                    { 95, 3, "الأزاريطة" },
                    { 96, 3, "الانفوشى" },
                    { 97, 3, "الدخيلة" },
                    { 98, 3, "السيوف" },
                    { 99, 3, "العامرية" },
                    { 100, 3, "اللبان" },
                    { 101, 3, "المفروزة" },
                    { 102, 3, "المنتزه" },
                    { 103, 3, "المنشية" },
                    { 104, 3, "الناصرية" },
                    { 105, 3, "امبروزو" },
                    { 106, 3, "باب شرق" },
                    { 107, 3, "برج العرب" },
                    { 108, 3, "ستانلى" },
                    { 109, 3, "سموحة" },
                    { 110, 3, "سيدى بشر" },
                    { 111, 3, "شدس" },
                    { 112, 3, "غيط العنب" },
                    { 113, 3, "فلمينج" },
                    { 114, 3, "فيكتوريا" },
                    { 115, 3, "كامب شيزار" },
                    { 116, 3, "كرموز" },
                    { 117, 3, "محطة الرمل" },
                    { 118, 3, "مينا البصل" },
                    { 119, 3, "العصافرة" },
                    { 120, 3, "العجمي" },
                    { 121, 3, "بكوس" },
                    { 122, 3, "بولكلي" },
                    { 123, 3, "كليوباترا" },
                    { 124, 3, "جليم" },
                    { 125, 3, "المعمورة" },
                    { 126, 3, "المندرة" },
                    { 127, 3, "محرم بك" },
                    { 128, 3, "الشاطبي" },
                    { 129, 3, "سيدي جابر" },
                    { 130, 3, "الساحل الشمالي" },
                    { 131, 3, "الحضرة" },
                    { 132, 3, "العطارين" },
                    { 133, 3, "سيدي كرير" },
                    { 134, 3, "الجمرك" },
                    { 135, 3, "المكس" },
                    { 136, 3, "مارينا" },
                    { 137, 4, "المنصورة" },
                    { 138, 4, "طلخا" },
                    { 139, 4, "ميت غمر" },
                    { 140, 4, "دكرنس" },
                    { 141, 4, "أجا" },
                    { 142, 4, "منية النصر" },
                    { 143, 4, "السنبلاوين" },
                    { 144, 4, "الكردي" },
                    { 145, 4, "بني عبيد" },
                    { 146, 4, "المنزلة" },
                    { 147, 4, "تمي الأمديد" },
                    { 148, 4, "الجمالية" },
                    { 149, 4, "شربين" },
                    { 150, 4, "المطرية" },
                    { 151, 4, "بلقاس" },
                    { 152, 4, "ميت سلسيل" },
                    { 153, 4, "جمصة" },
                    { 154, 4, "محلة دمنة" },
                    { 155, 4, "نبروه" },
                    { 156, 5, "الغردقة" },
                    { 157, 5, "رأس غارب" },
                    { 158, 5, "سفاجا" },
                    { 159, 5, "القصير" },
                    { 160, 5, "مرسى علم" },
                    { 161, 5, "الشلاتين" },
                    { 162, 5, "حلايب" },
                    { 163, 5, "الدهار" },
                    { 164, 6, "دمنهور" },
                    { 165, 6, "كفر الدوار" },
                    { 166, 6, "رشيد" },
                    { 167, 6, "إدكو" },
                    { 168, 6, "أبو المطامير" },
                    { 169, 6, "أبو حمص" },
                    { 170, 6, "الدلنجات" },
                    { 171, 6, "المحمودية" },
                    { 172, 6, "الرحمانية" },
                    { 173, 6, "إيتاي البارود" },
                    { 174, 6, "حوش عيسى" },
                    { 175, 6, "شبراخيت" },
                    { 176, 6, "كوم حمادة" },
                    { 177, 6, "بدر" },
                    { 178, 6, "وادي النطرون" },
                    { 179, 6, "النوبارية الجديدة" },
                    { 180, 6, "النوبارية" },
                    { 181, 7, "الفيوم" },
                    { 182, 7, "الفيوم الجديدة" },
                    { 183, 7, "طامية" },
                    { 184, 7, "سنورس" },
                    { 185, 7, "إطسا" },
                    { 186, 7, "إبشواي" },
                    { 187, 7, "يوسف الصديق" },
                    { 188, 7, "الحادقة" },
                    { 189, 7, "اطسا" },
                    { 190, 7, "الجامعة" },
                    { 191, 7, "السيالة" },
                    { 192, 8, "طنطا" },
                    { 193, 8, "المحلة الكبرى" },
                    { 194, 8, "كفر الزيات" },
                    { 195, 8, "زفتى" },
                    { 196, 8, "السنطة" },
                    { 197, 8, "قطور" },
                    { 198, 8, "بسيون" },
                    { 199, 8, "سمنود" },
                    { 200, 9, "الإسماعيلية" },
                    { 201, 9, "فايد" },
                    { 202, 9, "القنطرة شرق" },
                    { 203, 9, "القنطرة غرب" },
                    { 204, 9, "التل الكبير" },
                    { 205, 9, "أبو صوير" },
                    { 206, 9, "القصاصين الجديدة" },
                    { 207, 9, "نفيشة" },
                    { 208, 9, "الشيخ زايد" },
                    { 209, 10, "شبين الكوم" },
                    { 210, 10, "مدينة السادات" },
                    { 211, 10, "منوف" },
                    { 212, 10, "سرس الليان" },
                    { 213, 10, "أشمون" },
                    { 214, 10, "الباجور" },
                    { 215, 10, "قويسنا" },
                    { 216, 10, "بركة السبع" },
                    { 217, 10, "تلا" },
                    { 218, 10, "الشهداء" },
                    { 219, 11, "المنيا" },
                    { 220, 11, "المنيا الجديدة" },
                    { 221, 11, "العدوة" },
                    { 222, 11, "مغاغة" },
                    { 223, 11, "بني مزار" },
                    { 224, 11, "مطاي" },
                    { 225, 11, "سمالوط" },
                    { 226, 11, "المدينة الفكرية" },
                    { 227, 11, "ملوي" },
                    { 228, 11, "دير مواس" },
                    { 229, 11, "ابو قرقاص" },
                    { 230, 11, "ارض سلطان" },
                    { 231, 12, "بنها" },
                    { 232, 12, "قليوب" },
                    { 233, 12, "شبرا الخيمة" },
                    { 234, 12, "القناطر الخيرية" },
                    { 235, 12, "الخانكة" },
                    { 236, 12, "كفر شكر" },
                    { 237, 12, "طوخ" },
                    { 238, 12, "قها" },
                    { 239, 12, "العبور" },
                    { 240, 12, "الخصوص" },
                    { 241, 12, "شبين القناطر" },
                    { 242, 12, "مسطرد" },
                    { 243, 13, "الخارجة" },
                    { 244, 13, "باريس" },
                    { 245, 13, "موط" },
                    { 246, 13, "الفرافرة" },
                    { 247, 13, "بلاط" },
                    { 248, 13, "الداخلة" },
                    { 249, 14, "السويس" },
                    { 250, 14, "الجناين" },
                    { 251, 14, "عتاقة" },
                    { 252, 14, "العين السخنة" },
                    { 253, 14, "فيصل" },
                    { 254, 15, "أسوان" },
                    { 255, 15, "أسوان الجديدة" },
                    { 256, 15, "دراو" },
                    { 257, 15, "كوم أمبو" },
                    { 258, 15, "نصر النوبة" },
                    { 259, 15, "كلابشة" },
                    { 260, 15, "إدفو" },
                    { 261, 15, "الرديسية" },
                    { 262, 15, "البصيلية" },
                    { 263, 15, "السباعية" },
                    { 264, 15, "ابوسمبل السياحية" },
                    { 265, 15, "مرسى علم" },
                    { 266, 16, "أسيوط" },
                    { 267, 16, "أسيوط الجديدة" },
                    { 268, 16, "ديروط" },
                    { 269, 16, "منفلوط" },
                    { 270, 16, "القوصية" },
                    { 271, 16, "أبنوب" },
                    { 272, 16, "أبو تيج" },
                    { 273, 16, "الغنايم" },
                    { 274, 16, "ساحل سليم" },
                    { 275, 16, "البداري" },
                    { 276, 16, "صدفا" },
                    { 277, 17, "بني سويف" },
                    { 278, 17, "بني سويف الجديدة" },
                    { 279, 17, "الواسطى" },
                    { 280, 17, "ناصر" },
                    { 281, 17, "إهناسيا" },
                    { 282, 17, "ببا" },
                    { 283, 17, "الفشن" },
                    { 284, 17, "سمسطا" },
                    { 285, 17, "الاباصيرى" },
                    { 286, 17, "مقبل" },
                    { 287, 18, "بورسعيد" },
                    { 288, 18, "بورفؤاد" },
                    { 289, 18, "العرب" },
                    { 290, 18, "حى الزهور" },
                    { 291, 18, "حى الشرق" },
                    { 292, 18, "حى الضواحى" },
                    { 293, 18, "حى المناخ" },
                    { 294, 18, "حى مبارك" },
                    { 295, 19, "دمياط" },
                    { 296, 19, "دمياط الجديدة" },
                    { 297, 19, "رأس البر" },
                    { 298, 19, "فارسكور" },
                    { 299, 19, "الزرقا" },
                    { 300, 19, "السرو" },
                    { 301, 19, "الروضة" },
                    { 302, 19, "كفر البطيخ" },
                    { 303, 19, "عزبة البرج" },
                    { 304, 19, "ميت أبو غالب" },
                    { 305, 19, "كفر سعد" },
                    { 306, 20, "الزقازيق" },
                    { 307, 20, "العاشر من رمضان" },
                    { 308, 20, "منيا القمح" },
                    { 309, 20, "بلبيس" },
                    { 310, 20, "مشتول السوق" },
                    { 311, 20, "القنايات" },
                    { 312, 20, "أبو حماد" },
                    { 313, 20, "القرين" },
                    { 314, 20, "ههيا" },
                    { 315, 20, "أبو كبير" },
                    { 316, 20, "فاقوس" },
                    { 317, 20, "الصالحية الجديدة" },
                    { 318, 20, "الإبراهيمية" },
                    { 319, 20, "ديرب نجم" },
                    { 320, 20, "كفر صقر" },
                    { 321, 20, "أولاد صقر" },
                    { 322, 20, "الحسينية" },
                    { 323, 20, "صان الحجر القبلية" },
                    { 324, 20, "منشأة أبو عمر" },
                    { 325, 21, "الطور" },
                    { 326, 21, "شرم الشيخ" },
                    { 327, 21, "دهب" },
                    { 328, 21, "نويبع" },
                    { 329, 21, "طابا" },
                    { 330, 21, "سانت كاترين" },
                    { 331, 21, "أبو رديس" },
                    { 332, 21, "أبو زنيمة" },
                    { 333, 21, "رأس سدر" },
                    { 334, 22, "كفر الشيخ" },
                    { 335, 22, "وسط البلد كفر الشيخ" },
                    { 336, 22, "دسوق" },
                    { 337, 22, "فوه" },
                    { 338, 22, "مطوبس" },
                    { 339, 22, "برج البرلس" },
                    { 340, 22, "بلطيم" },
                    { 341, 22, "مصيف بلطيم" },
                    { 342, 22, "الحامول" },
                    { 343, 22, "بيلا" },
                    { 344, 22, "الرياض" },
                    { 345, 22, "سيدي سالم" },
                    { 346, 22, "قلين" },
                    { 347, 22, "سيدي غازي" },
                    { 348, 23, "مرسى مطروح" },
                    { 349, 23, "الحمام" },
                    { 350, 23, "العلمين" },
                    { 351, 23, "الضبعة" },
                    { 352, 23, "النجيلة" },
                    { 353, 23, "سيدي براني" },
                    { 354, 23, "السلوم" },
                    { 355, 23, "سيوة" },
                    { 356, 23, "مارينا" },
                    { 357, 23, "الساحل الشمالى" },
                    { 358, 24, "الأقصر" },
                    { 359, 24, "الأقصر الجديدة" },
                    { 360, 24, "إسنا" },
                    { 361, 24, "طيبة الجديدة" },
                    { 362, 24, "الزينية" },
                    { 363, 24, "البياضية" },
                    { 364, 24, "القرنة" },
                    { 365, 24, "أرمنت" },
                    { 366, 24, "الطود" },
                    { 367, 25, "قنا" },
                    { 368, 25, "قنا الجديدة" },
                    { 369, 25, "ابو طشت" },
                    { 370, 25, "نجع حمادي" },
                    { 371, 25, "دشنا" },
                    { 372, 25, "الوقف" },
                    { 373, 25, "قفط" },
                    { 374, 25, "نقادة" },
                    { 375, 25, "فرشوط" },
                    { 376, 25, "قوص" },
                    { 377, 26, "العريش" },
                    { 378, 26, "الشيخ زويد" },
                    { 379, 26, "نخل" },
                    { 380, 26, "رفح" },
                    { 381, 26, "بئر العبد" },
                    { 382, 26, "الحسنة" },
                    { 383, 27, "سوهاج" },
                    { 384, 27, "سوهاج الجديدة" },
                    { 385, 27, "أخميم" },
                    { 386, 27, "أخميم الجديدة" },
                    { 387, 27, "البلينا" },
                    { 388, 27, "المراغة" },
                    { 389, 27, "المنشأة" },
                    { 390, 27, "دار السلام" },
                    { 391, 27, "جرجا" },
                    { 392, 27, "جهينة الغربية" },
                    { 393, 27, "ساقلته" },
                    { 394, 27, "طما" },
                    { 395, 27, "طهطا" },
                    { 396, 27, "الكوثر" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCategories_SCategoryID",
                table: "PCategories",
                column: "SCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ConditionID",
                table: "Products",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopID",
                table: "Products",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ShopID",
                table: "Ratings",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserID",
                table: "Ratings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SAreas_CityID",
                table: "SAreas",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_SCities_CountryID",
                table: "SCities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_AreaID",
                table: "Shops",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CategoryID",
                table: "Shops",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CityID",
                table: "Shops",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CountryID",
                table: "Shops",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserID",
                table: "Shops",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PCategories");

            migrationBuilder.DropTable(
                name: "PConditions");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "SAreas");

            migrationBuilder.DropTable(
                name: "SCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SCities");

            migrationBuilder.DropTable(
                name: "SCountries");
        }
    }
}
