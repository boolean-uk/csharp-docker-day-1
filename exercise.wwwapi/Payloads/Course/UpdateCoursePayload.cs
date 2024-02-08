namespace exercise.wwwapi.Payloads.Course
{
    public class UpdateCoursePayload
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? AvailableSpots { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
