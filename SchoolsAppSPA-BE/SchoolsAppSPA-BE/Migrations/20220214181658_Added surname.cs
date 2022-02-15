using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolsAppSPA_BE.Migrations
{
    public partial class Addedsurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Students");
        }
    }
}
