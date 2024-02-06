using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public CourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            StartDate = course.StartDate;
        }
    }
}
