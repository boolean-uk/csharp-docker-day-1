using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentPayload
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();

        public StudentPayload(Student student)
        {
            this.Id = student.Id;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.BirthDate = student.BirthDate;
            foreach (var course in student.StudentCourses)
            {
                this.Courses.Add(new CourseDTO(course.Course));
            }
        }
    }
}
