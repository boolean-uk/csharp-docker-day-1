using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.StudentDTO
{
    public record CourseStudentDTO
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public float AverageGrade { get; set; }

        public CourseStudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Birthdate = student.Birthdate;
            AverageGrade = student.AverageGrade;
        }
    }
}
