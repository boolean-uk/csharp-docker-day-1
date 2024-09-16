using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }


        [Column("lastname")]
        public string LastName { get; set; }

        [Column("birth")]
        public DateOnly Birth { get; set; }

        [ForeignKey("courseid")]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
