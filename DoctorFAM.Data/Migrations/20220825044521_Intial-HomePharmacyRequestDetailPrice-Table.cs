using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntialHomePharmacyRequestDetailPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePharmacyRequestDetailPrices",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomePharmacyRequestDetailId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SellerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePharmacyRequestDetailPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePharmacyRequestDetailPrices_HomePharmacyRequestDetails_HomePharmacyRequestDetailId",
                        column: x => x.HomePharmacyRequestDetailId,
                        principalTable: "HomePharmacyRequestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomePharmacyRequestDetailPrices_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 605, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 25, 9, 15, 20, 604, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.CreateIndex(
                name: "IX_HomePharmacyRequestDetailPrices_HomePharmacyRequestDetailId",
                table: "HomePharmacyRequestDetailPrices",
                column: "HomePharmacyRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePharmacyRequestDetailPrices_SellerId",
                table: "HomePharmacyRequestDetailPrices",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePharmacyRequestDetailPrices");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 21, 16, 47, 9, 571, DateTimeKind.Local).AddTicks(6905));
        }
    }
}
