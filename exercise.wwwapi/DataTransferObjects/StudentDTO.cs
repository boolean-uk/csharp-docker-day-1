using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }

        public StudentDTO(Student student)
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.BirthDate = student.BirthDate;
        }
    }
}
