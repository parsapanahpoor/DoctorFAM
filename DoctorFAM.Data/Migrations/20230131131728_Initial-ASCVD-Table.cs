using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialASCVDTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASCVD",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: false),
                    TotalCholesterol = table.Column<int>(type: "int", nullable: false),
                    SystolicBloodPressure = table.Column<int>(type: "int", nullable: false),
                    TreatmentforHypertension = table.Column<bool>(type: "bit", nullable: false),
                    DiabetesMelitus = table.Column<bool>(type: "bit", nullable: false),
                    Smoker = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASCVD", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 31, 16, 47, 27, 667, DateTimeKind.Local).AddTicks(5867));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASCVD");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 29, 13, 2, 51, 960, DateTimeKind.Local).AddTicks(9667));
        }
    }
}
