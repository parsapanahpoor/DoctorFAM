using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdatePopulationCoveredTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PopulationCovered_Requests_RequestId",
                table: "PopulationCovered");

            migrationBuilder.DropIndex(
                name: "IX_PopulationCovered_RequestId",
                table: "PopulationCovered");

            migrationBuilder.DropColumn(
                name: "RequestDescription",
                table: "PopulationCovered");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "PopulationCovered");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 28, 1, 153, DateTimeKind.Local).AddTicks(3484));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestDescription",
                table: "PopulationCovered",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RequestId",
                table: "PopulationCovered",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 6, 22, 22, 23, 50, 827, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.CreateIndex(
                name: "IX_PopulationCovered_RequestId",
                table: "PopulationCovered",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PopulationCovered_Requests_RequestId",
                table: "PopulationCovered",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
