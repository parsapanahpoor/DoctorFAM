using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateParsaSystemExcelFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAnyFamilyDoctor",
                table: "UserInsertedFromParsaSystems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 18, 17, 36, 14, 867, DateTimeKind.Local).AddTicks(7898));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAnyFamilyDoctor",
                table: "UserInsertedFromParsaSystems");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 17, 17, 0, 31, 501, DateTimeKind.Local).AddTicks(5092));
        }
    }
}
