namespace exercise.wwwapi.DataTransferObjects
{
    public class CreateStudentPayload
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string CourseTitle { get; set; }

        public DateTime CourseStartDate { get; set; }

        public float AverageGrade { get; set; }
    }
}
