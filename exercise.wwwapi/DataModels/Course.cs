using exercise.wwwapi.DataTransferObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("course_name")]
        public required string CourseName { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public static CourseDTO ToDTO(Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                CourseName = course.CourseName
            };
        }

        public static ICollection<CourseDTO> ToDTO(ICollection<Course> course)
        {
            List<CourseDTO> courseDTOs = new List<CourseDTO>();

            foreach (var c in course)
            {
                courseDTOs.Add(Course.ToDTO(c));
            }

            return courseDTOs;
        }

        public static CourseResponse ToResponseDTO(Course course)
        {
            return new CourseResponse
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Students = Student.ToDTO(course.Students)
            };
        }

        public static ICollection<CourseResponse> ToResponseDTO(ICollection<Course> courses)
        {
            var courseDTOs = new List<CourseResponse>();

            foreach (var course in courses)
            {
                courseDTOs.Add(Course.ToResponseDTO(course));
            }

            return courseDTOs;
        }
    }
}
