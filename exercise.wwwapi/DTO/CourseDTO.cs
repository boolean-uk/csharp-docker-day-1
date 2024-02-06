using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class CourseDTO
    {
        public string CourseTitle { get; set; }
        public DateTimeOffset CourseStartDate { get; set; }
        public List<StudentListDataDTO> Student { get; set; }

        public CourseDTO(Course course) {
            CourseTitle = course.CourseTitle;
            CourseStartDate = course.CourseStartDate;

            
        }
    }
}
