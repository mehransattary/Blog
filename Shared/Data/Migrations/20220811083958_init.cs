using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseView",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count_Views = table.Column<int>(type: "int", nullable: false),
                    DateTime_Views = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP_Views = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsMobile_Views = table.Column<bool>(type: "bit", nullable: false),
                    Browser_Views = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Tellphone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Linkdin = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Learn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "settingAdvertisings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_Advertising_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_href_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_alt_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_title_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settingAdvertisings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_Sitename = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Settings_Questions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_HelperSell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Settings_Tell = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Settings_Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Settings_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Settings_ImageFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_ImageTopMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsCopyRights",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_Tarah_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_Tarah_Href = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_Tarah_FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_Tarah_Logo_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Tarah_Logo_Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_Tarah_Logo_alt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsCopyRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsEnemads",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_Image_Enemad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Title_Enemad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Settings_href_Enemad = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Settings_IsExist_Enemad = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsEnemads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsLogos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_Image_Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Image_Logo_Footer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_alt_Logo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_title_Logo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Settings_Icon_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsLogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsMetas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Settings_keywords = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_description = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_canonical = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_author = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_ogtitle = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    Settings_ogdescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_ogimage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_ogurl = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_ogsite_name = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    Settings_twitter_title = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    Settings_twitter_description = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Settings_twitter_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Search_Console = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Google_Analytics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Service_Adver_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Service_Adver_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Service_Adver_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings_Service_Adver_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsMetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontAwseome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "webLog_Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_Category_Title_One = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Category_Title_Two = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Category_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Category_ThumbnaillImage = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Category_ImageHome = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Category_Order = table.Column<short>(type: "smallint", nullable: true),
                    WebLog_Category_IsShow = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Category_ShortDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WebLog_Category_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebLog_Category_ShortLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Title_Meta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TitleEnglish_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc_Meta = table.Column<string>(type: "nvarchar(185)", maxLength: 185, nullable: false),
                    Canonical_Meta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Keyword_Meta = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Image_Meta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webLog_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Labels",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_Label_Title_One = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Label_Title_Two = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Label_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Label_ThumbnaillImage = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Label_ImageHome = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Label_Order = table.Column<short>(type: "smallint", nullable: true),
                    WebLog_Label_IsShow = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Label_ShortDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WebLog_Label_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebLog_Label_ShortLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Title_Meta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TitleEnglish_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc_Meta = table.Column<string>(type: "nvarchar(185)", maxLength: 185, nullable: false),
                    Canonical_Meta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Keyword_Meta = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Image_Meta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_SelectedBlogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_BlogId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebLog_Orddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_SelectedBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Category_Views",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewId = table.Column<int>(type: "int", nullable: false),
                    WebLog_CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Category_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Category_Views_BaseView_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "dbo",
                        principalTable: "BaseView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Category_Views_webLog_Categories_WebLog_CategoryId",
                        column: x => x.WebLog_CategoryId,
                        principalSchema: "dbo",
                        principalTable: "webLog_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Groups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_Group_Title_One = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Group_Title_Two = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebLog_Group_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Group_ThumbnaillImage = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Group_ImageHome = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Group_Order = table.Column<short>(type: "smallint", nullable: true),
                    WebLog_Group_IsShow = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Group_ShortDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WebLog_Group_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebLog_Group_ShortLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WebLog_Group_CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Title_Meta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TitleEnglish_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc_Meta = table.Column<string>(type: "nvarchar(185)", maxLength: 185, nullable: false),
                    Canonical_Meta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Keyword_Meta = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Image_Meta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Groups_webLog_Categories_WebLog_Group_CategoryId",
                        column: x => x.WebLog_Group_CategoryId,
                        principalSchema: "dbo",
                        principalTable: "webLog_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Label_Views",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewId = table.Column<int>(type: "int", nullable: false),
                    WebLog_LabelId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Label_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Label_Views_BaseView_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "dbo",
                        principalTable: "BaseView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Label_Views_WebLog_Labels_WebLog_LabelId",
                        column: x => x.WebLog_LabelId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Group_Views",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewId = table.Column<int>(type: "int", nullable: false),
                    WebLog_GroupId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Group_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Group_Views_BaseView_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "dbo",
                        principalTable: "BaseView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Group_Views_WebLog_Groups_WebLog_GroupId",
                        column: x => x.WebLog_GroupId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weblogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weblog_Title_One = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Weblog_Title_Two = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Weblog_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    Weblog_Thumbnail_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    Weblog_Short_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Weblog_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weblog_Writer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Weblog_IsShow = table.Column<bool>(type: "bit", nullable: false),
                    Weblog_GroupId = table.Column<int>(type: "int", nullable: false),
                    Weblog_StudyTime = table.Column<int>(type: "int", nullable: false),
                    Weblog_Star = table.Column<int>(type: "int", nullable: false),
                    Weblog_ShortLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Title_Meta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TitleEnglish_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url_Meta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc_Meta = table.Column<string>(type: "nvarchar(185)", maxLength: 185, nullable: false),
                    Canonical_Meta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Keyword_Meta = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Image_Meta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weblogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weblogs_WebLog_Groups_Weblog_GroupId",
                        column: x => x.Weblog_GroupId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "webLog_Comments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeblogId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Comment_UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Comment_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment_IsShow = table.Column<bool>(type: "bit", nullable: false),
                    Comment_OkAnswer = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webLog_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_webLog_Comments_Weblogs_WeblogId",
                        column: x => x.WeblogId,
                        principalSchema: "dbo",
                        principalTable: "Weblogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_ImageAdvertises",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_ImageAdvertise_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebLog_ImageAdvertise_CategoryId = table.Column<int>(type: "int", nullable: false),
                    WebLog_ImageAdvertise_Category_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_GroupId = table.Column<int>(type: "int", nullable: false),
                    WebLog_ImageAdvertise_Group_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_BlogId = table.Column<int>(type: "int", nullable: false),
                    WebLog_ImageAdvertise_Blog_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_LabelId = table.Column<int>(type: "int", nullable: false),
                    WebLog_ImageAdvertise_Label_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_Link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebLog_ImageAdvertise_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_ImageAdvertise_Order = table.Column<int>(type: "int", nullable: false),
                    WebLog_ImageAdvertise_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_IsActive_TopPage = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_IsActive_MiddlePage = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_IsActive_BottomPage = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_ImageAdvertise_HtmlRaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_ImageAdvertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_ImageAdvertises_webLog_Categories_WebLog_ImageAdvertise_CategoryId",
                        column: x => x.WebLog_ImageAdvertise_CategoryId,
                        principalSchema: "dbo",
                        principalTable: "webLog_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_ImageAdvertises_WebLog_Groups_WebLog_ImageAdvertise_GroupId",
                        column: x => x.WebLog_ImageAdvertise_GroupId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_ImageAdvertises_WebLog_Labels_WebLog_ImageAdvertise_LabelId",
                        column: x => x.WebLog_ImageAdvertise_LabelId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_ImageAdvertises_Weblogs_WebLog_ImageAdvertise_BlogId",
                        column: x => x.WebLog_ImageAdvertise_BlogId,
                        principalSchema: "dbo",
                        principalTable: "Weblogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Label_Blogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeblogId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Label_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Label_Blogs_WebLog_Labels_LabelId",
                        column: x => x.LabelId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Label_Blogs_Weblogs_WeblogId",
                        column: x => x.WeblogId,
                        principalSchema: "dbo",
                        principalTable: "Weblogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Sliders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLog_Slider_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebLog_Slider_CategoryId = table.Column<int>(type: "int", nullable: false),
                    WebLog_Slider_Category_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_GroupId = table.Column<int>(type: "int", nullable: false),
                    WebLog_Slider_Group_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_BlogId = table.Column<int>(type: "int", nullable: false),
                    WebLog_Slider_Blog_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_LabelId = table.Column<int>(type: "int", nullable: false),
                    WebLog_Slider_Label_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_Link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebLog_Slider_Image = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    WebLog_Slider_Order = table.Column<int>(type: "int", nullable: false),
                    WebLog_Slider_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_IsActive_TopPage = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_IsActive_MiddlePage = table.Column<bool>(type: "bit", nullable: false),
                    WebLog_Slider_IsActive_BottomPage = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Sliders_webLog_Categories_WebLog_Slider_CategoryId",
                        column: x => x.WebLog_Slider_CategoryId,
                        principalSchema: "dbo",
                        principalTable: "webLog_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Sliders_WebLog_Groups_WebLog_Slider_GroupId",
                        column: x => x.WebLog_Slider_GroupId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Sliders_WebLog_Labels_WebLog_Slider_LabelId",
                        column: x => x.WebLog_Slider_LabelId,
                        principalSchema: "dbo",
                        principalTable: "WebLog_Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Sliders_Weblogs_WebLog_Slider_BlogId",
                        column: x => x.WebLog_Slider_BlogId,
                        principalSchema: "dbo",
                        principalTable: "Weblogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebLog_Views",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewId = table.Column<int>(type: "int", nullable: false),
                    WebLogId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLog_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebLog_Views_BaseView_ViewId",
                        column: x => x.ViewId,
                        principalSchema: "dbo",
                        principalTable: "BaseView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebLog_Views_Weblogs_WebLogId",
                        column: x => x.WebLogId,
                        principalSchema: "dbo",
                        principalTable: "Weblogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Category_Views_ViewId",
                schema: "dbo",
                table: "WebLog_Category_Views",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Category_Views_WebLog_CategoryId",
                schema: "dbo",
                table: "WebLog_Category_Views",
                column: "WebLog_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_webLog_Comments_WeblogId",
                schema: "dbo",
                table: "webLog_Comments",
                column: "WeblogId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Group_Views_ViewId",
                schema: "dbo",
                table: "WebLog_Group_Views",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Group_Views_WebLog_GroupId",
                schema: "dbo",
                table: "WebLog_Group_Views",
                column: "WebLog_GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Groups_WebLog_Group_CategoryId",
                schema: "dbo",
                table: "WebLog_Groups",
                column: "WebLog_Group_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_ImageAdvertises_WebLog_ImageAdvertise_BlogId",
                schema: "dbo",
                table: "WebLog_ImageAdvertises",
                column: "WebLog_ImageAdvertise_BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_ImageAdvertises_WebLog_ImageAdvertise_CategoryId",
                schema: "dbo",
                table: "WebLog_ImageAdvertises",
                column: "WebLog_ImageAdvertise_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_ImageAdvertises_WebLog_ImageAdvertise_GroupId",
                schema: "dbo",
                table: "WebLog_ImageAdvertises",
                column: "WebLog_ImageAdvertise_GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_ImageAdvertises_WebLog_ImageAdvertise_LabelId",
                schema: "dbo",
                table: "WebLog_ImageAdvertises",
                column: "WebLog_ImageAdvertise_LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Label_Blogs_LabelId",
                schema: "dbo",
                table: "WebLog_Label_Blogs",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Label_Blogs_WeblogId",
                schema: "dbo",
                table: "WebLog_Label_Blogs",
                column: "WeblogId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Label_Views_ViewId",
                schema: "dbo",
                table: "WebLog_Label_Views",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Label_Views_WebLog_LabelId",
                schema: "dbo",
                table: "WebLog_Label_Views",
                column: "WebLog_LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Sliders_WebLog_Slider_BlogId",
                schema: "dbo",
                table: "WebLog_Sliders",
                column: "WebLog_Slider_BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Sliders_WebLog_Slider_CategoryId",
                schema: "dbo",
                table: "WebLog_Sliders",
                column: "WebLog_Slider_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Sliders_WebLog_Slider_GroupId",
                schema: "dbo",
                table: "WebLog_Sliders",
                column: "WebLog_Slider_GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Sliders_WebLog_Slider_LabelId",
                schema: "dbo",
                table: "WebLog_Sliders",
                column: "WebLog_Slider_LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Views_ViewId",
                schema: "dbo",
                table: "WebLog_Views",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLog_Views_WebLogId",
                schema: "dbo",
                table: "WebLog_Views",
                column: "WebLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Weblogs_Weblog_GroupId",
                schema: "dbo",
                table: "Weblogs",
                column: "Weblog_GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "People",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "settingAdvertisings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingsCopyRights",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingsEnemads",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingsLogos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingsMetas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Socials",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Category_Views",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "webLog_Comments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Group_Views",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_ImageAdvertises",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Label_Blogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Label_Views",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_SelectedBlogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Sliders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Views",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Labels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BaseView",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Weblogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebLog_Groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "webLog_Categories",
                schema: "dbo");
        }
    }
}
