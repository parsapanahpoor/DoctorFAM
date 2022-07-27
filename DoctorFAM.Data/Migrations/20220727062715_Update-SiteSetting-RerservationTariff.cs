using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateSiteSettingRerservationTariff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationTarrif",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 10, 57, 14, 675, DateTimeKind.Local).AddTicks(880));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationTarrif",
                table: "SiteSettings");

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
    }
}
