using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddPictureFieldToTheHealthInformationmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "HealthInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8848));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "HealthInformation");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 171, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 23, 9, 57, 48, 172, DateTimeKind.Local).AddTicks(570));
        }
    }
}
