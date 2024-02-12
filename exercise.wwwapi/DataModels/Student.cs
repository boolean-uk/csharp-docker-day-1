using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Students")]
    public class Student
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public string DateOfBirth { get; set; }

        [Column("avrage_grade")]
        public int AvrageGrade { get; set; }

        [Column("course_id")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
