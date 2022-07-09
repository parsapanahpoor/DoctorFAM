using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialDoctorInteresTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsSelectedInterests",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InterestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsSelectedInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorsSelectedInterests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorsSelectedInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterestInfos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    InterestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestInfos_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterestInfos_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "SystemName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreateDate", "IsDelete" },
                values: new object[,]
                {
                    { 1m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5936), false },
                    { 2m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5947), false },
                    { 3m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5957), false },
                    { 4m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5966), false }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.InsertData(
                table: "InterestInfos",
                columns: new[] { "Id", "CreateDate", "InterestId", "IsDelete", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 1m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5978), 1m, false, "fa-IR", "ویزیت آنلاین" },
                    { 2m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(5990), 1m, false, "en-US", "Online Visit" },
                    { 3m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6038), 1m, false, "tr-TR", "çevrimiçi ziyaret" },
                    { 4m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6049), 1m, false, "ar-SA", "زيارة عبر الإنترنت" },
                    { 5m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6058), 2m, false, "ar-SA", "زيارة منزلية" },
                    { 6m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6069), 2m, false, "tr-TR", "Ev ziyareti" },
                    { 7m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6078), 2m, false, "fa-IR", "ویزیت در منزل" },
                    { 8m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6087), 2m, false, "en-US", "Home Visit" },
                    { 9m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6096), 3m, false, "en-US", "Family Doctor" },
                    { 10m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6106), 3m, false, "tr-TR", "aile hekimliği" },
                    { 11m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6115), 3m, false, "ar-SA", "أطباء الأسرة" },
                    { 12m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6124), 3m, false, "fa-IR", "پزشک خانواده" },
                    { 13m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6133), 4m, false, "fa-IR", "صدور گواهی فوت" },
                    { 14m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6176), 4m, false, "en-US", "Issuance of death certificate" },
                    { 15m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6187), 4m, false, "tr-TR", "Ölüm belgesi verilmesi" },
                    { 16m, new DateTime(2022, 7, 3, 15, 53, 46, 193, DateTimeKind.Local).AddTicks(6196), 4m, false, "ar-SA", "اصدار شهادة وفاة" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsSelectedInterests_DoctorId",
                table: "DoctorsSelectedInterests",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsSelectedInterests_InterestId",
                table: "DoctorsSelectedInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestInfos_InterestId",
                table: "InterestInfos",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestInfos_LanguageId",
                table: "InterestInfos",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsSelectedInterests");

            migrationBuilder.DropTable(
                name: "InterestInfos");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 15, 51, 14, 979, DateTimeKind.Local).AddTicks(1692));
        }
    }
}
