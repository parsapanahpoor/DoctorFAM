using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddUserRequestForReserveDateFieldToReservationDateTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UserRequestForReserveDate",
                table: "DoctorReservationDateTimes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 9, 16, 6, 10, 226, DateTimeKind.Local).AddTicks(4903));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRequestForReserveDate",
                table: "DoctorReservationDateTimes");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 49, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 3, 13, 41, 18, 50, DateTimeKind.Local).AddTicks(62));
        }
    }
}
