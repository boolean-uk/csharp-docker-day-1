using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.StudentDTO
{
    public record StudentDTO
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public float AverageGrade { get; set; }
        public StudentCourseDTO Course { get; set; } = null!;

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Birthdate = student.Birthdate;
            AverageGrade = student.AverageGrade;
            if (student.Course != null)
            {
                Course = new StudentCourseDTO(student.Course);
            }

        }
    }
}
