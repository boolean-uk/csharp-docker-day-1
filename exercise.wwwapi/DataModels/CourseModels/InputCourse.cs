namespace exercise.wwwapi.DataModels.CourseModels
{
    public class InputCourse
    {
        public string Title { get; set; }

        public DateTime Starts { get; set; }

        public IEnumerable<int> StudentIds { get; set; }
    }
}
