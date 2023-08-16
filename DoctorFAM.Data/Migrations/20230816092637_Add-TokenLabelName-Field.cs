using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddTokenLabelNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenLabel",
                table: "TouristTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2029));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenLabel",
                table: "TouristTokens");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 15, 11, 20, 9, 633, DateTimeKind.Local).AddTicks(2704));
        }
    }
}
