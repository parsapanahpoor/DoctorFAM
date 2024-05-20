using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class ChangesomepropertiesinorganizationStartable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ServiceRequestedId",
                table: "OrganizationStarts",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "PointValue",
                table: "OrganizationStarPoints",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 20, 12, 13, 58, 806, DateTimeKind.Local).AddTicks(9139));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceRequestedId",
                table: "OrganizationStarts");

            migrationBuilder.AlterColumn<decimal>(
                name: "PointValue",
                table: "OrganizationStarPoints",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2024, 5, 19, 13, 23, 38, 583, DateTimeKind.Local).AddTicks(5647));
        }
    }
}
