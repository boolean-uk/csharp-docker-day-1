using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Courses",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "CourseName", "Location", "StartDate", "TutorName" },
                values: new object[,]
                {
                    { 1, 100, "Introduction to Web Development", "Online", new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Alex Johnson Stone" },
                    { 2, 30, "Advanced C# Programming", "Fässberg", new DateTime(2024, 6, 20, 13, 0, 0, 0, DateTimeKind.Utc), "Maria Andersson" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "Courses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseId",
                value: null);
        }
    }
}
