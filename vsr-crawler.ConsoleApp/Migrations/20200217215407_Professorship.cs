using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class Professorship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorshipId",
                table: "Crawler",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professorships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professorships", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crawler_ProfessorshipId",
                table: "Crawler",
                column: "ProfessorshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crawler_Professorships_ProfessorshipId",
                table: "Crawler",
                column: "ProfessorshipId",
                principalTable: "Professorships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crawler_Professorships_ProfessorshipId",
                table: "Crawler");

            migrationBuilder.DropTable(
                name: "Professorships");

            migrationBuilder.DropIndex(
                name: "IX_Crawler_ProfessorshipId",
                table: "Crawler");

            migrationBuilder.DropColumn(
                name: "ProfessorshipId",
                table: "Crawler");
        }
    }
}
