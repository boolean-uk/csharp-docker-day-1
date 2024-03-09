using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AnotherNewInitiateData : Migration
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
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    average_grade = table.Column<float>(type: "real", nullable: false)
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
                columns: new[] { "id", "start_date", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9111), "Math" },
                    { 2, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9198), "Literature" },
                    { 3, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9221), "Arts" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_id", "dob", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 3f, 1, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9316), "Sandra", "Collins" },
                    { 2, 4f, 3, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9337), "Mike", "Smith" },
                    { 3, 5f, 2, new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9343), "Heather", "Dunst" }
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
