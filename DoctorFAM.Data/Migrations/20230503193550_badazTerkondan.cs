using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class badazTerkondan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OnlineVisitWorkShiftId",
                table: "OnlineVisitDoctorsAndPatientsReservationDetails",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6103));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 23, 5, 49, 405, DateTimeKind.Local).AddTicks(6031));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineVisitWorkShiftId",
                table: "OnlineVisitDoctorsAndPatientsReservationDetails");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 765, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 3, 12, 39, 57, 766, DateTimeKind.Local).AddTicks(3426));
        }
    }
}
