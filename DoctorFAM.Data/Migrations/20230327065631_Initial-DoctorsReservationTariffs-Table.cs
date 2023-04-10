using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialDoctorsReservationTariffsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorsReservationTariffs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InPersonReservationTariffForDoctorPopulationCovered = table.Column<int>(type: "int", nullable: false),
                    OnlineReservationTariffForDoctorPopulationCovered = table.Column<int>(type: "int", nullable: false),
                    InPersonReservationTariffForAnonymousPersons = table.Column<int>(type: "int", nullable: false),
                    OnlineReservationTariffForAnonymousPersons = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsReservationTariffs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 916, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 27, 10, 26, 29, 917, DateTimeKind.Local).AddTicks(747));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsReservationTariffs");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 489, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 25, 10, 1, 47, 490, DateTimeKind.Local).AddTicks(1748));
        }
    }
}
