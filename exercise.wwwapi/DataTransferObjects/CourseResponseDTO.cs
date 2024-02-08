using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            StartDate = course.StartDate;

            foreach (var student in course.Students)
                Students.Add(new StudentDTO(student));
        }

        public static List<CourseResponseDTO> FromRepository(IEnumerable<Course> courses)
        {
            var results = new List<CourseResponseDTO>();
            foreach (var course in courses)
                results.Add(new CourseResponseDTO(course));
            return results;
        }

        public static CourseResponseDTO FromARepository(Course course)
        {
            CourseResponseDTO result = new CourseResponseDTO(course);
            return result;
        }
    }
}
