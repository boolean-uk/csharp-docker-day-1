namespace exercise.wwwapi.DataTransferObjects.StudentCourse
{
    public class GetStudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime StartDate { get; set; }
        public float AvgGrade { get; set; }
    }
}
