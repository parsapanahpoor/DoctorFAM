using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddHealthCenterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthCenters",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCentersInfos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HealthCenterId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    GeneralPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCentersInfos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 5, 43, 46, 842, DateTimeKind.Local).AddTicks(9029));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "HealthCentersInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 11, 27, 0, 18, 21, 520, DateTimeKind.Local).AddTicks(3006));
        }
    }
}
