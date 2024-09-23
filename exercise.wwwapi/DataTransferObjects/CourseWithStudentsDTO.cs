using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseWithStudentsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public double AverageGrade { get; set; }
        public List<StudentWithNoCourseDTO> Students { get; set; } = new List<StudentWithNoCourseDTO>();
    }
}
