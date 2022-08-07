using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialReservationDateCancelationTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorReservationDateId",
                table: "ReservationDateTimeCancelations");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 46, 37, 72, DateTimeKind.Local).AddTicks(443));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DoctorReservationDateId",
                table: "ReservationDateTimeCancelations",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2925));
        }
    }
}
