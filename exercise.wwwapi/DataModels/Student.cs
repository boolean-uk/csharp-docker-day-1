using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth")]
        public DateOnly DateOfBirth { get; set; }

        [Column("average_grade")]
        public float AvgGrade { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; } 

        //public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
