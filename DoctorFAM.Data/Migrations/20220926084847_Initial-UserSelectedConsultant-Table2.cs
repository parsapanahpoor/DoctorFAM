using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialUserSelectedConsultantTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelectedConsultant_Users_ConsultantId",
                table: "UserSelectedConsultant");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSelectedConsultant_Users_PatientId",
                table: "UserSelectedConsultant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSelectedConsultant",
                table: "UserSelectedConsultant");

            migrationBuilder.RenameTable(
                name: "UserSelectedConsultant",
                newName: "UserSelectedConsultants");

            migrationBuilder.RenameIndex(
                name: "IX_UserSelectedConsultant_PatientId",
                table: "UserSelectedConsultants",
                newName: "IX_UserSelectedConsultants_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSelectedConsultant_ConsultantId",
                table: "UserSelectedConsultants",
                newName: "IX_UserSelectedConsultants_ConsultantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSelectedConsultants",
                table: "UserSelectedConsultants",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 18, 46, 297, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelectedConsultants_Users_ConsultantId",
                table: "UserSelectedConsultants",
                column: "ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelectedConsultants_Users_PatientId",
                table: "UserSelectedConsultants",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelectedConsultants_Users_ConsultantId",
                table: "UserSelectedConsultants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSelectedConsultants_Users_PatientId",
                table: "UserSelectedConsultants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSelectedConsultants",
                table: "UserSelectedConsultants");

            migrationBuilder.RenameTable(
                name: "UserSelectedConsultants",
                newName: "UserSelectedConsultant");

            migrationBuilder.RenameIndex(
                name: "IX_UserSelectedConsultants_PatientId",
                table: "UserSelectedConsultant",
                newName: "IX_UserSelectedConsultant_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSelectedConsultants_ConsultantId",
                table: "UserSelectedConsultant",
                newName: "IX_UserSelectedConsultant_ConsultantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSelectedConsultant",
                table: "UserSelectedConsultant",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 9, 26, 12, 15, 55, 662, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelectedConsultant_Users_ConsultantId",
                table: "UserSelectedConsultant",
                column: "ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelectedConsultant_Users_PatientId",
                table: "UserSelectedConsultant",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
