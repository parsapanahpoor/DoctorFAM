using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddInsulinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insulins",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsulinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulins", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(948));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 468, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 9, 53, 24, 469, DateTimeKind.Local).AddTicks(1961));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insulins");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 16, 31, 26, 451, DateTimeKind.Local).AddTicks(6133));
        }
    }
}
