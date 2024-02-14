using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "students",
                newName: "grade");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "students",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "students",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "students",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "CourseTitle",
                table: "students",
                newName: "course_title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "courses",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Instructor",
                table: "courses",
                newName: "instructor");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "courses",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "courses",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "courses",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "courses",
                newName: "course_id");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "student_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Students",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Students",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "Students",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "course_title",
                table: "Students",
                newName: "CourseTitle");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Courses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "instructor",
                table: "Courses",
                newName: "Instructor");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Courses",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Courses",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Courses",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");
        }
    }
}
