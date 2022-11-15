using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntitialDoctorPersonalBookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorPersonalBooking",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateTimeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPersonalBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorPersonalBooking_DoctorReservationDateTimes_DoctorReservationDateTimeId",
                        column: x => x.DoctorReservationDateTimeId,
                        principalTable: "DoctorReservationDateTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 13, 8, 9, 0, 127, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPersonalBooking_DoctorReservationDateTimeId",
                table: "DoctorPersonalBooking",
                column: "DoctorReservationDateTimeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPersonalBooking");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 17, 47, 44, 793, DateTimeKind.Local).AddTicks(3384));
        }
    }
}
