using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialWorkAddressTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddress_WorkAddressId",
                table: "DoctorReservationDateTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddress_Users_UserId",
                table: "WorkAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkAddress",
                table: "WorkAddress");

            migrationBuilder.RenameTable(
                name: "WorkAddress",
                newName: "WorkAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_WorkAddress_UserId",
                table: "WorkAddresses",
                newName: "IX_WorkAddresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkAddresses",
                table: "WorkAddresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 7, 21, 9, 57, 59, 651, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddresses_WorkAddressId",
                table: "DoctorReservationDateTimes",
                column: "WorkAddressId",
                principalTable: "WorkAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Users_UserId",
                table: "WorkAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddresses_WorkAddressId",
                table: "DoctorReservationDateTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Users_UserId",
                table: "WorkAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkAddresses",
                table: "WorkAddresses");

            migrationBuilder.RenameTable(
                name: "WorkAddresses",
                newName: "WorkAddress");

            migrationBuilder.RenameIndex(
                name: "IX_WorkAddresses_UserId",
                table: "WorkAddress",
                newName: "IX_WorkAddress_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkAddress",
                table: "WorkAddress",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReservationDateTimes_WorkAddress_WorkAddressId",
                table: "DoctorReservationDateTimes",
                column: "WorkAddressId",
                principalTable: "WorkAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddress_Users_UserId",
                table: "WorkAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
