using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    average_grade = table.Column<double>(type: "double precision", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "id", "course_code" },
                values: new object[,]
                {
                    { 1, "JAVA1001" },
                    { 2, "C#1001" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "average_grade", "course_id", "course_title", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 3.0, 2, "C#", new DateTime(2024, 2, 13, 12, 26, 52, 556, DateTimeKind.Utc).AddTicks(8633), "Peder", "Anton" },
                    { 2, 4.0, 1, "Java", new DateTime(2024, 2, 13, 12, 26, 52, 556, DateTimeKind.Utc).AddTicks(8649), "Guiseppe", "Garibaldi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_course_id",
                table: "student",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
