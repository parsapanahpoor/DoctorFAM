using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class SeedDataForCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateDate", "IsDelete", "ParentId", "UniqueName" },
                values: new object[,]
                {
                    { 1m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9622), false, null, "Cosmetics" },
                    { 2m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9639), false, null, "Medical Equipment" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.InsertData(
                table: "CategoryInfos",
                columns: new[] { "Id", "CategoryId", "CreateDate", "IsDelete", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 1m, 1m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9652), false, "fa-IR", "لوازم آرایشی بهداشتی" },
                    { 2m, 1m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9664), false, "en-US", "Cosmetics" },
                    { 3m, 1m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9675), false, "tr-TR", "Makyaj malzemeleri" },
                    { 4m, 1m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9685), false, "ar-SA", "مستحضرات التجميل" },
                    { 5m, 2m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9694), false, "ar-SA", "معدات طبية" },
                    { 6m, 2m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9706), false, "tr-TR", "Tıbbi malzeme" },
                    { 7m, 2m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9754), false, "en-US", "Medical Equipment" },
                    { 8m, 2m, new DateTime(2022, 6, 13, 11, 55, 58, 472, DateTimeKind.Local).AddTicks(9767), false, "fa-IR", "تجهیزات پزشکی" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m);

            migrationBuilder.DeleteData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 5, 30, 2, 24, 49, 448, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 5, 30, 2, 24, 49, 448, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 5, 30, 2, 24, 49, 448, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 5, 30, 2, 24, 49, 448, DateTimeKind.Local).AddTicks(2625));
        }
    }
}
