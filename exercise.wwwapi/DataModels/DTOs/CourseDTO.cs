using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels.DTOs
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
        public List<GetCourseStudentDTO> Students { get; set; } = new List<GetCourseStudentDTO>();
    }

    public class GetStudentCourseDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
    }

    public class PostCourseDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
    }

    public class PatchCourseDTO
    {
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public double? AverageGrade { get; set; }
    }
}
