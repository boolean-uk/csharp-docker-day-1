using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]

    public class Student
    {
        [Column("student_id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("course_title")]
        public string CourseTitle { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("grade")]
        public double Grade { get; set; }

    }
}
