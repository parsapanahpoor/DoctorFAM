using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateDiabetPopulationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "DiabetPopulation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "DiabetPopulation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 12, 28, 4, 307, DateTimeKind.Local).AddTicks(6807));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "DiabetPopulation");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "DiabetPopulation");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9200));
        }
    }
}
