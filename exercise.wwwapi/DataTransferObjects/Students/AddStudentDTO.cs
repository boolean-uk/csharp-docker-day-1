using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.Students
{
    public class AddStudentDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
