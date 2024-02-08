using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Updatestudenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_courses_course_id",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "course_id",
                table: "students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "end_date", "start_date" },
                values: new object[] { new DateTime(2024, 6, 5, 13, 5, 57, 518, DateTimeKind.Utc).AddTicks(7518), new DateTime(2024, 2, 13, 14, 5, 57, 518, DateTimeKind.Utc).AddTicks(7447) });

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "end_date", "start_date" },
                values: new object[] { new DateTime(2024, 5, 6, 13, 5, 57, 518, DateTimeKind.Utc).AddTicks(7526), new DateTime(2024, 2, 20, 14, 5, 57, 518, DateTimeKind.Utc).AddTicks(7524) });

            migrationBuilder.AddForeignKey(
                name: "FK_students_courses_course_id",
                table: "students",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_courses_course_id",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "course_id",
                table: "students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "end_date", "start_date" },
                values: new object[] { new DateTime(2024, 6, 5, 12, 33, 56, 244, DateTimeKind.Utc).AddTicks(5716), new DateTime(2024, 2, 13, 13, 33, 56, 244, DateTimeKind.Utc).AddTicks(5644) });

            migrationBuilder.UpdateData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "end_date", "start_date" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 33, 56, 244, DateTimeKind.Utc).AddTicks(5724), new DateTime(2024, 2, 20, 13, 33, 56, 244, DateTimeKind.Utc).AddTicks(5722) });

            migrationBuilder.AddForeignKey(
                name: "FK_students_courses_course_id",
                table: "students",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
