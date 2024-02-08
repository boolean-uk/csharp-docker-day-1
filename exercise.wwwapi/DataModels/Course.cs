using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("course_title")]
        public string CourseTitle { get; set; }

        [Column("course_start_date")]
        public string CourseStartDate { get; set; }

        [Column("average_grade")]
        public int grade { get; set; } //gives average grade from 0 - 10
    }
}
