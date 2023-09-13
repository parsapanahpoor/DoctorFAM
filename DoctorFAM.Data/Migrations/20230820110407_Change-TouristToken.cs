using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangeTouristToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristPassengersSelectTokens");

            migrationBuilder.AddColumn<decimal>(
                name: "TokenId",
                table: "TouristPassengers",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 14, 34, 5, 971, DateTimeKind.Local).AddTicks(4796));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "TouristPassengers");

            migrationBuilder.CreateTable(
                name: "TouristPassengersSelectTokens",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    PassengersId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TokenId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TouristId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristPassengersSelectTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 8, 16, 12, 56, 36, 17, DateTimeKind.Local).AddTicks(2029));
        }
    }
}
