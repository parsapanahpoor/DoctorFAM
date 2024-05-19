using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddOrganizationStarPointTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationStarPoints",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PointValue = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStarPoints", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5647));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationStarPoints");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 5, 14, 470, DateTimeKind.Local).AddTicks(8977));
        }
    }
}
