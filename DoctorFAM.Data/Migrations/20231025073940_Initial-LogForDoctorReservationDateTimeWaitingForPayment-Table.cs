using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialLogForDoctorReservationDateTimeWaitingForPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogForDoctorReservationDateTimeWaitingForPaymentComments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LogForDoctorReservationDateTimeWaitingForPaymentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogForDoctorReservationDateTimeWaitingForPaymentComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogForDoctorReservationDateTimeWaitingForPayments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorReservationDateTimeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PatientUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SupporterUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    IsSeenBySupporters = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogForDoctorReservationDateTimeWaitingForPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogForDoctorReservationDateTimeWaitingForPayments_DoctorReservationDateTimes_DoctorReservationDateTimeId",
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
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9699));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 739, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 25, 11, 9, 38, 740, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.CreateIndex(
                name: "IX_LogForDoctorReservationDateTimeWaitingForPayments_DoctorReservationDateTimeId",
                table: "LogForDoctorReservationDateTimeWaitingForPayments",
                column: "DoctorReservationDateTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogForDoctorReservationDateTimeWaitingForPaymentComments");

            migrationBuilder.DropTable(
                name: "LogForDoctorReservationDateTimeWaitingForPayments");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 21, 15, 10, 18, 244, DateTimeKind.Local).AddTicks(8482));
        }
    }
}
