using Microsoft.EntityFrameworkCore.Migrations;

namespace vsr_crawler.ConsoleApp.Migrations
{
    public partial class Faculty_and_FacultyMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestClasses");

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Raum = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OfficeHour = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyMember_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyMember_FacultyId",
                table: "FacultyMember",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyMember");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.CreateTable(
                name: "TestClasses",
                columns: table => new
                {
                    TestClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestClasses", x => x.TestClassId);
                });
        }
    }
}
