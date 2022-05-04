using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialParientRequestDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "SystemName",
                keyValue: "ru-RU");

            migrationBuilder.AddColumn<decimal>(
                name: "UserId",
                table: "Patients",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaitientRequestDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PatientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CountryId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CityId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Vilage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaitientRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaitientRequestDetails_Locations_CityId",
                        column: x => x.CityId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaitientRequestDetails_Locations_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaitientRequestDetails_Locations_StateId",
                        column: x => x.StateId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaitientRequestDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaitientRequestDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "ar-SA", true, "Arabic" });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "tr-TR", true, "Turkish" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaitientRequestDetails_CityId",
                table: "PaitientRequestDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PaitientRequestDetails_CountryId",
                table: "PaitientRequestDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PaitientRequestDetails_PatientId",
                table: "PaitientRequestDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaitientRequestDetails_RequestId",
                table: "PaitientRequestDetails",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaitientRequestDetails_StateId",
                table: "PaitientRequestDetails",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PaitientRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "SystemName",
                keyValue: "ar-SA");

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "SystemName",
                keyValue: "tr-TR");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "SystemName", "IsActive", "Title" },
                values: new object[] { "ru-RU", true, "Russian" });
        }
    }
}
