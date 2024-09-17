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
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    course_date_started = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    average_grade = table.Column<double>(type: "double precision", nullable: false)
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
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                columns: new[] { "id", "average_grade", "course_date_started", "course_title" },
                values: new object[,]
                {
                    { 1, 5.0, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "C#" },
                    { 2, 2.0, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Java" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "course_id", "dob", "firstName", "lastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Silje", "Jacobsen" },
                    { 2, 2, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Daniel", "Røli" },
                    { 3, 2, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Øyvind", "Onarheim" },
                    { 4, 1, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Eyvind", "Malde" },
                    { 5, 1, new DateTime(2000, 7, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Espen", "Luba" }
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
