using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangeLogForGetAppoinmentForOtherPeopleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ReservationDateTimeId",
                table: "logForGetAppoinmentForOtherPeoples",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 19, 7, 33, 888, DateTimeKind.Local).AddTicks(2341));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDateTimeId",
                table: "logForGetAppoinmentForOtherPeoples");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8124));
        }
    }
}
