using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateSiteSettingForSiteAddressDomainField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteDomain",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 16, 15, 28, 45, 749, DateTimeKind.Local).AddTicks(6439));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteDomain",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8611));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7382));
        }
    }
}
