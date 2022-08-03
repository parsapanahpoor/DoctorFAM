using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateRelationBetweenRequestAndRequestDateTimeDetailTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientRequestDateTimeDetails_RequestId",
                table: "PatientRequestDateTimeDetails");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 3, 18, 32, 32, 323, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.CreateIndex(
                name: "IX_PatientRequestDateTimeDetails_RequestId",
                table: "PatientRequestDateTimeDetails",
                column: "RequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientRequestDateTimeDetails_RequestId",
                table: "PatientRequestDateTimeDetails");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5554));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 16, 30, 52, 314, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.CreateIndex(
                name: "IX_PatientRequestDateTimeDetails_RequestId",
                table: "PatientRequestDateTimeDetails",
                column: "RequestId");
        }
    }
}
