using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class removedUnused : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.6399999999999997, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1980, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Middleton" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.1899999999999999, new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.9299999999999997, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1981, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 3.8100000000000001, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1973, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Barack", "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "last_name" },
                values: new object[] { 3.6600000000000001, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.77, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1995, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.6399999999999997, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1988, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.9800000000000004, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1980, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.9500000000000002, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1993, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name" },
                values: new object[] { 6.9800000000000004, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1972, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Mick" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.9700000000000006, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1975, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Oprah", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 9.7799999999999994, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1994, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Middleton" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 9.4600000000000009, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1996, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Oprah", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.23999999999999999, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1976, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.2699999999999996, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Donald", "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.8000000000000007, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 11, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.1900000000000004, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1989, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Presley" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.3600000000000003, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1971, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.6699999999999999, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1996, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.6299999999999999, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1982, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Donald", "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.5800000000000001, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2005, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Jimi", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.059999999999999998, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2007, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "last_name" },
                values: new object[] { 8.8499999999999996, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Middleton" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.1399999999999997, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1975, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.0599999999999996, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1970, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.96, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2002, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Jimi", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.5099999999999998, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1978, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Oprah", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.7000000000000002, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1996, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.3600000000000001, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2005, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Obama" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.4500000000000002, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1998, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 9.7899999999999991, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1984, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Middleton" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.5599999999999996, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2002, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.2300000000000004, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1982, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "last_name" },
                values: new object[] { 9.1099999999999994, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.1599999999999999, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2007, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.1799999999999999, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.3600000000000003, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.6699999999999999, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name" },
                values: new object[] { 4.4299999999999997, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1973, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Barack" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.6800000000000002, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2009, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.7699999999999996, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1983, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 3.5600000000000001, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2006, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Presley" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.71, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.1799999999999997, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.16, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.71, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1989, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.1500000000000004, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2000, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.4199999999999999, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1986, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.6900000000000004, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1974, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.0, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1975, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.5099999999999998, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "last_name" },
                values: new object[] { 8.9800000000000004, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2005, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.9399999999999999, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1975, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.5, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2006, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.0299999999999994, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.8900000000000006, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1991, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.65000000000000002, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1979, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.7899999999999991, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1981, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Hendrix" });
        }
    }
}
