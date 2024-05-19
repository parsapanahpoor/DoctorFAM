using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddOrganizationStarsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationStarts",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PatientUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OrganizationStartEnum = table.Column<int>(type: "int", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStarts", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationStarts");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 12, 0, 44, 374, DateTimeKind.Local).AddTicks(6658));
        }
    }
}
