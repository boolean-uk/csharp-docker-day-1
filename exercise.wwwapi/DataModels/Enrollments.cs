using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
        [Table("enrollments")]
        public class Enrollments
        {
            [Column("title")]
            public string Title { get; set; }

            [Column("start_date")]
            public DateOnly StartDate { get; set; }
            [Column("student_id")]
            public int StudentId { get; set; }
            public Student Student { get; set; }
            [Column("course_id")]
            public int CourseId { get; set; }
            public Course Course { get; set; }
        }
}
