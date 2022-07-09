using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddOpertionFieldToRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OperationId",
                table: "Requests",
                type: "decimal(20,0)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 3, 13, 42, 38, 487, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OperationId",
                table: "Requests",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_OperationId",
                table: "Requests",
                column: "OperationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_OperationId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OperationId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Requests");

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
        }
    }
}
