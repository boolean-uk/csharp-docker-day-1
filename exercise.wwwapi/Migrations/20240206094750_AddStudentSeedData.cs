using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AvarageGrade", "CourseName", "DateOfBirth", "FirstName", "LastName", "StartDateOfCourse" },
                values: new object[,]
                {
                    { 1, 3.5f, "Computer Science", new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "John", "Doe", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 3.8f, "Mathematics", new DateTime(1999, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Jane", "Smith", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
