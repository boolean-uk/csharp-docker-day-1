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
                value: new DateOnly(2026, 1, 20));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date_of_courses",
                value: new DateOnly(2022, 7, 31));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date_of_courses",
                value: new DateOnly(2025, 5, 20));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4,
                column: "start_date_of_courses",
                value: new DateOnly(2023, 5, 8));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5,
                column: "start_date_of_courses",
                value: new DateOnly(2022, 11, 12));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6,
                column: "start_date_of_courses",
                value: new DateOnly(2025, 8, 1));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 7,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 8, 2));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 8,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 4, 24));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 9,
                column: "start_date_of_courses",
                value: new DateOnly(2030, 3, 15));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 10,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 6, 20));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { new List<int> { 1 }, new DateOnly(2028, 1, 25), "Duck" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { 1, new List<int> { 2 }, new DateOnly(2026, 7, 16), "Xavier" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 3 }, new DateOnly(2030, 10, 21), "Felix", "Winslow" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 4 }, new DateOnly(2026, 12, 9), "Adam", "Sandler" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 5, new List<int> { 5 }, new DateOnly(2029, 10, 14), "Elvis", "Schwarzenegger" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { 5, new List<int> { 6 }, new DateOnly(2022, 1, 11), "Xavier" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 7 }, new DateOnly(2027, 6, 12), "Charles", "Andersson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 3, new List<int> { 8 }, new DateOnly(2030, 9, 23), "Oprah", "Winslow" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 2, new List<int> { 9 }, new DateOnly(2023, 5, 24), "Oprah", "Schwarzenegger" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 1, new List<int> { 10 }, new DateOnly(2023, 11, 28), "Elvis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 1,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 2, 2));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2,
                column: "start_date_of_courses",
                value: new DateOnly(2029, 1, 31));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3,
                column: "start_date_of_courses",
                value: new DateOnly(2023, 6, 30));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4,
                column: "start_date_of_courses",
                value: new DateOnly(2029, 7, 31));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5,
                column: "start_date_of_courses",
                value: new DateOnly(2023, 1, 18));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6,
                column: "start_date_of_courses",
                value: new DateOnly(2024, 9, 17));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 7,
                column: "start_date_of_courses",
                value: new DateOnly(2028, 8, 6));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 8,
                column: "start_date_of_courses",
                value: new DateOnly(2022, 4, 5));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 9,
                column: "start_date_of_courses",
                value: new DateOnly(2025, 8, 26));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 10,
                column: "start_date_of_courses",
                value: new DateOnly(2026, 12, 19));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { new List<int> { 1 }, new DateOnly(2030, 6, 1), "Mathiasson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { 2, new List<int> { 2 }, new DateOnly(2029, 1, 10), "Lothbrok" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 4, new List<int> { 3 }, new DateOnly(2029, 6, 8), "Kate", "Lothbrok" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 3, new List<int> { 4 }, new DateOnly(2022, 12, 23), "Mickey", "Andersson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 1, new List<int> { 5 }, new DateOnly(2030, 9, 6), "Mickey", "Obama" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "last_names" },
                values: new object[] { 3, new List<int> { 6 }, new DateOnly(2027, 1, 15), "Andersson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { new List<int> { 7 }, new DateOnly(2024, 3, 30), "Barack", "Duck" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 4, new List<int> { 8 }, new DateOnly(2026, 12, 24), "Neo", "Presley" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names", "last_names" },
                values: new object[] { 3, new List<int> { 9 }, new DateOnly(2028, 5, 29), "Neo", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grades", "course_id's", "dates_of_birth", "first_names" },
                values: new object[] { 4, new List<int> { 10 }, new DateOnly(2026, 5, 7), "Adam" });
        }
    }
}
