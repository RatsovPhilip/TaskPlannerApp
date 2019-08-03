using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class AddedManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Companies_CompanyId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CompanyId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => new { x.CompanyId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_CategoryId",
                table: "CompanyCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCategories");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CompanyId",
                table: "Categories",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Companies_CompanyId",
                table: "Categories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
