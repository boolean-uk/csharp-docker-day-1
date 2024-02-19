using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class dockertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_name = table.Column<string>(type: "text", nullable: false),
                    avg_grade = table.Column<double>(type: "double precision", nullable: false),
                    start_of_course = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_fk_course_id",
                        column: x => x.fk_course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "avg_grade", "course_name", "start_of_course" },
                values: new object[,]
                {
                    { 1, 90.5, "Programming 101", new DateTime(2023, 12, 16, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(5861) },
                    { 2, 85.0, "Web Development Fundamentals", new DateTime(2024, 2, 14, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(5872) },
                    { 3, 88.200000000000003, "Data Structures and Algorithms", new DateTime(2023, 10, 16, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(5882) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "fk_course_id", "dob", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1824, 7, 8, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6150), "Minion1", "Banana" },
                    { 2, 1, new DateTime(1824, 2, 29, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6183), "Minion2", "Banana" },
                    { 3, 1, new DateTime(1824, 4, 28, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6201), "Minion3", "Banana" },
                    { 4, 2, new DateTime(1825, 1, 15, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6219), "Minion4", "Banana" },
                    { 5, 2, new DateTime(1824, 6, 21, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6238), "Minion5", "Banana" },
                    { 6, 2, new DateTime(1824, 2, 22, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6257), "Minion6", "Banana" },
                    { 7, 2, new DateTime(1824, 10, 1, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6274), "Minion7", "Banana" },
                    { 8, 3, new DateTime(1824, 9, 14, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6292), "Minion8", "Banana" },
                    { 9, 1, new DateTime(1825, 1, 30, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6309), "Minion9", "Banana" },
                    { 10, 3, new DateTime(1824, 8, 12, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6373), "Minion10", "Banana" },
                    { 11, 2, new DateTime(1824, 9, 27, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6391), "Minion11", "Banana" },
                    { 12, 1, new DateTime(1824, 5, 7, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6409), "Minion12", "Banana" },
                    { 13, 2, new DateTime(1824, 8, 5, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6426), "Minion13", "Banana" },
                    { 14, 3, new DateTime(1824, 5, 20, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6444), "Minion14", "Banana" },
                    { 15, 2, new DateTime(1824, 10, 26, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6461), "Minion15", "Banana" },
                    { 16, 3, new DateTime(1824, 5, 28, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6479), "Minion16", "Banana" },
                    { 17, 3, new DateTime(1824, 7, 13, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6495), "Minion17", "Banana" },
                    { 18, 1, new DateTime(1824, 8, 21, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6514), "Minion18", "Banana" },
                    { 19, 2, new DateTime(1824, 12, 12, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6530), "Minion19", "Banana" },
                    { 20, 1, new DateTime(1824, 8, 6, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6547), "Minion20", "Banana" },
                    { 21, 3, new DateTime(1824, 12, 6, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6564), "Minion21", "Banana" },
                    { 22, 1, new DateTime(1824, 4, 7, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6581), "Minion22", "Banana" },
                    { 23, 2, new DateTime(1824, 4, 28, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6597), "Minion23", "Banana" },
                    { 24, 2, new DateTime(1824, 9, 15, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6614), "Minion24", "Banana" },
                    { 25, 1, new DateTime(1824, 4, 17, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6629), "Minion25", "Banana" },
                    { 26, 3, new DateTime(1824, 3, 14, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6644), "Minion26", "Banana" },
                    { 27, 1, new DateTime(1824, 5, 6, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6662), "Minion27", "Banana" },
                    { 28, 1, new DateTime(1824, 9, 18, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6677), "Minion28", "Banana" },
                    { 29, 3, new DateTime(1824, 4, 28, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6693), "Minion29", "Banana" },
                    { 30, 1, new DateTime(1825, 1, 13, 9, 59, 32, 754, DateTimeKind.Utc).AddTicks(6709), "Minion30", "Banana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_fk_course_id",
                table: "Students",
                column: "fk_course_id");
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
