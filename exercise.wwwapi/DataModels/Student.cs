using exercise.wwwapi.DataTransferObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public required string FirstName { get; set; }
        [Column("last_name")]
        public required string LastName { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("average_grade")]
        public double AverageGrade { get; set; }

        public static StudentResponse ToResponseDTO(Student student)
        {
            return new StudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Course = Course.ToDTO(student.Course),
                StartDate = student.StartDate,
                AverageGrade = student.AverageGrade
            };
        }

        public static List<StudentResponse> ToResponseDTO(ICollection<Student> students)
        {
            List<StudentResponse> studentDTOs = new List<StudentResponse>();

            foreach (var student in students)
            {
                studentDTOs.Add(Student.ToResponseDTO(student));
            }

            return studentDTOs;
        }

        public static StudentDTO ToDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                StartDate = student.StartDate,
                AverageGrade = student.AverageGrade
            };
        }

        public static ICollection<StudentDTO> ToDTO(ICollection<Student> students)
        {
            var studentDTOs = new List<StudentDTO>();

            foreach (var student in students)
            {
                studentDTOs.Add(Student.ToDTO(student));
            }

            return studentDTOs;
        }
    }
}
