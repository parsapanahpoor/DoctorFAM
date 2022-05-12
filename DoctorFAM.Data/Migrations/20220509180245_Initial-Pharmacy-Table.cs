using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    public partial class InitialPharmacyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePharmacyRequestDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DrugTrakingCode = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DrugPrescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DrugCount = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePharmacyRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePharmacyRequestDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomePharmacyRequestDetails_RequestId",
                table: "HomePharmacyRequestDetails",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePharmacyRequestDetails");
        }
    }
}
