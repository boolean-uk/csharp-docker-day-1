using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_course_CourseId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_students_course_description_fk",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_description_fk",
                table: "students");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_course_description",
                table: "course");

            migrationBuilder.DropColumn(
                name: "description_fk",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_students_course_CourseId",
                table: "students",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_course_CourseId",
                table: "students");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "description_fk",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_course_description",
                table: "course",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "IX_students_description_fk",
                table: "students",
                column: "description_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_students_course_CourseId",
                table: "students",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_course_description_fk",
                table: "students",
                column: "description_fk",
                principalTable: "course",
                principalColumn: "description",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
