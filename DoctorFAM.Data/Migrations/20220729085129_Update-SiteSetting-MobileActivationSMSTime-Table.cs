using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateSiteSettingMobileActivationSMSTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireMobileSMSDateTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendSMSTimer",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 315, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 29, 13, 21, 29, 314, DateTimeKind.Local).AddTicks(9151));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireMobileSMSDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SendSMSTimer",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 401, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 27, 14, 12, 20, 400, DateTimeKind.Local).AddTicks(9070));
        }
    }
}
