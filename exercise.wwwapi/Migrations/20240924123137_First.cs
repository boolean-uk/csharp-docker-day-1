using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
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
                    start = table.Column<DateOnly>(type: "date", nullable: false)
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
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    CourseId = table.Column<List<int>>(type: "integer[]", nullable: false),
                    average_grades = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "start", "title" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 8, 20), "Programming" },
                    { 2, new DateOnly(2024, 9, 1), "Mathematics" },
                    { 3, new DateOnly(2024, 9, 15), "Physics" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grades", "birthdate", "CourseId", "firstname", "lastname" },
                values: new object[,]
                {
                    { 1, 3, new DateOnly(2000, 9, 19), new List<int> { 1, 2 }, "John", "Doe" },
                    { 2, 4, new DateOnly(1999, 5, 22), new List<int> { 2, 3 }, "Jane", "Smith" },
                    { 3, 4, new DateOnly(2001, 12, 15), new List<int> { 1, 3 }, "Robert", "Johnson" }
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
