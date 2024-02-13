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
                name: "course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_title = table.Column<string>(type: "text", nullable: false),
                    start_date_course = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "Date", nullable: false),
                    average_grade = table.Column<double>(type: "double precision", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_student_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "course_id", "start_date_course", "course_title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 14, 48, 17, 872, DateTimeKind.Local).AddTicks(5199), "Naturdag" },
                    { 2, new DateTime(2024, 2, 13, 14, 48, 17, 872, DateTimeKind.Local).AddTicks(5287), "Matte" },
                    { 3, new DateTime(2024, 2, 13, 14, 48, 17, 872, DateTimeKind.Local).AddTicks(5290), "Fargerer" },
                    { 4, new DateTime(2024, 2, 13, 14, 48, 17, 872, DateTimeKind.Local).AddTicks(5294), "Kjeddeeeelig" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "student_id", "average_grade", "CourseId", "dob", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 2.2000000000000002, 1, new DateTime(1998, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Idaa", "KK" },
                    { 2, 4.0999999999999996, 1, new DateTime(2002, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "DEW", "KK" },
                    { 3, 6.0, 2, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olkeee", "Bes" },
                    { 4, 5.5, 3, new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAAAA", "Vor AD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_CourseId",
                table: "student",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
