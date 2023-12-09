using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class DeleteOrganizationIdFromDoctorSelectedHealthCenterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "DoctorSelectedHealthCenters");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3090));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrganizationId",
                table: "DoctorSelectedHealthCenters",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1438));
        }
    }
}
