namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public DateTime StartDate { get; set; }

        public int AverageGrade { get; set; }
    }
}
