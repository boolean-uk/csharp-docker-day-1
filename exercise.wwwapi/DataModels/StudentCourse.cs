using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    [Table("studentCourses")]
    public class StudentCourse
    {
        [ForeignKey("Student")]
        [Column("studentId")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        [Column("courseId")]
        public int CourseId { get; set; }
    }
}
