using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddFreeSMSField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FreeSMS",
                table: "SendRequestOfSMSFromDoctorsToThePatientDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 4, 19, 13, 0, 5, 544, DateTimeKind.Local).AddTicks(7749));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeSMS",
                table: "SendRequestOfSMSFromDoctorsToThePatientDetails");

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
    }
}
