using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects.Courses;

namespace exercise.wwwapi.DataTransferObjects.Students
{
    public class GetStudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
