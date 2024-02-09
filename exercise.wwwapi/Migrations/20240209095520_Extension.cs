using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Extension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "average_grade",
                table: "students");

            migrationBuilder.DropColumn(
                name: "course_title",
                table: "students");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "students");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "courses",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "course_title",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "start_date",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    average_grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.student_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_Registrations_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "course_title", "start_date" },
                values: new object[,]
                {
                    { 1, "Theater", "31-1-2024" },
                    { 2, "Science", "28-1-2024" },
                    { 3, "Piano", "2-2-2024" },
                    { 4, "Chess", "5-2-2024" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 3, "3-4-2002", "Neomi", "Bes" },
                    { 4, "22-10-2005", "Quinten", "van Koeverden" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "course_id", "student_id", "average_grade", "id" },
                values: new object[,]
                {
                    { 2, 1, 9.5f, 5 },
                    { 4, 1, 8.5f, 1 },
                    { 1, 2, 9.3f, 2 },
                    { 3, 2, 8.6f, 1 },
                    { 1, 3, 8.8f, 3 },
                    { 2, 4, 7.5f, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_course_id",
                table: "Registrations",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "course_title",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Courses",
                newName: "Id");

            migrationBuilder.AddColumn<float>(
                name: "average_grade",
                table: "students",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "course_title",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "start_date",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grade", "course_title", "start_date" },
                values: new object[] { 9f, "Science", "31-8-2023" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grade", "course_title", "start_date" },
                values: new object[] { 7f, "Theater", "31-8-2023" });
        }
    }
}
