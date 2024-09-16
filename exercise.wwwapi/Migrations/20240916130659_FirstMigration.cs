using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    CourseStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageGrade = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseTitle" },
                values: new object[,]
                {
                    { 1, "Math201" },
                    { 2, "Kitchen2001" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AverageGrade", "CourseId", "CourseStart", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 4.2000000000000002, 1, new DateTime(2024, 9, 20, 13, 6, 56, 304, DateTimeKind.Utc).AddTicks(2261), new DateOnly(2000, 9, 6), "John", "Bravo" },
                    { 2, 2.2000000000000002, 2, new DateTime(2024, 9, 21, 13, 6, 56, 304, DateTimeKind.Utc).AddTicks(2293), new DateOnly(2003, 10, 6), "Thomas", "Flya" },
                    { 3, 4.7999999999999998, 2, new DateTime(2024, 9, 21, 13, 6, 56, 304, DateTimeKind.Utc).AddTicks(2298), new DateOnly(1999, 6, 26), "Melvin", "Linderud" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
