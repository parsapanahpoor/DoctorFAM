using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntitialWorkingAddressResumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingAddressResume",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    WorkingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingAddressTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Days = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Times = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingAddressResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingAddressResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 37, 22, 772, DateTimeKind.Local).AddTicks(6826));

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAddressResume_ResumeId",
                table: "WorkingAddressResume",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingAddressResume");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 4, 10, 26, 33, 387, DateTimeKind.Local).AddTicks(1417));
        }
    }
}
