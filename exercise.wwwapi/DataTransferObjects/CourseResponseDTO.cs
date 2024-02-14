using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string startDate { get; set; }

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            startDate = course.StartDate;
        }
    }
}