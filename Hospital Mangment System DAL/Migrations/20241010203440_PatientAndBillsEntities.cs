using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Mangment_System_DAL.Migrations
{
    /// <inheritdoc />
    public partial class PatientAndBillsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    phone1 = table.Column<int>(type: "int", nullable: false),
                    phone2 = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bills_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bills_patientId",
                table: "bills",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
