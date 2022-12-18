using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialRequestSelectedHealthHouseTarifftable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressureMeasurement",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "DermalOrSubcutaneousInjection",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "ECG",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "GastricIntubation",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "Glucometry",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "GreatDressing",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "IntramuscularInjection",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "OxygenTherapy",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "PulseOximetry",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "ReedyInjection",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "SerumTherapy",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "SmallDressing",
                table: "HomeVisitRequestDetails");

            migrationBuilder.DropColumn(
                name: "UrinaryBladder",
                table: "HomeVisitRequestDetails");

            migrationBuilder.CreateTable(
                name: "RequestSelectedHealthHouseTariff",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TariffForHealthHouseServiceId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSelectedHealthHouseTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestSelectedHealthHouseTariff_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSelectedHealthHouseTariff_TariffForHealthHouseServices_TariffForHealthHouseServiceId",
                        column: x => x.TariffForHealthHouseServiceId,
                        principalTable: "TariffForHealthHouseServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 17, 42, 31, 703, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelectedHealthHouseTariff_RequestId",
                table: "RequestSelectedHealthHouseTariff",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSelectedHealthHouseTariff_TariffForHealthHouseServiceId",
                table: "RequestSelectedHealthHouseTariff",
                column: "TariffForHealthHouseServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSelectedHealthHouseTariff");

            migrationBuilder.AddColumn<bool>(
                name: "BloodPressureMeasurement",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DermalOrSubcutaneousInjection",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ECG",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GastricIntubation",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Glucometry",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GreatDressing",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IntramuscularInjection",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OxygenTherapy",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PulseOximetry",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReedyInjection",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SerumTherapy",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SmallDressing",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UrinaryBladder",
                table: "HomeVisitRequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 982, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 12, 15, 7, 3, 981, DateTimeKind.Local).AddTicks(9770));
        }
    }
}
