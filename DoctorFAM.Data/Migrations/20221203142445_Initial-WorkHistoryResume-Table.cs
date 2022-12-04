using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialWorkHistoryResumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkHistoryResume",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistoryResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistoryResume_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 17, 54, 44, 149, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistoryResume_ResumeId",
                table: "WorkHistoryResume",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkHistoryResume");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 12, 3, 12, 38, 18, 629, DateTimeKind.Local).AddTicks(933));
        }
    }
}
