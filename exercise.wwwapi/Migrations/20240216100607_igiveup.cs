using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class igiveup : Migration
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
                    average_grade = table.Column<char>(type: "character(1)", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_course = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "average_grade", "course_title", "start_date" },
                values: new object[,]
                {
                    { 1, 'B', "Mathematics", new DateTime(2024, 2, 16, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2813) },
                    { 2, 'D', "Physics", new DateTime(2024, 1, 17, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2815) },
                    { 3, 'C', "Biology", new DateTime(2023, 12, 18, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2822) }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "date_of_birth", "first_name", "last_name", "fk_course" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John", "Doe", 0 },
                    { 2, new DateTime(1999, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Alice", "Smith", 0 },
                    { 3, new DateTime(2001, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Bob", "Johnson", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
