using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class AddChatAndChatGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatGroups",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupToken = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    OwnerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    GroupId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1248));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 31, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 12, 42, 42, 32, DateTimeKind.Local).AddTicks(2423));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatGroups");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Insurance",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 19m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 20m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 21m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 22m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 23m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 24m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 25m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 26m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 27m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 28m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 29m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 30m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 31m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "SpecialtiyInfos",
                keyColumn: "Id",
                keyValue: 32m,
                column: "CreateDate",
                value: new DateTime(2023, 3, 4, 9, 42, 36, 251, DateTimeKind.Local).AddTicks(8848));
        }
    }
}
