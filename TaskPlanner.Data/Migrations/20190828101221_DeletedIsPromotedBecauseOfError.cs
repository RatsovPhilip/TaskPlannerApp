using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class DeletedIsPromotedBecauseOfError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
