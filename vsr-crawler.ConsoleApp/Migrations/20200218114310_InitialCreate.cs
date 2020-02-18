using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crawler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    MainDivPath = table.Column<string>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true),
                    NamePath = table.Column<string>(nullable: true),
                    RoomPath = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crawler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrawlerData",
                columns: table => new
                {
                    CrawlerDataId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrawlerData", x => x.CrawlerDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crawler");

            migrationBuilder.DropTable(
                name: "CrawlerData");
        }
    }
}
