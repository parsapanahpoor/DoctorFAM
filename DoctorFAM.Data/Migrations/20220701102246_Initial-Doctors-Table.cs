using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialDoctorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsInfos_Users_UserId",
                table: "DoctorsInfos");

            migrationBuilder.DropIndex(
                name: "IX_DoctorsInfos_UserId",
                table: "DoctorsInfos");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DoctorsInfosType",
                table: "DoctorsInfos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DoctorsInfos",
                newName: "DoctorId");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DoctorsInfosType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 1, 14, 52, 45, 740, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsInfos_DoctorId",
                table: "DoctorsInfos",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsInfos_Doctors_DoctorId",
                table: "DoctorsInfos",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsInfos_Doctors_DoctorId",
                table: "DoctorsInfos");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_DoctorsInfos_DoctorId",
                table: "DoctorsInfos");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorsInfos",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorsInfosType",
                table: "DoctorsInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 30, 13, 9, 40, 190, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsInfos_UserId",
                table: "DoctorsInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsInfos_Users_UserId",
                table: "DoctorsInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
