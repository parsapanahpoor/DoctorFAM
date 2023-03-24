using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddFieldsLongEffectShortEffectToInsulinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LongEffect",
                table: "Insulins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShortEffect",
                table: "Insulins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 24, 16, 51, 59, 178, DateTimeKind.Local).AddTicks(5204));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongEffect",
                table: "Insulins");

            migrationBuilder.DropColumn(
                name: "ShortEffect",
                table: "Insulins");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5778));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 9, 49, 14, 800, DateTimeKind.Local).AddTicks(6093));
        }
    }
}
