using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgVision.DAL.Migrations
{
    public partial class addTeachingIDForenKeyToCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeachingsId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachingsId",
                table: "Courses");
        }
    }
}
