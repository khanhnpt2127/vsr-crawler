using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class changeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CrawlerData",
                table: "CrawlerData");

            migrationBuilder.DropColumn(
                name: "CrawlerDataId",
                table: "CrawlerData");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CrawlerData",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrawlerData",
                table: "CrawlerData",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Professorships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professorships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professorships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrawlerData",
                table: "CrawlerData");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CrawlerData");

            migrationBuilder.AddColumn<Guid>(
                name: "CrawlerDataId",
                table: "CrawlerData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrawlerData",
                table: "CrawlerData",
                column: "CrawlerDataId");
        }
    }
}
