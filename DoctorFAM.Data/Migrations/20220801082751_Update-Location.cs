using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CityId",
                table: "WorkAddresses",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CountryId",
                table: "WorkAddresses",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StateId",
                table: "WorkAddresses",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 57, 51, 140, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddresses_CityId",
                table: "WorkAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddresses_CountryId",
                table: "WorkAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddresses_StateId",
                table: "WorkAddresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Locations_CityId",
                table: "WorkAddresses",
                column: "CityId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Locations_CountryId",
                table: "WorkAddresses",
                column: "CountryId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAddresses_Locations_StateId",
                table: "WorkAddresses",
                column: "StateId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Locations_CityId",
                table: "WorkAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Locations_CountryId",
                table: "WorkAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAddresses_Locations_StateId",
                table: "WorkAddresses");

            migrationBuilder.DropIndex(
                name: "IX_WorkAddresses_CityId",
                table: "WorkAddresses");

            migrationBuilder.DropIndex(
                name: "IX_WorkAddresses_CountryId",
                table: "WorkAddresses");

            migrationBuilder.DropIndex(
                name: "IX_WorkAddresses_StateId",
                table: "WorkAddresses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "WorkAddresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "WorkAddresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "WorkAddresses");

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

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 8, 1, 12, 25, 15, 217, DateTimeKind.Local).AddTicks(63));

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
        }
    }
}
