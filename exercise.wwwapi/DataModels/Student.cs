using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Student")]
    public class Student
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Course_Id")]
        public int CourseID { get; set; }

        public Course Course { get; set; }


    }
}
