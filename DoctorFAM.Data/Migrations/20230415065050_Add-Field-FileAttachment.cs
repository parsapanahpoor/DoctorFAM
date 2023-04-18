using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddFieldFileAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileAttach",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 602, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 15, 10, 20, 49, 603, DateTimeKind.Local).AddTicks(1120));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileAttach",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 8, 11, 42, 10, 240, DateTimeKind.Local).AddTicks(6740));
        }
    }
}
