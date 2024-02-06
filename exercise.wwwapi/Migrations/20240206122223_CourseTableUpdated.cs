using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CourseTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "TutorName");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TutorName",
                table: "Courses",
                newName: "Name");
        }
    }
}
