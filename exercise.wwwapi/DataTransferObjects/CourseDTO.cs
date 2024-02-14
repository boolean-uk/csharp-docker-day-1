using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
    }
}
