using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddImageToHealthCenterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HealthCenterImage",
                table: "HealthCentersInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2504));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthCenterImage",
                table: "HealthCentersInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9029));
        }
    }
}
