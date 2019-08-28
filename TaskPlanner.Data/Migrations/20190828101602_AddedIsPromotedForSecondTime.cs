using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class AddedIsPromotedForSecondTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "AspNetUsers");
        }
    }
}
