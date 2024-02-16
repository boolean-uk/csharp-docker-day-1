using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO : IStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CourseId { get; set; }

        public CourseDTO Course { get; set; }
    }
}
