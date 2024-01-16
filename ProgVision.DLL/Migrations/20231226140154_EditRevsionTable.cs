using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgVision.DAL.Migrations
{
    public partial class EditRevsionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Students_StudentId1",
                table: "Revisions");

            migrationBuilder.DropIndex(
                name: "IX_Revisions_StudentId1",
                table: "Revisions");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Revisions");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Revisions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_StudentId",
                table: "Revisions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Students_StudentId",
                table: "Revisions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Students_StudentId",
                table: "Revisions");

            migrationBuilder.DropIndex(
                name: "IX_Revisions_StudentId",
                table: "Revisions");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Revisions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Revisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_StudentId1",
                table: "Revisions",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Students_StudentId1",
                table: "Revisions",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
