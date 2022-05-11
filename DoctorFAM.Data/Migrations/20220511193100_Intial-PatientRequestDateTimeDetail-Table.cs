using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class IntialPatientRequestDateTimeDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientRequestDateTimeDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRequestDateTimeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRequestDateTimeDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientRequestDateTimeDetails_RequestId",
                table: "PatientRequestDateTimeDetails",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientRequestDateTimeDetails");
        }
    }
}
