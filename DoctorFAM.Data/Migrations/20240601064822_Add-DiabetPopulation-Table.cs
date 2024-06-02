using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddDiabetPopulationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiabetPopulation",
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
                    table.PrimaryKey("PK_DiabetPopulation", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 10, 18, 20, 630, DateTimeKind.Local).AddTicks(9200));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiabetPopulation");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 13, 20, 51, 829, DateTimeKind.Local).AddTicks(3653));
        }
    }
}
