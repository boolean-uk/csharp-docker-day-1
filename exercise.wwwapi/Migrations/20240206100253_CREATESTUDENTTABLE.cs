using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CREATESTUDENTTABLE : Migration
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
                    { 1, 4, "2024/05/13", "Fundamentals of Csharp", "1994/02/07", "Joel", "Joelsson" },
                    { 2, 5, "2024/03/20", "Advanced Data Structures", "1993/08/15", "Anna", "Andersson" },
                    { 3, 3, "2024/04/10", "Machine Learning Fundamentals", "1995/11/21", "David", "Davidsson" },
                    { 4, 2, "2024/06/01", "Web Development Basics", "1992/06/30", "Emma", "Emilsson" },
                    { 5, 5, "2024/02/15", "Introduction to Algorithms", "1996/09/18", "Erik", "Eriksson" }
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
