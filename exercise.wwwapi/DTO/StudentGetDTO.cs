using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DTO
{
    public class StudentGetDTO
    {
        public string Name { get; set; }
        public List<CourseGetDTO> Courses { get; }
        public List<StudentCourseDTO> StudentCourses { get; }
    }
}
