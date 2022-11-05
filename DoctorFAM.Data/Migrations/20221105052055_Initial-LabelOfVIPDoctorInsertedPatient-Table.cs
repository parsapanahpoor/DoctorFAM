using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialLabelOfVIPDoctorInsertedPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelOfVIPDoctorInsertedPatient",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIPUserInsertedFromDoctorSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LabelOfSickness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelOfVIPDoctorInsertedPatient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogForSendSMSToVIPUsersIncomeFromDoctorSystem",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIPUserInsertedFromDoctorSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SMSBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogForSendSMSToVIPUsersIncomeFromDoctorSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VIPUserInsertedFromDoctorSystem",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SMSSent = table.Column<bool>(type: "bit", nullable: false),
                    SMSSentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientNationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPUserInsertedFromDoctorSystem", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 8, 50, 54, 515, DateTimeKind.Local).AddTicks(8081));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelOfVIPDoctorInsertedPatient");

            migrationBuilder.DropTable(
                name: "LogForSendSMSToVIPUsersIncomeFromDoctorSystem");

            migrationBuilder.DropTable(
                name: "VIPUserInsertedFromDoctorSystem");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 749, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 10, 30, 0, 23, 13, 748, DateTimeKind.Local).AddTicks(8930));
        }
    }
}
