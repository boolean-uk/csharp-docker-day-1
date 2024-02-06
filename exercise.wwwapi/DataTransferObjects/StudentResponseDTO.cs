using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string AverageGrade { get; set; }

        public int CourseId { get; set; }

        public CourseDTO Course { get; set; }

        public StudentResponseDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Birthday = student.Birthday;
            AverageGrade = student.AverageGrade;
            CourseId = student.CourseId;
            Course = new CourseDTO(student.Course);
        }

        public static List<StudentResponseDTO> FromRepository(IEnumerable<Student> students)
        {
            var results = new List<StudentResponseDTO>();
            foreach (var student in students)
                results.Add(new StudentResponseDTO(student));
            return results;
        }

        public static StudentResponseDTO FromARepository(Student student)
        {
            StudentResponseDTO result = new StudentResponseDTO(student);
            return result;
        }
    }
}
