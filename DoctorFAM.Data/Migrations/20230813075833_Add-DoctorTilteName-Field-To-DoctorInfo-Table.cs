using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddDoctorTilteNameFieldToDoctorInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorTilteName",
                table: "DoctorsInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 13, 11, 28, 32, 439, DateTimeKind.Local).AddTicks(2641));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorTilteName",
                table: "DoctorsInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 6, 9, 36, 49, 707, DateTimeKind.Local).AddTicks(2694));
        }
    }
}
