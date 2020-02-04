using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class Crawler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crawler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    MainDivPath = table.Column<string>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true),
                    NamePath = table.Column<string>(nullable: true),
                    RoomPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crawler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crawler");
        }
    }
}
