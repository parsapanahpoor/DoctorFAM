using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialReservationDateCancelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelReservationRequest");

            migrationBuilder.CreateTable(
                name: "ReservationDateCancelations",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDateCancelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDateCancelations_DoctorReservationDates_DoctorReservationDateId",
                        column: x => x.DoctorReservationDateId,
                        principalTable: "DoctorReservationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDateTimeCancelations",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DoctorReservationDateTimeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReservationDateCancelationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDateTimeCancelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDateTimeCancelations_DoctorReservationDateTimes_DoctorReservationDateTimeId",
                        column: x => x.DoctorReservationDateTimeId,
                        principalTable: "DoctorReservationDateTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationDateTimeCancelations_ReservationDateCancelations_ReservationDateCancelationId",
                        column: x => x.ReservationDateCancelationId,
                        principalTable: "ReservationDateCancelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 7, 15, 33, 49, 662, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDateCancelations_DoctorReservationDateId",
                table: "ReservationDateCancelations",
                column: "DoctorReservationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDateTimeCancelations_DoctorReservationDateTimeId",
                table: "ReservationDateTimeCancelations",
                column: "DoctorReservationDateTimeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDateTimeCancelations_ReservationDateCancelationId",
                table: "ReservationDateTimeCancelations",
                column: "ReservationDateCancelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationDateTimeCancelations");

            migrationBuilder.DropTable(
                name: "ReservationDateCancelations");

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
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 4, 17, 50, 23, 303, DateTimeKind.Local).AddTicks(6715));

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
    }
}
