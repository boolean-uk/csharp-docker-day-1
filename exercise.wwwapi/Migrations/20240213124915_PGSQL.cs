using System;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class PGSQL : Migration
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
                    StudentCount = table.Column<int>(type: "integer", nullable: false)
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
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    course_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    average_grade = table.Column<double>(type: "double precision", nullable: false)
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
                columns: new[] { "id", "StudentCount", "title" },
                values: new object[,]
                {
                    { -1, 0, "Not Specified" },
                    { 1, 0, "C#" },
                    { 2, 0, "Java" },
                    { 3, 0, "C" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 5.4500000000000002, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1998, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Jacobsen" },
                    { 2, 9.7899999999999991, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1984, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Middleton" },
                    { 3, 7.5599999999999996, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2002, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Obama" },
                    { 4, 4.2300000000000004, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1982, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hendrix" },
                    { 5, 9.1099999999999994, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hepburn" },
                    { 6, 1.1599999999999999, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2007, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hepburn" },
                    { 7, 1.1799999999999999, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1977, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Olsen" },
                    { 8, 4.3600000000000003, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winfrey" },
                    { 9, 8.6699999999999999, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jagger" },
                    { 10, 4.4299999999999997, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1973, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Barack", "Olsen" },
                    { 11, 2.6800000000000002, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2009, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Winslet" },
                    { 12, 6.7699999999999996, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1983, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Winfrey" },
                    { 13, 3.5600000000000001, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2006, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Presley" },
                    { 14, 5.71, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Hendrix" },
                    { 15, 8.1799999999999997, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1997, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Windsor" },
                    { 16, 0.16, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1991, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Winfrey" },
                    { 17, 2.71, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1989, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jacobsen" },
                    { 18, 4.1500000000000004, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2000, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hendrix" },
                    { 19, 2.4199999999999999, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1986, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Windsor" },
                    { 20, 7.6900000000000004, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1974, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hendrix" },
                    { 21, 4.0, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1975, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Windsor" },
                    { 22, 8.5099999999999998, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1977, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hendrix" },
                    { 23, 8.9800000000000004, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2005, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Olsen" },
                    { 24, 2.9399999999999999, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1975, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Winfrey" },
                    { 25, 4.5, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2006, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Jacobsen" },
                    { 26, 8.0299999999999994, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Olsen" },
                    { 27, 8.8900000000000006, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1991, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jacobsen" },
                    { 28, 0.65000000000000002, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1979, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winslet" },
                    { 29, 8.7899999999999991, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1981, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Hendrix" }
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
