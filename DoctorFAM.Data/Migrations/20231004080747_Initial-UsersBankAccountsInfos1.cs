using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialUsersBankAccountsInfos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersBankAccountsInfos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ShomareShaba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShomareCart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAccountUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankBranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankBranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBankAccountsInfos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 37, 45, 883, DateTimeKind.Local).AddTicks(4505));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBankAccountsInfos");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 4, 11, 14, 42, 371, DateTimeKind.Local).AddTicks(5306));
        }
    }
}
