using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 5, 3));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date_of_courses",
                value: new DateOnly(2030, 1, 18));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date_of_courses",
                value: new DateOnly(2028, 2, 10));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4,
                column: "start_date_of_courses",
                value: new DateOnly(2029, 1, 3));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5,
                column: "start_date_of_courses",
                value: new DateOnly(2030, 10, 29));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 12, 24));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 7,
                column: "start_date_of_courses",
                value: new DateOnly(2030, 5, 31));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 8,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 5, 2));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 9,
                column: "start_date_of_courses",
                value: new DateOnly(2028, 4, 28));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 10,
                column: "start_date_of_courses",
                value: new DateOnly(2023, 7, 24));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 1, new List<int> { 1, 10 }, new DateOnly(2026, 1, 24), "Ragnar" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 1, new List<int> { 2, 9 }, new DateOnly(2026, 12, 24), "Felix", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 3, 8 }, new DateOnly(2022, 8, 27), "Barack", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 4, new List<int> { 4, 7 }, new DateOnly(2030, 7, 8), "Kate", "Presley" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 5, new List<int> { 5, 6 }, new DateOnly(2024, 10, 22), "Neo", "Lothbrok" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 6, 5 }, new DateOnly(2022, 5, 13), "Arnold", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 7, 4 }, new DateOnly(2028, 1, 15), "Barack", "Lothbrok" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 1, new List<int> { 8, 3 }, new DateOnly(2025, 10, 15), "Arnold", "Mathiasson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 9, 2 }, new DateOnly(2025, 4, 12), "Neo", "Sandler" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 1, new List<int> { 10, 1 }, new DateOnly(2028, 1, 28), "Arnold" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date_of_courses",
                value: new DateOnly(2029, 10, 5));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date_of_courses",
                value: new DateOnly(2027, 2, 13));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 9, 20));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5,
                column: "start_date_of_courses",
                value: new DateOnly(2029, 1, 18));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 4, 3));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 7,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 1, 3));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 8,
                column: "start_date_of_courses",
                value: new DateOnly(2023, 5, 29));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 9,
                column: "start_date_of_courses",
                value: new DateOnly(2030, 9, 5));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 10,
                column: "start_date_of_courses",
                value: new DateOnly(2027, 6, 7));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 5, new List<int> { 1 }, new DateOnly(2027, 6, 15), "Felix" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 4, new List<int> { 2 }, new DateOnly(2027, 7, 18), "Mickey", "Sandler" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 3 }, new DateOnly(2026, 3, 19), "Arnold", "Lothbrok" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 4 }, new DateOnly(2024, 5, 21), "Adam", "Schwarzenegger" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 5 }, new DateOnly(2028, 8, 7), "Donald", "Xavier" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 6 }, new DateOnly(2029, 10, 19), "Felix", "Xavier" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 3, new List<int> { 7 }, new DateOnly(2027, 1, 5), "Kate", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 4, new List<int> { 8 }, new DateOnly(2025, 4, 18), "Neo", "Duck" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 9 }, new DateOnly(2028, 2, 28), "Kate", "Schwarzenegger" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 4, new List<int> { 10 }, new DateOnly(2029, 1, 3), "Charles" });
        }
    }
}
