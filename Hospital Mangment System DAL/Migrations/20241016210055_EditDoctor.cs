using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Mangment_System_DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Doctors");
        }
    }
}
