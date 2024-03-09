using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class manyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.course_id, x.student_id });
                    table.ForeignKey(
                        name: "FK_CourseStudents_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "course_id", "student_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "dob",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                column: "dob",
                value: new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_student_id",
                table: "CourseStudents",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "course_id", "dob" },
                values: new object[] { 1, new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "course_id", "dob" },
                values: new object[] { 3, new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "course_id", "dob" },
                values: new object[] { 2, new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7509) });

            migrationBuilder.CreateIndex(
                name: "IX_students_course_id",
                table: "students",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_courses_course_id",
                table: "students",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
