using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialDoctorReservationDateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorReservationDates",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReservationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReservationDates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReservationDateTimes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PatientId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    DoctorReservationState = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReservationDateTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReservationDateTimes_DoctorReservationDates_DoctorReservationDateId",
                        column: x => x.DoctorReservationDateId,
                        principalTable: "DoctorReservationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorReservationDateTimes_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 828, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 827, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 827, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 827, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 827, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 12, 14, 28, 827, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservationDates_UserId",
                table: "DoctorReservationDates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservationDateTimes_DoctorReservationDateId",
                table: "DoctorReservationDateTimes",
                column: "DoctorReservationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservationDateTimes_PatientId",
                table: "DoctorReservationDateTimes",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorReservationDateTimes");

            migrationBuilder.DropTable(
                name: "DoctorReservationDates");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 19, 11, 52, 55, 263, DateTimeKind.Local).AddTicks(7060));
        }
    }
}
