using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddDoctorSelectedHealthCentersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorSelectedHealthCenters",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OrganizationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HealthCenterId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DoctorSelectedHealthCenterState = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSelectedHealthCenters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 842, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 52, 9, 843, DateTimeKind.Local).AddTicks(1438));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSelectedHealthCenters");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 22, 21, 185, DateTimeKind.Local).AddTicks(7325));
        }
    }
}
