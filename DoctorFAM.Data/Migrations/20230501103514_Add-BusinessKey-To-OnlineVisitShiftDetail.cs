using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddBusinessKeyToOnlineVisitShiftDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "OnlineVisitWorkShiftDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "OnlineVisitWorkShiftDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BusinessKey",
                table: "OnlineVisitWorkShiftDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2321));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessKey",
                table: "OnlineVisitWorkShiftDetails");

            migrationBuilder.AlterColumn<int>(
                name: "StartTime",
                table: "OnlineVisitWorkShiftDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EndTime",
                table: "OnlineVisitWorkShiftDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 29, 15, 43, 7, 207, DateTimeKind.Local).AddTicks(7783));
        }
    }
}
