using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangeDoctorInterestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsultantPanelSide",
                table: "Interests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DoctorPanelSide",
                table: "Interests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 12, 26, 31, 728, DateTimeKind.Local).AddTicks(6163));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantPanelSide",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "DoctorPanelSide",
                table: "Interests");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 6, 3, 10, 20, 29, 58, DateTimeKind.Local).AddTicks(8897));
        }
    }
}
