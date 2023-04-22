using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddSendRequestOfSMSFromDoctorsToThePatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendRequestOfSMSFromDoctorsToThePatientDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendRequestOfSMSFromDoctorsToThePatientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendRequestOfSMSFromDoctorsToThePatientDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SendRequestOfSMSFromDoctorsToThePatients",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SendSMSFromDoctorState = table.Column<int>(type: "int", nullable: false),
                    DeclineDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendRequestOfSMSFromDoctorsToThePatients", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 923, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 17, 43, 43, 924, DateTimeKind.Local).AddTicks(3440));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendRequestOfSMSFromDoctorsToThePatientDetails");

            migrationBuilder.DropTable(
                name: "SendRequestOfSMSFromDoctorsToThePatients");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 197, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 18, 16, 48, 11, 198, DateTimeKind.Local).AddTicks(8809));
        }
    }
}
