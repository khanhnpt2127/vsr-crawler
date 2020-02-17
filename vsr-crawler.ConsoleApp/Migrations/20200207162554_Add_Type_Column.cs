using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class Add_Type_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Crawler",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Crawler");
        }
    }
}
