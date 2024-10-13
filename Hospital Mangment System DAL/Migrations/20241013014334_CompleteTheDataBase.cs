using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Mangment_System_DAL.Migrations
{
    /// <inheritdoc />
    public partial class CompleteTheDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addmissions",
                columns: table => new
                {
                    Addmission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_number = table.Column<int>(type: "int", nullable: false),
                    Addmission_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Date_discharge = table.Column<DateOnly>(type: "date", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addmissions", x => x.Addmission_Id);
                    table.ForeignKey(
                        name: "FK_addmissions_patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Appointment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timeOftheappointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason_Of_Visit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Appointment_Id);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Dnum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dr_Id = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Dnum);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DrId);
                    table.ForeignKey(
                        name: "FK_Doctors_departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "medical_Equipment",
                columns: table => new
                {
                    Equipment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equip_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintence_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_Equipment", x => x.Equipment_Id);
                    table.ForeignKey(
                        name: "FK_medical_Equipment_departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "nurses",
                columns: table => new
                {
                    NurseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    phones = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurses", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_nurses_departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "lap_Tests",
                columns: table => new
                {
                    Test_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Test_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dr_id = table.Column<int>(type: "int", nullable: false),
                    doctorDrId = table.Column<int>(type: "int", nullable: false),
                    Patient_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lap_Tests", x => x.Test_ID);
                    table.ForeignKey(
                        name: "FK_lap_Tests_Doctors_doctorDrId",
                        column: x => x.doctorDrId,
                        principalTable: "Doctors",
                        principalColumn: "DrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lap_Tests_patients_Patient_ID",
                        column: x => x.Patient_ID,
                        principalTable: "patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_addmissions_Patient_Id",
                table: "addmissions",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_departments_ManagerId",
                table: "departments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Dnum",
                table: "Doctors",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_lap_Tests_doctorDrId",
                table: "lap_Tests",
                column: "doctorDrId");

            migrationBuilder.CreateIndex(
                name: "IX_lap_Tests_Patient_ID",
                table: "lap_Tests",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_medical_Equipment_Dnum",
                table: "medical_Equipment",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_nurses_Dnum",
                table: "nurses",
                column: "Dnum");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Doctors_ManagerId",
                table: "departments",
                column: "ManagerId",
                principalTable: "Doctors",
                principalColumn: "DrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Doctors_ManagerId",
                table: "departments");

            migrationBuilder.DropTable(
                name: "addmissions");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "lap_Tests");

            migrationBuilder.DropTable(
                name: "medical_Equipment");

            migrationBuilder.DropTable(
                name: "nurses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
