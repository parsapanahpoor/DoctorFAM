using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddBackgroundServicesLoggersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackgroundServicesLoggers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundServicesLoggers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 13, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 9, 32, 56, 12, DateTimeKind.Local).AddTicks(9874));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackgroundServicesLoggers");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4953));
        }
    }
}
