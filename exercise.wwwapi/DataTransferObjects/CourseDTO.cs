using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string StartDate { get; set; }
        public ICollection<CourseRegistrationDTO> Registrations { get; set; }
        public CourseDTO(Course course)
        {
            Id = course.Id;
            CourseTitle = course.CourseTitle;
            StartDate = course.StartDate;
            Registrations = new List<CourseRegistrationDTO>();
            if (course.Registrations is null) return;
            foreach (Registration registration in course.Registrations)
            {
                Registrations.Add(new CourseRegistrationDTO(registration));
            }
        }
    }

    public class RegistrationCourseDTO
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string StartDate { get; set; }
        public RegistrationCourseDTO(Course course)
        {
            Id = course.Id;
            CourseTitle = course.CourseTitle;
            StartDate = course.StartDate;
        }

    }
}
