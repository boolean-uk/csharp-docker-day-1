using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public decimal AvgGrade { get; set; } = 0m;
    }
}
