using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Registration
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Column("average_grade")]
        public float AverageGrade { get; set; }

    }
}
