using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class _14010816 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorsLabelsForVIPInsertedDoctor",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsLabelsForVIPInsertedDoctor", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "LabelOfVIPDoctorInsertedPatient",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIPUserInsertedFromDoctorSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DoctorsLabelsForVIPInsertedDoctorId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelOfVIPDoctorInsertedPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelOfVIPDoctorInsertedPatient_DoctorsLabelsForVIPInsertedDoctor_DoctorsLabelsForVIPInsertedDoctorId",
                        column: x => x.DoctorsLabelsForVIPInsertedDoctorId,
                        principalTable: "DoctorsLabelsForVIPInsertedDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "CategoryInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "InterestInfos",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "PharmacyInterestInfos",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "PharmacyInterests",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18m,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 16, 28, 37, 635, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.CreateIndex(
                name: "IX_LabelOfVIPDoctorInsertedPatient_DoctorsLabelsForVIPInsertedDoctorId",
                table: "LabelOfVIPDoctorInsertedPatient",
                column: "DoctorsLabelsForVIPInsertedDoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelOfVIPDoctorInsertedPatient");

            migrationBuilder.DropTable(
                name: "LogForSendSMSToVIPUsersIncomeFromDoctorSystem");

            migrationBuilder.DropTable(
                name: "VIPUserInsertedFromDoctorSystem");

            migrationBuilder.DropTable(
                name: "DoctorsLabelsForVIPInsertedDoctor");

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
