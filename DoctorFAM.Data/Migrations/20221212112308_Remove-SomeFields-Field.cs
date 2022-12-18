using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class RemoveSomeFieldsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressureMeasurement",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "DermalOrSubcutaneousInjection",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ECG",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "GastricIntubation",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "Glucometry",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "GreatDressing",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "IntramuscularInjection",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "OxygenTherapy",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "PulseOximetry",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SerumTherapy",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmallDressing",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "UrinaryBladder",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 71, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 53, 8, 70, DateTimeKind.Local).AddTicks(8598));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodPressureMeasurement",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DermalOrSubcutaneousInjection",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ECG",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GastricIntubation",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Glucometry",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GreatDressing",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntramuscularInjection",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OxygenTherapy",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PulseOximetry",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerumTherapy",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SmallDressing",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UrinaryBladder",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 14, 32, 23, 249, DateTimeKind.Local).AddTicks(2087));
        }
    }
}
