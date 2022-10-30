using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateCooperationRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CooperationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CooperationRequests");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 17, 32, 41, 897, DateTimeKind.Local).AddTicks(8134));
        }
    }
}
