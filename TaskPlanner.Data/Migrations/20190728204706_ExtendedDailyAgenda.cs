using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskPlanner.Data.Migrations
{
    public partial class ExtendedDailyAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DailyAgendas",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DailyAgendas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DailyAgendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "DailyAgendas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThemeColor",
                table: "DailyAgendas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DailyAgendas");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DailyAgendas");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "DailyAgendas");

            migrationBuilder.DropColumn(
                name: "ThemeColor",
                table: "DailyAgendas");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DailyAgendas",
                newName: "Date");
        }
    }
}
