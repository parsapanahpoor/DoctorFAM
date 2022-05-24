using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddSeedDataForRoleTableAdminRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                columns: new[] { "CreateDate", "RoleUniqueName", "Title" },
                values: new object[] { new DateTime(2022, 5, 16, 1, 18, 16, 302, DateTimeKind.Local).AddTicks(6929), "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                columns: new[] { "CreateDate", "RoleUniqueName", "Title" },
                values: new object[] { new DateTime(2022, 5, 16, 1, 18, 16, 302, DateTimeKind.Local).AddTicks(6949), "Doctor", "Doctor" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "RoleUniqueName", "Title" },
                values: new object[] { 3m, new DateTime(2022, 5, 16, 1, 18, 16, 302, DateTimeKind.Local).AddTicks(6964), false, "Support", "Support" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                columns: new[] { "CreateDate", "RoleUniqueName", "Title" },
                values: new object[] { new DateTime(2022, 5, 16, 1, 14, 26, 965, DateTimeKind.Local).AddTicks(4294), "Doctor", "Doctor" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                columns: new[] { "CreateDate", "RoleUniqueName", "Title" },
                values: new object[] { new DateTime(2022, 5, 16, 1, 14, 26, 965, DateTimeKind.Local).AddTicks(4310), "Support", "Support" });
        }
    }
}
