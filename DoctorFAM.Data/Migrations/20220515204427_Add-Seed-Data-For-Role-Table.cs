using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddSeedDataForRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "RoleUniqueName", "Title" },
                values: new object[] { 1m, new DateTime(2022, 5, 16, 1, 14, 26, 965, DateTimeKind.Local).AddTicks(4294), false, "Doctor", "Doctor" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "RoleUniqueName", "Title" },
                values: new object[] { 2m, new DateTime(2022, 5, 16, 1, 14, 26, 965, DateTimeKind.Local).AddTicks(4310), false, "Support", "Support" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m);
        }
    }
}
