using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialDiabetRiskFactorQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiabetRiskFactorQuestions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiabetRiskFactorQuestions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 52, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 15, 8, 30, 16, 51, DateTimeKind.Local).AddTicks(9875));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiabetRiskFactorQuestions");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 1, 14, 15, 2, 7, 212, DateTimeKind.Local).AddTicks(6796));
        }
    }
}
