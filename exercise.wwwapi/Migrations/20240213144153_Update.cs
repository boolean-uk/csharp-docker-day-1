using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.98, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2004, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.0399999999999991, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2000, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Donald", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.2300000000000004, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 8.2400000000000002, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2001, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Jimi" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.5899999999999999, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1986, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Presley" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name" },
                values: new object[] { 9.6199999999999992, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2006, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.1200000000000001, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1981, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 9.8900000000000006, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2001, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Mick" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 0.68000000000000005, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1976, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 7.9299999999999997, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2006, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Oprah" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.7000000000000002, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1983, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.46, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2007, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Presley" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.7899999999999991, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1973, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.79, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1979, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Barack", "Middleton" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.6900000000000004, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2000, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Donald", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.95, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1983, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Donald", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.4400000000000004, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1983, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "last_name" },
                values: new object[] { 3.5600000000000001, new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2002, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.4000000000000004, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1988, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Barack", "Presley" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.9000000000000004, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2001, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.28000000000000003, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1990, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Obama" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.97, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1998, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Emma", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.6600000000000001, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 8, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Oprah", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.4800000000000004, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2003, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 4.3700000000000001, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2001, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Donald" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 1.73, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1983, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Jacobsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.6800000000000002, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2004, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Trump" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.33000000000000002, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1972, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Jagger" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "last_name" },
                values: new object[] { 3.0299999999999998, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Hepburn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 5.4500000000000002, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1998, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Jacobsen" });

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
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 4.2300000000000004, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1982, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 9.1099999999999994, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hepburn" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name" },
                values: new object[] { 1.1599999999999999, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2007, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur" });

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
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 4.3600000000000003, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Kate" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 8.6699999999999999, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Kate" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 4.4299999999999997, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1973, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Barack" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.6800000000000002, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2009, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Audrey", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 6.7699999999999996, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1983, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Winfrey" });

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
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.16, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(1991, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Charles", "Winfrey" });

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
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "last_name" },
                values: new object[] { 4.1500000000000004, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2000, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.4199999999999999, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1986, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 7.6900000000000004, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1974, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 4.0, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1975, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Arthur", "Windsor" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.5099999999999998, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1977, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Hendrix" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.9800000000000004, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2005, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Olsen" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "average_grade", "course_date", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 2.9399999999999999, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1975, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Elvis", "Winfrey" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name" },
                values: new object[] { 4.5, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2006, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Emma" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 8.0299999999999994, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(1997, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Mick", "Olsen" });

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
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[] { 0.65000000000000002, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1979, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Kate", "Winslet" });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "average_grade", "course_date", "course_id", "date_of_birth", "last_name" },
                values: new object[] { 8.7899999999999991, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(1981, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Hendrix" });
        }
    }
}
