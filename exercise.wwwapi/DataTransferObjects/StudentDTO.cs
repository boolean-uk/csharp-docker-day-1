using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<StudentRegistrationDTO> Registrations { get; set; }
        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
            Registrations = new List<StudentRegistrationDTO>();
            if (student.Registrations is null) return;
            foreach (Registration registration in student.Registrations)
            {
                Registrations.Add(new StudentRegistrationDTO(registration));
            }
        }
    }

    public class RegistrationStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public RegistrationStudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
        }
    }
}
