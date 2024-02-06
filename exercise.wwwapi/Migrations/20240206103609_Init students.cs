using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Initstudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    average_grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "birthdate", "start_date", "course_title", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 3.5f, new DateTime(2000, 1, 14, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Computer Science", "John", "Doe" },
                    { 2, 3.8f, new DateTime(1999, 5, 21, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Mathematics", "Jane", "Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
