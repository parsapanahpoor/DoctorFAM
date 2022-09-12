using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialUserSeletedFamilyDoctorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSelectedFamilyDoctor",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PatientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RejectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyDoctorRequestState = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectedFamilyDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSelectedFamilyDoctor_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSelectedFamilyDoctor_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8611));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 10, 11, 21, 47, 382, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectedFamilyDoctor_DoctorId",
                table: "UserSelectedFamilyDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelectedFamilyDoctor_PatientId",
                table: "UserSelectedFamilyDoctor",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSelectedFamilyDoctor");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 27, 16, 27, 50, 954, DateTimeKind.Local).AddTicks(3643));
        }
    }
}
