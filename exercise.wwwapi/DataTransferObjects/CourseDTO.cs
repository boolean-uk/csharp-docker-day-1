using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CourseStart { get; set; }
        public double AverageGrade { get; set; }


        public CourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            CourseStart = course.CourseStart;
            AverageGrade = course.AverageGrade;
        }
    }
}
