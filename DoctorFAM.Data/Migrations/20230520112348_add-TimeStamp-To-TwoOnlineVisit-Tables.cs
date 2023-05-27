using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class addTimeStampToTwoOnlineVisitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OnlineVisitUserRequestDetails",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "OnlineVisitDoctorsAndPatientsReservationDetails",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 420, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 14, 53, 47, 421, DateTimeKind.Local).AddTicks(1227));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OnlineVisitUserRequestDetails");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "OnlineVisitDoctorsAndPatientsReservationDetails");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 12, 45, 6, 263, DateTimeKind.Local).AddTicks(3084));
        }
    }
}
