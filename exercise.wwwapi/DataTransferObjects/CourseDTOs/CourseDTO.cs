using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects.StudentDTO;

namespace exercise.wwwapi.DataTransferObjects.CourseDTOs
{
    internal record CourseDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AvailableSpots { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CourseStudentDTO>? Students { get; set; } = new List<CourseStudentDTO>();

        public CourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            AvailableSpots = course.AvailableSpots;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
            if (course.Students != null)
            {
                foreach (var student in course.Students)
                {
                    Students.Add(new CourseStudentDTO(student));
                }
            }

        }
    }
}