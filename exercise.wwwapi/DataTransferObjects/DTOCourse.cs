
namespace exercise.wwwapi.DataTransferObjects
{
    public class DTOCourse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartsAt { get; set; }
        public char AverageGrade { get; set; }

        public List<StudentForCourse> Students { get; set; } = new List<StudentForCourse>();
    }
}
