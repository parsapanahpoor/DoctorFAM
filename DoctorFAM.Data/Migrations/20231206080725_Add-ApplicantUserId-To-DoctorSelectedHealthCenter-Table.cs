using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddApplicantUserIdToDoctorSelectedHealthCenterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoctorUserId",
                table: "DoctorSelectedHealthCenters",
                newName: "ApplicantUserId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 37, 24, 223, DateTimeKind.Local).AddTicks(4953));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicantUserId",
                table: "DoctorSelectedHealthCenters",
                newName: "DoctorUserId");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 12, 6, 11, 14, 26, 817, DateTimeKind.Local).AddTicks(3090));
        }
    }
}
