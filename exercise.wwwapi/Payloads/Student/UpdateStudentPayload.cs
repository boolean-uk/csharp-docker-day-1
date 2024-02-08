namespace exercise.wwwapi.Payloads
{
    public class UpdateStudentPayload
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public float AverageGrade { get; set; } = float.NaN;
    }
}
