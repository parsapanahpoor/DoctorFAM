using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddCountOFFreeSMSForDoctorsFieldToDoctorInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOFFreeSMSForDoctors",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOFFreeSMSForDoctors",
                table: "DoctorsInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8809));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOFFreeSMSForDoctors",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CountOFFreeSMSForDoctors",
                table: "DoctorsInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 733, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 16, 17, 53, 58, 734, DateTimeKind.Local).AddTicks(2730));
        }
    }
}
