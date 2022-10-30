using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class CooperationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CooperationRequests",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowedUp = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CooperationRequests", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CooperationRequests");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 306, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 21, 11, 34, 40, 305, DateTimeKind.Local).AddTicks(8558));
        }
    }
}
