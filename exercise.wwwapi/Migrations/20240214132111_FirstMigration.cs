using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    averageGrade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentCourses",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "integer", nullable: false),
                    courseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourses", x => new { x.studentId, x.courseId });
                    table.ForeignKey(
                        name: "FK_studentCourses_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourses_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "startDate", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 5, 13, 21, 11, 34, DateTimeKind.Utc).AddTicks(3490), "Math" },
                    { 2, new DateTime(2024, 3, 15, 13, 21, 11, 34, DateTimeKind.Utc).AddTicks(3502), "English" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "averageGrade", "dateOfBirth", "firstName", "lastName" },
                values: new object[,]
                {
                    { 1, "B", new DateTime(1994, 2, 14, 13, 21, 11, 34, DateTimeKind.Utc).AddTicks(3506), "Cillian", "Murphy" },
                    { 2, "A", new DateTime(1996, 2, 14, 13, 21, 11, 34, DateTimeKind.Utc).AddTicks(3513), "Christian", "Bale" },
                    { 3, "C", new DateTime(2024, 1, 25, 13, 21, 11, 34, DateTimeKind.Utc).AddTicks(3517), "Tom", "Hardy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentCourses_courseId",
                table: "studentCourses",
                column: "courseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentCourses");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
