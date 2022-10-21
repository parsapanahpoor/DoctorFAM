using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialTableForLogSMSSenderFromDoctorToUsersThatIncomesFromParsaSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogForSendSMSToUsersIncomeFromParsa",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ParsaUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SMSBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogForSendSMSToUsersIncomeFromParsa", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogForSendSMSToUsersIncomeFromParsa");

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
    }
}
