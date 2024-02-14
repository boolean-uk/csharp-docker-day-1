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
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<string>(type: "text", nullable: false),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    course_start_date = table.Column<string>(type: "text", nullable: false),
                    average_grade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_start_date", "course_title", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 4, "2024/01/08", "C# Academy", "1998/11/29", "Henrik", "Rosenkilde" },
                    { 2, 5, "2024/03/20", "Advanced Data Structures", "1999/03/15", "Jens", "Forgård" },
                    { 3, 6, "2024/04/10", "Machine Learning Fundamentals", "1997/11/21", "Kristian", "Verduin" }
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
