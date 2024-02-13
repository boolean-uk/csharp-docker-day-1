using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extendedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "course_start_date", "course_title" },
                values: new object[] { 2, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Fullstack Java" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 3, 3.0, 1, new DateTime(1996, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Ole Markus", "Roland" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
