namespace exercise.wwwapi.DTOs
{
    public class GetStudentDTO
    {

        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int courseId { get; set; }
    }
}
