namespace exercise.wwwapi.Payloads
{
    public class CreateStudentPayload
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public float AverageGrade { get; set; }
    }
}
