using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class ExtendedCompnayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldOfService",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FieldOfService",
                table: "Companies");
        }
    }
}
