using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversitySystem.Data.Migrations
{
    public partial class Subjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
