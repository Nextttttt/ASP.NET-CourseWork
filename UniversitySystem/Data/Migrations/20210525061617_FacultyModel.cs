using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySystem.Data.Migrations
{
    public partial class FacultyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Studies_StudieModelId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudieModelId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudieModelId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyBindingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyUpdateBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyUpdateBindingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudieBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieBindingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudieSubjects",
                columns: table => new
                {
                    StudieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieSubjects", x => new { x.StudieId, x.SubjectId });
                });

            migrationBuilder.CreateTable(
                name: "StudieUpdateBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieUpdateBindingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudieViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "FacultyBindingModel");

            migrationBuilder.DropTable(
                name: "FacultyUpdateBindingModel");

            migrationBuilder.DropTable(
                name: "FacultyViewModel");

            migrationBuilder.DropTable(
                name: "StudieBindingModel");

            migrationBuilder.DropTable(
                name: "StudieSubjects");

            migrationBuilder.DropTable(
                name: "StudieUpdateBindingModel");

            migrationBuilder.DropTable(
                name: "StudieViewModel");

            migrationBuilder.AddColumn<string>(
                name: "StudieModelId",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudieModelId",
                table: "Subjects",
                column: "StudieModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Studies_StudieModelId",
                table: "Subjects",
                column: "StudieModelId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
