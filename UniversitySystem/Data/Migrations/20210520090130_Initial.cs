using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studies_SubjectsToStudie_SubjectsToStudieStudieId",
                table: "Studies");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_StudieSubjects_StudieSubjectsModelId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_SubjectsToStudie_SubjectsToStudieStudieId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "StudieSubjects");

            migrationBuilder.DropTable(
                name: "StudieViewModel");

            migrationBuilder.DropTable(
                name: "SubjectsToStudie");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudieSubjectsModelId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectsToStudieStudieId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Studies_SubjectsToStudieStudieId",
                table: "Studies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudieSubjectsModelId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectsToStudieStudieId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudieName",
                table: "Studies");

            migrationBuilder.DropColumn(
                name: "SubjectsToStudieStudieId",
                table: "Studies");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SubjectViewModel",
                newName: "Desc");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectViewModel",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Subjects",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Studies",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectBindingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectUpdateBindingModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectUpdateBindingModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "SubjectBindingModel");

            migrationBuilder.DropTable(
                name: "SubjectUpdateBindingModel");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Studies");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "SubjectViewModel",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectViewModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudieSubjectsModelId",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectsToStudieStudieId",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudieName",
                table: "Studies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectsToStudieStudieId",
                table: "Studies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudieSubjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudieViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudieViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsToStudie",
                columns: table => new
                {
                    StudieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsToStudie", x => x.StudieId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudieSubjectsModelId",
                table: "Subjects",
                column: "StudieSubjectsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectsToStudieStudieId",
                table: "Subjects",
                column: "SubjectsToStudieStudieId");

            migrationBuilder.CreateIndex(
                name: "IX_Studies_SubjectsToStudieStudieId",
                table: "Studies",
                column: "SubjectsToStudieStudieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studies_SubjectsToStudie_SubjectsToStudieStudieId",
                table: "Studies",
                column: "SubjectsToStudieStudieId",
                principalTable: "SubjectsToStudie",
                principalColumn: "StudieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_StudieSubjects_StudieSubjectsModelId",
                table: "Subjects",
                column: "StudieSubjectsModelId",
                principalTable: "StudieSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_SubjectsToStudie_SubjectsToStudieStudieId",
                table: "Subjects",
                column: "SubjectsToStudieStudieId",
                principalTable: "SubjectsToStudie",
                principalColumn: "StudieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
