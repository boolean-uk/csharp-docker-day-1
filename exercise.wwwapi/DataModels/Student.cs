using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DOB {  get; set; }
        public string CourseTitle { get; set; }

        public DateOnly StartDate { get; set; }

        public int AvarageGrade { get; set; }
    }
}
