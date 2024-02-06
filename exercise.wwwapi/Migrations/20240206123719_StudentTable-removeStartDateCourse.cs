using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class StudentTableremoveStartDateCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDateOfCourse",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateOfCourse",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDateOfCourse",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDateOfCourse",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
