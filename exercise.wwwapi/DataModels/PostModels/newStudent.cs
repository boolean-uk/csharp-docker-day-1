using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels.PostModels
{
    public class NewStudent
    {
        public string FirstName { get; set; } = "Firstname";
        public string LastName { get; set; } = "Lastname";
        public DateTime DateOfBirth { get; set; } = new DateTime(1990,01,01);
        public int CourseId { get; set; } = 1;
        public DateTime CourseDate { get; set; } = DateTime.UtcNow;
        public double AverageGrade { get; set; } = 0.00;


    }
}
