using exercise.wwwapi.Models.Interfaces;

namespace exercise.wwwapi.Models.Models.Students
{
    public class StudentPut : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
