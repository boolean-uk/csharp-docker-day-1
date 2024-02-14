using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_course_id",
                table: "students",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_courses_course_id",
                table: "students",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_courses_course_id",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_course_id",
                table: "students");

            migrationBuilder.DropColumn(
                name: "course_id",
                table: "students");
        }
    }
}
