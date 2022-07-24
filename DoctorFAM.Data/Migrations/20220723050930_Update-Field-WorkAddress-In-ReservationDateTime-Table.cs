using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateFieldWorkAddressInReservationDateTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WorkAddressId",
                table: "DoctorReservationDateTimes",
                type: "decimal(20,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 23, 9, 39, 30, 23, DateTimeKind.Local).AddTicks(5618));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WorkAddressId",
                table: "DoctorReservationDateTimes",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 22, 19, 45, 37, 237, DateTimeKind.Local).AddTicks(7773));
        }
    }
}
