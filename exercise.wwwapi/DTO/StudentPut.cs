using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class StudentPut
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string CourseTitle { get; set; }
        public DateTime Startdate { get; set; }
        public double AvgGrade { get; set; }
        public int CourseId { get; set; }
    }
}
