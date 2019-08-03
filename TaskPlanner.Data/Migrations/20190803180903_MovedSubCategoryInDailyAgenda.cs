using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class MovedSubCategoryInDailyAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategory",
                table: "DailyAgendas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "DailyAgendas");

            migrationBuilder.AddColumn<int>(
                name: "SubCategory",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
