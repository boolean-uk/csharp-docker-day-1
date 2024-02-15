using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "couses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    course_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    average_grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_couses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "couses",
                columns: new[] { "id", "average_grade", "course_start_date", "course_title" },
                values: new object[,]
                {
                    { 1, 1f, new DateOnly(2024, 1, 4), "Title" },
                    { 2, 3f, new DateOnly(2024, 6, 15), "Another Title" },
                    { 3, 2f, new DateOnly(2025, 1, 26), "Yet another Title" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2000, 1, 26), "First", "Second" },
                    { 2, 2, new DateOnly(2000, 6, 3), "First", "Third" },
                    { 3, 1, new DateOnly(2000, 12, 15), "First", "Fourth" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "couses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
