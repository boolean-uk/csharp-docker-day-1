namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public string? AverageGrade { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
