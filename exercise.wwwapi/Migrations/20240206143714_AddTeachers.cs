using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "teacher",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "start_date", "teacher" },
                values: new object[] { new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7197), "Ms. Rosamund" });

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "start_date", "teacher" },
                values: new object[] { new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7326), "Mr. Dostoyevski" });

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "start_date", "teacher" },
                values: new object[] { new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7331), "Mr. Bacon" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "dob",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                column: "dob",
                value: new DateTime(2024, 2, 6, 14, 37, 13, 732, DateTimeKind.Utc).AddTicks(7509));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teacher",
                table: "courses");

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "dob",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                column: "dob",
                value: new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9343));
        }
    }
}
