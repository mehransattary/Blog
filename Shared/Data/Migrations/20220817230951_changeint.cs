using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "settingAdvertisings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

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

          
        }
    }
}
