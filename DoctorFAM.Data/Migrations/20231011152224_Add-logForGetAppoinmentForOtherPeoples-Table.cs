using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddlogForGetAppoinmentForOtherPeoplesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logForGetAppoinmentForOtherPeoples",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logForGetAppoinmentForOtherPeoples", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 11, 18, 52, 22, 733, DateTimeKind.Local).AddTicks(8124));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logForGetAppoinmentForOtherPeoples");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4274));
        }
    }
}
