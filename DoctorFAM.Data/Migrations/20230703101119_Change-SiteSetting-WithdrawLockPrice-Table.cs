using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangeSiteSettingWithdrawLockPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WalletLockPrice",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(62));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletLockPrice",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8611));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 10, 19, 57, 131, DateTimeKind.Local).AddTicks(9668));
        }
    }
}
