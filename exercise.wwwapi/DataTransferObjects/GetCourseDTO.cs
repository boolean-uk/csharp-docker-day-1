namespace exercise.wwwapi.DataTransferObjects
{
    public class GetCourseDTO
    {
        public string CourseTitle { get; set; }
        public List<GetStudentDTO> Students { get; set; }
    }
}
