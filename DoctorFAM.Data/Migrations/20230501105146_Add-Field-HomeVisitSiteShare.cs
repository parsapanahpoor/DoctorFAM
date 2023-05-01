using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddFieldHomeVisitSiteShare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeVisitSiteShare",
                table: "SiteSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 21, 44, 764, DateTimeKind.Local).AddTicks(3897));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeVisitSiteShare",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 564, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 5, 1, 14, 5, 13, 565, DateTimeKind.Local).AddTicks(2321));
        }
    }
}
