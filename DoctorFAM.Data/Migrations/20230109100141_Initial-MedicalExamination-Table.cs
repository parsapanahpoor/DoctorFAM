using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialMedicalExaminationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalExaminations",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalExaminationName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PriodMonth = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminations", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalExaminations");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3297));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 848, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 6, 12, 4, 26, 849, DateTimeKind.Local).AddTicks(2891));
        }
    }
}
