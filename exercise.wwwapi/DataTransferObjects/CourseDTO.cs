using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class ResponseCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public float AverageGrade { get; set; }
        List<ResponseStudentDTOCourseLess> Students { get; set; } = new List<ResponseStudentDTOCourseLess>();

        public ResponseCourseDTO(Course model)
        {
            Id = model.Id;
            Title = model.Title;
            StartDate = model.StartDate.ToString();
            AverageGrade = model.AverageGrade;
            Students = model.Students.Select(student => new ResponseStudentDTOCourseLess(student)).ToList();
        }
    }

    public class ResponseCourseDTOStudentLess
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public float AverageGrade { get; set; }
        public ResponseCourseDTOStudentLess(Course model)
        {
            Id = model.Id;
            Title = model.Title;
            StartDate = model.StartDate.ToString();
            AverageGrade = model.AverageGrade;
        }
    }

    public class PostCourseDTO
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public float AverageGrade { get; set; }
    }

    public class PutCourseDTO
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public float AverageGrade { get; set; }
    }
}
