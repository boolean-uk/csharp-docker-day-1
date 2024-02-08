namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TutorName { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public List<Student> students { get; set; }
        

    }
}
