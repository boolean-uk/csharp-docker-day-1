using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FillDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_title", "date_of_birth", "first_name", "last_name", "start_date" },
                values: new object[,]
                {
                    { 1, 9f, "Science", "18-4-2006", "Grigoris", "Karampis", "31-8-2023" },
                    { 2, 7f, "Theater", "15-4-2006", "Hannelieke", "Hoogenboom", "31-8-2023" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
