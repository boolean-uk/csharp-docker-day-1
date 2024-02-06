using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Initstudentsandcourse : Migration
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
                    course_title = table.Column<string>(type: "text", nullable: false),
                    course_description = table.Column<string>(type: "text", nullable: false),
                    available_spots = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    average_grade = table.Column<float>(type: "real", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "available_spots", "course_description", "end_date", "start_date", "course_title" },
                values: new object[,]
                {
                    { 1, 30, "Advanced Calculus", new DateTime(2024, 6, 5, 12, 33, 56, 244, DateTimeKind.Utc).AddTicks(5716), new DateTime(2024, 2, 13, 13, 33, 56, 244, DateTimeKind.Utc).AddTicks(5644), "Mathematics" },
                    { 2, 25, "Introduction to Programming", new DateTime(2024, 5, 6, 12, 33, 56, 244, DateTimeKind.Utc).AddTicks(5724), new DateTime(2024, 2, 20, 13, 33, 56, 244, DateTimeKind.Utc).AddTicks(5722), "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "birthdate", "course_id", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 3.5f, new DateTime(2000, 1, 14, 23, 0, 0, 0, DateTimeKind.Utc), 1, "John", "Doe" },
                    { 2, 3.8f, new DateTime(1999, 5, 21, 22, 0, 0, 0, DateTimeKind.Utc), 2, "Jane", "Smith" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_course_id",
                table: "students",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
