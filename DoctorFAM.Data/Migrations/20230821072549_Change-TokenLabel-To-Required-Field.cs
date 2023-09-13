using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangeTokenLabelToRequiredField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TokenLabel",
                table: "TouristTokens",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TokenLabel",
                table: "TouristTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4796));
        }
    }
}
