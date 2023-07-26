using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class updatedoctorReservationRemoveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 9, 14, 19, 168, DateTimeKind.Local).AddTicks(4970));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 7, 17, 11, 10, 56, 71, DateTimeKind.Local).AddTicks(6970));
        }
    }
}
