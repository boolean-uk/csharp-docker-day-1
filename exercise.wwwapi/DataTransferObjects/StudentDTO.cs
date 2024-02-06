using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AvgGrade { get; set; }

        public StudentDTO(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            AvgGrade = student.AvgGrade;
        }
    }
}