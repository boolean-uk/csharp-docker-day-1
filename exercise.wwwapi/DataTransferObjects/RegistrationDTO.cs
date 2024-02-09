using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentRegistrationDTO
    {
        public int Id { get; set; }
        public RegistrationCourseDTO Course { get; set; }
        public float AverageGrade { get; set; }
        public StudentRegistrationDTO(Registration registration)
        {
            Id = registration.Id;
            Course = new RegistrationCourseDTO(registration.Course);
            AverageGrade = registration.AverageGrade;
        }
    }

    public class CourseRegistrationDTO
    {
        public int Id { get; set; }
        public RegistrationStudentDTO Student { get; set; }
        public float AverageGrade { get; set; }
        public CourseRegistrationDTO(Registration registration)
        {
            Id = registration.Id;
            Student = new RegistrationStudentDTO(registration.Student);
            AverageGrade = registration.AverageGrade;
        }
    }
}
