using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class initialDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "students",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "course_start_date",
                table: "couses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 1,
                column: "course_start_date",
                value: new DateTime(2024, 1, 4, 12, 12, 12, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 2,
                column: "course_start_date",
                value: new DateTime(2024, 6, 15, 12, 12, 12, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 3,
                column: "course_start_date",
                value: new DateTime(2025, 1, 26, 12, 12, 12, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "date_of_birth",
                value: new DateTime(2000, 1, 26, 12, 12, 12, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "date_of_birth",
                value: new DateTime(2000, 6, 3, 12, 12, 12, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                column: "date_of_birth",
                value: new DateTime(2000, 12, 15, 12, 12, 12, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_birth",
                table: "students",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "course_start_date",
                table: "couses",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 1,
                column: "course_start_date",
                value: new DateOnly(2024, 1, 4));

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 2,
                column: "course_start_date",
                value: new DateOnly(2024, 6, 15));

            migrationBuilder.UpdateData(
                table: "couses",
                keyColumn: "id",
                keyValue: 3,
                column: "course_start_date",
                value: new DateOnly(2025, 1, 26));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                column: "date_of_birth",
                value: new DateOnly(2000, 1, 26));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                column: "date_of_birth",
                value: new DateOnly(2000, 6, 3));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                column: "date_of_birth",
                value: new DateOnly(2000, 12, 15));
        }
    }
}
