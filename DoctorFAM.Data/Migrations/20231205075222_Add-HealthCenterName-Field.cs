using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddHealthCenterNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HealthCenterName",
                table: "HealthCentersInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.CreateIndex(
                name: "IX_HealthCentersInfos_HealthCenterId",
                table: "HealthCentersInfos",
                column: "HealthCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenters_UserId",
                table: "HealthCenters",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCenters_Users_UserId",
                table: "HealthCenters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCentersInfos_HealthCenters_HealthCenterId",
                table: "HealthCentersInfos",
                column: "HealthCenterId",
                principalTable: "HealthCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthCenters_Users_UserId",
                table: "HealthCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthCentersInfos_HealthCenters_HealthCenterId",
                table: "HealthCentersInfos");

            migrationBuilder.DropIndex(
                name: "IX_HealthCentersInfos_HealthCenterId",
                table: "HealthCentersInfos");

            migrationBuilder.DropIndex(
                name: "IX_HealthCenters_UserId",
                table: "HealthCenters");

            migrationBuilder.DropColumn(
                name: "HealthCenterName",
                table: "HealthCentersInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 29, 10, 50, 42, 638, DateTimeKind.Local).AddTicks(2504));
        }
    }
}
