using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public StudentResponseDTO(Student student) 
        {
            Id = student.Id;
            firstName = student.FirstName;
            lastName = student.LastName;
        }
    }
}
