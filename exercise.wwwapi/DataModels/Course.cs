using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
