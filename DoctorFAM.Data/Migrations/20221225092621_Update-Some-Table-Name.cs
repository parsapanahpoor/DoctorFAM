using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class UpdateSomeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_News_NewsId",
                table: "MyProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_NewsCategories_NewsCategoryId",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "NewsSelectedCategory");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_NewsId",
                table: "NewsSelectedCategory",
                newName: "IX_NewsSelectedCategory_NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_NewsCategoryId",
                table: "NewsSelectedCategory",
                newName: "IX_NewsSelectedCategory_NewsCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsSelectedCategory",
                table: "NewsSelectedCategory",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 25, 12, 56, 20, 588, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.AddForeignKey(
                name: "FK_NewsSelectedCategory_News_NewsId",
                table: "NewsSelectedCategory",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsSelectedCategory_NewsCategories_NewsCategoryId",
                table: "NewsSelectedCategory",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsSelectedCategory_News_NewsId",
                table: "NewsSelectedCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsSelectedCategory_NewsCategories_NewsCategoryId",
                table: "NewsSelectedCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsSelectedCategory",
                table: "NewsSelectedCategory");

            migrationBuilder.RenameTable(
                name: "NewsSelectedCategory",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_NewsSelectedCategory_NewsId",
                table: "MyProperty",
                newName: "IX_MyProperty_NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsSelectedCategory_NewsCategoryId",
                table: "MyProperty",
                newName: "IX_MyProperty_NewsCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 24, 12, 59, 43, 119, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_News_NewsId",
                table: "MyProperty",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_NewsCategories_NewsCategoryId",
                table: "MyProperty",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
