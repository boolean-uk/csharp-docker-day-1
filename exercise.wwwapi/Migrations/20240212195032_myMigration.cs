using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<string>(type: "text", nullable: false),
                    avrage_grade = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "start_date", "title" },
                values: new object[,]
                {
                    { 1, "2024-01-01", "Music" },
                    { 2, "2024-01-01", "Math" },
                    { 3, "2024-01-01", "Programming" },
                    { 4, "2024-01-01", "Art" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "avrage_grade", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 5, 1, "1992-01-01", "A", "Aa" },
                    { 2, 4, 1, "1992-02-02", "B", "Bb" },
                    { 3, 3, 2, "1992-03-03", "C", "Cc" },
                    { 4, 2, 2, "1992-04-04", "D", "Dd" },
                    { 5, 5, 3, "1992-01-01", "E", "Aa" },
                    { 6, 4, 3, "1992-02-02", "F", "Bb" },
                    { 7, 3, 4, "1992-03-03", "G", "Cc" },
                    { 8, 2, 4, "1992-04-04", "H", "Dd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_course_id",
                table: "Students",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
