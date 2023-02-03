using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdatePeriodicExaminationLabelNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LabelName",
                table: "PriodicPatientsExamination",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 14, 3, 20, 648, DateTimeKind.Local).AddTicks(5019));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabelName",
                table: "PriodicPatientsExamination");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 573, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 3, 11, 59, 20, 574, DateTimeKind.Local).AddTicks(913));
        }
    }
}
