using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    courseTitle = table.Column<string>(type: "text", nullable: false),
                    courseStartDate = table.Column<string>(type: "text", nullable: false),
                    averageGrade = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    dateofbirth = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "averageGrade", "courseStartDate", "courseTitle" },
                values: new object[,]
                {
                    { 1, 1.0, "2024, 9, 22", "Java" },
                    { 2, 6.0, "2024, 2, 14", "C#" },
                    { 3, 4.0, "2024, 6, 28", ".NET" },
                    { 4, 5.0, "2024, 9, 22", "C#" },
                    { 5, 2.0, "2024, 10, 3", "Java" },
                    { 6, 1.0, "2024, 8, 9", "C#" },
                    { 7, 2.0, "2024, 8, 9", "JavaScript" },
                    { 8, 4.0, "2024, 11, 7", "JavaScript" },
                    { 9, 2.0, "2024, 7, 18", "Java" },
                    { 10, 1.0, "2024, 6, 28", "JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "Id", "CourseId", "dateofbirth", "firstname", "lastname" },
                values: new object[,]
                {
                    { 1, 3, "1975, 9, 22", "Donald", "Presley" },
                    { 2, 1, "1993, 2, 14", "Kate", "Windsor" },
                    { 3, 4, "1990, 5, 15", "Elvis", "Windsor" },
                    { 4, 4, "1978, 12, 25", "Barack", "Hendrix" },
                    { 5, 3, "2005, 11, 7", "Oprah", "Hepburn" },
                    { 6, 2, "1982, 7, 18", "Jimi", "Jagger" },
                    { 7, 3, "1970, 6, 28", "Jimi", "Winfrey" },
                    { 8, 2, "1975, 9, 22", "Mick", "Winslet" },
                    { 9, 4, "1996, 4, 30", "Charles", "Windsor" },
                    { 10, 2, "1985, 10, 3", "Charles", "Windsor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_CourseId",
                table: "student",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
