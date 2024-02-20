using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Column("course_id")]
        public int Id { get; set; }
        [Column("course_title")]
        public string Title { get; set; }
        [Column("course_date_started")]
        public DateTime CourseStart { get; set; }
        [Column("averageGrade")]
        public double AverageGrade { get; set; }
    }
}
