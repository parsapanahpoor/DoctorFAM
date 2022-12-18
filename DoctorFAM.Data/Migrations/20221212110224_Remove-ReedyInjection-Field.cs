using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class RemoveReedyInjectionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReedyInjection",
                table: "SiteSettings");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReedyInjection",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 11, 8, 2, 47, 949, DateTimeKind.Local).AddTicks(2025));
        }
    }
}
