using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialWorkAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorReservationType",
                table: "DoctorReservationDateTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkAddressId",
                table: "DoctorReservationDateTimes",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "WorkAddress",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkAddress_Users_UserId",
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
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 19, 6, 395, DateTimeKind.Local).AddTicks(1708));

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservationDateTimes_WorkAddressId",
                table: "DoctorReservationDateTimes",
                column: "WorkAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddress_UserId",
                table: "WorkAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddress_WorkAddressId",
                table: "DoctorReservationDateTimes",
                column: "WorkAddressId",
                principalTable: "WorkAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddress_WorkAddressId",
                table: "DoctorReservationDateTimes");

            migrationBuilder.DropTable(
                name: "WorkAddress");

            migrationBuilder.DropIndex(
                name: "IX_DoctorReservationDateTimes_WorkAddressId",
                table: "DoctorReservationDateTimes");

            migrationBuilder.DropColumn(
                name: "DoctorReservationType",
                table: "DoctorReservationDateTimes");

            migrationBuilder.DropColumn(
                name: "WorkAddressId",
                table: "DoctorReservationDateTimes");

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
        }
    }
}
