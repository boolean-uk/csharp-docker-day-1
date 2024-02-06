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

        [Column("birthday")]
        public string Birthday { get; set; }

        [Column("average_grade")]
        public string AverageGrade { get; set; }

        [Column("course_id")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
