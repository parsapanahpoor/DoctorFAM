using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class BeforeAddInsuranceTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
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
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 30, 39, 940, DateTimeKind.Local).AddTicks(7736));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 2, 10, 21, 24, 11, 761, DateTimeKind.Local).AddTicks(9331));
        }
    }
}
