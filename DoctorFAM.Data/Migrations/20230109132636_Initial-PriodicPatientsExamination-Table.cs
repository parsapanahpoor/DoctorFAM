using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialPriodicPatientsExaminationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriodicPatientsExamination",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MedicalExaminationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LastPatientMedicalExamination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriodicPatientsExamination", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 16, 56, 35, 185, DateTimeKind.Local).AddTicks(5677));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriodicPatientsExamination");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 9, 13, 31, 40, 640, DateTimeKind.Local).AddTicks(4668));
        }
    }
}
