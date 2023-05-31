using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateHomeLaboratoryRequestPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SenResultInSocialMedias",
                table: "HomeLaboratoryRequestPrice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendResultInDoctorFAMPanel",
                table: "HomeLaboratoryRequestPrice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendResultWithVisitInPerson",
                table: "HomeLaboratoryRequestPrice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3464));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 20, 20, 0, 135, DateTimeKind.Local).AddTicks(6594));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenResultInSocialMedias",
                table: "HomeLaboratoryRequestPrice");

            migrationBuilder.DropColumn(
                name: "SendResultInDoctorFAMPanel",
                table: "HomeLaboratoryRequestPrice");

            migrationBuilder.DropColumn(
                name: "SendResultWithVisitInPerson",
                table: "HomeLaboratoryRequestPrice");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 29, 13, 26, 39, 644, DateTimeKind.Local).AddTicks(6525));
        }
    }
}
