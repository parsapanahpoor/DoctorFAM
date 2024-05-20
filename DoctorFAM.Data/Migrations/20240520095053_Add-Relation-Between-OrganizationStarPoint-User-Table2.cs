using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddRelationBetweenOrganizationStarPointUserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizationStarPoints_OperatorUserId",
                table: "OrganizationStarPoints");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStarPoints_OperatorUserId",
                table: "OrganizationStarPoints",
                column: "OperatorUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizationStarPoints_OperatorUserId",
                table: "OrganizationStarPoints");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5543));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 5, 48, 584, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStarPoints_OperatorUserId",
                table: "OrganizationStarPoints",
                column: "OperatorUserId");
        }
    }
}
