using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class AddedCollectionOfAgendasInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DailyAgendas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyAgendas_ApplicationUserId",
                table: "DailyAgendas",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyAgendas_AspNetUsers_ApplicationUserId",
                table: "DailyAgendas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyAgendas_AspNetUsers_ApplicationUserId",
                table: "DailyAgendas");

            migrationBuilder.DropIndex(
                name: "IX_DailyAgendas_ApplicationUserId",
                table: "DailyAgendas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DailyAgendas");
        }
    }
}
