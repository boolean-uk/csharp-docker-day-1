using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
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
                    start = table.Column<DateOnly>(type: "date", nullable: false),
                    grade = table.Column<double>(type: "double precision", nullable: false)
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
                    birth = table.Column<DateOnly>(type: "date", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "grade", "start", "title" },
                values: new object[,]
                {
                    { 1, 1.5, new DateOnly(2024, 8, 8), "Java" },
                    { 2, 5.2000000000000002, new DateOnly(2024, 8, 8), ".NET" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "birth", "CourseId", "firstname", "lastname" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 7, 20), 2, "Espen", "Luna" },
                    { 2, new DateOnly(2000, 6, 26), 2, "Eyvind", "Malde" },
                    { 3, new DateOnly(2000, 10, 8), 1, "Daniel", "Røli" }
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
