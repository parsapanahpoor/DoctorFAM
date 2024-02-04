using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddVideoFileForStoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoFile",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 2, 3, 14, 33, 19, 733, DateTimeKind.Local).AddTicks(7127));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "VideoFile",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 1, 30, 16, 37, 18, 444, DateTimeKind.Local).AddTicks(5747));
        }
    }
}
