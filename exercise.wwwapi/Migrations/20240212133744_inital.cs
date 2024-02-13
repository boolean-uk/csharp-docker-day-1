using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
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
                    average_grade = table.Column<double>(type: "double precision", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_fk_course_id",
                        column: x => x.fk_course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "average_grade", "course_name", "start_date" },
                values: new object[,]
                {
                    { 1, 90.5, "Programming 101", new DateTime(2023, 12, 12, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(6838) },
                    { 2, 85.0, "Web Development Fundamentals", new DateTime(2024, 2, 10, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(6852) },
                    { 3, 88.200000000000003, "Data Structures and Algorithms", new DateTime(2023, 10, 12, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(6856) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "fk_course_id", "date_of_birth", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2004, 11, 5, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(6994), "Student1", "Last1" },
                    { 2, 1, new DateTime(2004, 4, 10, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7022), "Student2", "Last2" },
                    { 3, 2, new DateTime(2004, 5, 11, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7033), "Student3", "Last3" },
                    { 4, 1, new DateTime(2004, 11, 17, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7042), "Student4", "Last4" },
                    { 5, 2, new DateTime(2004, 4, 8, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7052), "Student5", "Last5" },
                    { 6, 2, new DateTime(2004, 3, 24, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7063), "Student6", "Last6" },
                    { 7, 2, new DateTime(2004, 8, 18, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7073), "Student7", "Last7" },
                    { 8, 2, new DateTime(2004, 9, 15, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7082), "Student8", "Last8" },
                    { 9, 2, new DateTime(2004, 3, 1, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7091), "Student9", "Last9" },
                    { 10, 2, new DateTime(2004, 6, 29, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(7104), "Student10", "Last10" },
                    { 11, 2, new DateTime(2004, 8, 8, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9715), "Student11", "Last11" },
                    { 12, 2, new DateTime(2004, 6, 30, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9848), "Student12", "Last12" },
                    { 13, 2, new DateTime(2004, 3, 18, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9885), "Student13", "Last13" },
                    { 14, 3, new DateTime(2004, 5, 8, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9918), "Student14", "Last14" },
                    { 15, 2, new DateTime(2004, 9, 23, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9949), "Student15", "Last15" },
                    { 16, 3, new DateTime(2004, 7, 27, 13, 37, 44, 509, DateTimeKind.Utc).AddTicks(9980), "Student16", "Last16" },
                    { 17, 2, new DateTime(2004, 7, 5, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(11), "Student17", "Last17" },
                    { 18, 3, new DateTime(2004, 9, 3, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(54), "Student18", "Last18" },
                    { 19, 2, new DateTime(2004, 12, 29, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(86), "Student19", "Last19" },
                    { 20, 2, new DateTime(2004, 12, 8, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(116), "Student20", "Last20" },
                    { 21, 1, new DateTime(2004, 4, 8, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(147), "Student21", "Last21" },
                    { 22, 3, new DateTime(2004, 2, 13, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(177), "Student22", "Last22" },
                    { 23, 2, new DateTime(2004, 3, 5, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(206), "Student23", "Last23" },
                    { 24, 2, new DateTime(2004, 2, 21, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(236), "Student24", "Last24" },
                    { 25, 2, new DateTime(2004, 6, 28, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(266), "Student25", "Last25" },
                    { 26, 3, new DateTime(2004, 4, 18, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(295), "Student26", "Last26" },
                    { 27, 3, new DateTime(2004, 10, 28, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(325), "Student27", "Last27" },
                    { 28, 3, new DateTime(2004, 11, 14, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(355), "Student28", "Last28" },
                    { 29, 1, new DateTime(2004, 4, 28, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(386), "Student29", "Last29" },
                    { 30, 2, new DateTime(2004, 7, 20, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(887), "Student30", "Last30" },
                    { 31, 3, new DateTime(2004, 11, 24, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1117), "Student31", "Last31" },
                    { 32, 2, new DateTime(2005, 1, 11, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1154), "Student32", "Last32" },
                    { 33, 2, new DateTime(2005, 1, 6, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1301), "Student33", "Last33" },
                    { 34, 3, new DateTime(2004, 11, 26, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1369), "Student34", "Last34" },
                    { 35, 1, new DateTime(2004, 9, 19, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1659), "Student35", "Last35" },
                    { 36, 3, new DateTime(2005, 1, 8, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1678), "Student36", "Last36" },
                    { 37, 3, new DateTime(2004, 7, 6, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1689), "Student37", "Last37" },
                    { 38, 3, new DateTime(2004, 2, 26, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1699), "Student38", "Last38" },
                    { 39, 1, new DateTime(2004, 12, 16, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1709), "Student39", "Last39" },
                    { 40, 1, new DateTime(2004, 12, 8, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1718), "Student40", "Last40" },
                    { 41, 3, new DateTime(2005, 1, 20, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1727), "Student41", "Last41" },
                    { 42, 1, new DateTime(2005, 1, 5, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1736), "Student42", "Last42" },
                    { 43, 2, new DateTime(2005, 2, 1, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1745), "Student43", "Last43" },
                    { 44, 2, new DateTime(2004, 2, 21, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1753), "Student44", "Last44" },
                    { 45, 3, new DateTime(2004, 5, 16, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1761), "Student45", "Last45" },
                    { 46, 3, new DateTime(2004, 3, 15, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1770), "Student46", "Last46" },
                    { 47, 2, new DateTime(2004, 10, 1, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1779), "Student47", "Last47" },
                    { 48, 3, new DateTime(2004, 12, 10, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1788), "Student48", "Last48" },
                    { 49, 2, new DateTime(2004, 9, 28, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1797), "Student49", "Last49" },
                    { 50, 3, new DateTime(2004, 3, 19, 13, 37, 44, 510, DateTimeKind.Utc).AddTicks(1805), "Student50", "Last50" }
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
