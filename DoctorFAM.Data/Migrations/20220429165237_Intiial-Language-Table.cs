using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntiialLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    SystemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.SystemName);
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "en-US", true, "English" });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "fa-IR", true, "فارسی" });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "ru-RU", true, "Russian" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
