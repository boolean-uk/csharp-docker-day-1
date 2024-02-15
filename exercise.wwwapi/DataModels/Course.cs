namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public char AvgGrade { get; set; }
    }

    public class CourseDTO
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public char AvgGrade { get; set; }
    }
}
