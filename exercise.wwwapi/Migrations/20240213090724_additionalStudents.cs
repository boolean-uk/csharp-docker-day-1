using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class additionalStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "average_grade", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 4, 3.0, 2, new DateTime(1996, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Alexander", "Gatland" },
                    { 5, 3.0, 2, new DateTime(1996, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Nora", "Hansen" },
                    { 6, 3.0, 2, new DateTime(1996, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Marit", "Moe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
