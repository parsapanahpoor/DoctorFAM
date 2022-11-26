using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntitialHealthInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthInformation",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthInformationType = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowInSite = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDoctorPanel = table.Column<bool>(type: "bit", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShowInfinity = table.Column<bool>(type: "bit", nullable: false),
                    RejectNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInformation_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthInformationTags",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInformationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TagTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInformationTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInformationTags_HealthInformation_HealthInformationId",
                        column: x => x.HealthInformationId,
                        principalTable: "HealthInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadioFAMSelectedCategories",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInformationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RadioFAMCategoryId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioFAMSelectedCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadioFAMSelectedCategories_HealthInformation_HealthInformationId",
                        column: x => x.HealthInformationId,
                        principalTable: "HealthInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadioFAMSelectedCategories_RadioFAMCategories_RadioFAMCategoryId",
                        column: x => x.RadioFAMCategoryId,
                        principalTable: "RadioFAMCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TVFAMSelectedCategories",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInformationId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TVFAMCategoryId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVFAMSelectedCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVFAMSelectedCategories_HealthInformation_HealthInformationId",
                        column: x => x.HealthInformationId,
                        principalTable: "HealthInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVFAMSelectedCategories_TVFAMCategories_TVFAMCategoryId",
                        column: x => x.TVFAMCategoryId,
                        principalTable: "TVFAMCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 13, 40, 26, 731, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_OwnerId",
                table: "HealthInformation",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformationTags_HealthInformationId",
                table: "HealthInformationTags",
                column: "HealthInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_RadioFAMSelectedCategories_HealthInformationId",
                table: "RadioFAMSelectedCategories",
                column: "HealthInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_RadioFAMSelectedCategories_RadioFAMCategoryId",
                table: "RadioFAMSelectedCategories",
                column: "RadioFAMCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TVFAMSelectedCategories_HealthInformationId",
                table: "TVFAMSelectedCategories",
                column: "HealthInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TVFAMSelectedCategories_TVFAMCategoryId",
                table: "TVFAMSelectedCategories",
                column: "TVFAMCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthInformationTags");

            migrationBuilder.DropTable(
                name: "RadioFAMSelectedCategories");

            migrationBuilder.DropTable(
                name: "TVFAMSelectedCategories");

            migrationBuilder.DropTable(
                name: "HealthInformation");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 323, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 26, 10, 49, 59, 322, DateTimeKind.Local).AddTicks(7310));
        }
    }
}
