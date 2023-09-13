using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddUsersVirtualFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersVirtualFiles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersVirtualFiles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 14, 6, 11, 17, DateTimeKind.Local).AddTicks(5291));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersVirtualFiles");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 25, 21, 525, DateTimeKind.Local).AddTicks(8348));
        }
    }
}
