using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class CourseDTO
    {
       
        public int Id { get; set; }
        public string CourseTitle { get; set; }        
        public DateTimeOffset CourseStartDate { get; set; }
        public ICollection<StudentDTO> Students { get; set; }

        public CourseDTO(Course course) { 
            Id = course.Id;
            CourseTitle = course.CourseTitle;
            CourseStartDate = course.CourseStartDate;
            Students = new List<StudentDTO>();
            foreach (var student in course.Students)
            {
                Students.Add(new StudentDTO(student));
            }
        }
    }
}
