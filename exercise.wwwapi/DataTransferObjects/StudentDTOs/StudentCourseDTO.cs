using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.StudentDTO
{
    public class StudentCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AvailableSpots { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public StudentCourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            AvailableSpots = course.AvailableSpots;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
        }
    }
}