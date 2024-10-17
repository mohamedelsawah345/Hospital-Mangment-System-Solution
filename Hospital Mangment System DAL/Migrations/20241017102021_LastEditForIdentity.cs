using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Mangment_System_DAL.Migrations
{
    /// <inheritdoc />
    public partial class LastEditForIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Doctors_ManagerId",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_lap_Tests_Doctors_doctorApplicationUserId",
                table: "lap_Tests");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.RenameColumn(
                name: "doctorApplicationUserId",
                table: "lap_Tests",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_lap_Tests_doctorApplicationUserId",
                table: "lap_Tests",
                newName: "IX_lap_Tests_doctorId");

            migrationBuilder.RenameColumn(
                name: "role_Type",
                table: "AspNetUsers",
                newName: "Role_Type");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dnum",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Dnum",
                table: "AspNetUsers",
                column: "Dnum");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_departments_Dnum",
                table: "AspNetUsers",
                column: "Dnum",
                principalTable: "departments",
                principalColumn: "Dnum");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_AspNetUsers_ManagerId",
                table: "departments",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lap_Tests_AspNetUsers_doctorId",
                table: "lap_Tests",
                column: "doctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_Dnum",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_AspNetUsers_ManagerId",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_lap_Tests_AspNetUsers_doctorId",
                table: "lap_Tests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Dnum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Dnum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "lap_Tests",
                newName: "doctorApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_lap_Tests_doctorId",
                table: "lap_Tests",
                newName: "IX_lap_Tests_doctorApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Role_Type",
                table: "AspNetUsers",
                newName: "role_Type");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ApplicationUserId);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Dnum",
                table: "Doctors",
                column: "Dnum");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Doctors_ManagerId",
                table: "departments",
                column: "ManagerId",
                principalTable: "Doctors",
                principalColumn: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_lap_Tests_Doctors_doctorApplicationUserId",
                table: "lap_Tests",
                column: "doctorApplicationUserId",
                principalTable: "Doctors",
                principalColumn: "ApplicationUserId");
        }
    }
}
