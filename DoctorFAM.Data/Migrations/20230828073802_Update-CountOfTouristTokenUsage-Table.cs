using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateCountOfTouristTokenUsageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "CountOfTouristTokenUsages",
                newName: "TouristId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 804, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 28, 11, 8, 0, 805, DateTimeKind.Local).AddTicks(1086));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TouristId",
                table: "CountOfTouristTokenUsages",
                newName: "PassengerId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 324, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 21, 10, 55, 48, 325, DateTimeKind.Local).AddTicks(584));
        }
    }
}
