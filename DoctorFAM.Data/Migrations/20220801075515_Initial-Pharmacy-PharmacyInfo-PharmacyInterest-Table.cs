using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialPharmacyPharmacyInfoPharmacyInterestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacies",
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
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInterests",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInfos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    NationalCode = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyInfos_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInterestInfos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    InterestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInterestInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyInterestInfos_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "SystemName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyInterestInfos_PharmacyInterests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "PharmacyInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacySelectedInterests",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InterestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacySelectedInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacySelectedInterests_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacySelectedInterests_PharmacyInterests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "PharmacyInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.InsertData(
                table: "PharmacyInterests",
                columns: new[] { "Id", "CreateDate", "IsDelete" },
                values: new object[] { 1m, new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(63), false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 216, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.InsertData(
                table: "PharmacyInterestInfos",
                columns: new[] { "Id", "CreateDate", "InterestId", "IsDelete", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 1m, new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(82), 1m, false, "fa-IR", "داروخانه در منزل" },
                    { 2m, new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(96), 1m, false, "tr-TR", "evde eczane" },
                    { 3m, new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(107), 1m, false, "ar-SA", "صيدلية في المنزل" },
                    { 4m, new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(117), 1m, false, "en-US", "Pharmacy at home" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_UserId",
                table: "Pharmacies",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyInfos_PharmacyId",
                table: "PharmacyInfos",
                column: "PharmacyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyInterestInfos_InterestId",
                table: "PharmacyInterestInfos",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyInterestInfos_LanguageId",
                table: "PharmacyInterestInfos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacySelectedInterests_InterestId",
                table: "PharmacySelectedInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacySelectedInterests_PharmacyId",
                table: "PharmacySelectedInterests",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyInfos");

            migrationBuilder.DropTable(
                name: "PharmacyInterestInfos");

            migrationBuilder.DropTable(
                name: "PharmacySelectedInterests");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyInterests");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 10, 38, 16, 375, DateTimeKind.Local).AddTicks(830));
        }
    }
}
