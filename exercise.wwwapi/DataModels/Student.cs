using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("birth_date")]
        public DateTimeOffset BirthDate { get; set; }

        [Column("title")]
        public string CourseTitle { get; set; }

        [Column("start_date")]
        public DateTimeOffset StartDate { get; set; }

        [Column("avg_grade")]
        public int AvgGrade { get; set; }

        // Foreign Key
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
