using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddDoctorReservationAlertField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorReservationAlert",
                table: "DoctorsReservationTariffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 10, 13, 24, 10, 21, DateTimeKind.Local).AddTicks(4274));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorReservationAlert",
                table: "DoctorsReservationTariffs");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 10, 5, 13, 2, 40, 1, DateTimeKind.Local).AddTicks(8368));
        }
    }
}
