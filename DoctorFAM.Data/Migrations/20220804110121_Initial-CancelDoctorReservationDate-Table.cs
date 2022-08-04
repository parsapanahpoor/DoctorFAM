using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialCancelDoctorReservationDateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelReservationRequest",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DoctorReservationDateTimeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelReservationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelReservationRequest_DoctorReservationDates_DoctorReservationDateId",
                        column: x => x.DoctorReservationDateId,
                        principalTable: "DoctorReservationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CancelReservationRequest_DoctorReservationDateTimes_DoctorReservationDateTimeId",
                        column: x => x.DoctorReservationDateTimeId,
                        principalTable: "DoctorReservationDateTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CancelReservationRequest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 930, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 15, 31, 20, 929, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.CreateIndex(
                name: "IX_CancelReservationRequest_DoctorReservationDateId",
                table: "CancelReservationRequest",
                column: "DoctorReservationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelReservationRequest_DoctorReservationDateTimeId",
                table: "CancelReservationRequest",
                column: "DoctorReservationDateTimeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CancelReservationRequest_UserId",
                table: "CancelReservationRequest",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelReservationRequest");

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
        }
    }
}
