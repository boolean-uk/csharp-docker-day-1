using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB {  get; set; } = DateTime.UtcNow;
        public Course Course{ get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public DateTime CourseStartDate { get; set; } = DateTime.UtcNow.AddDays(1);
        public double average_grade { get; set; }

    }
}
