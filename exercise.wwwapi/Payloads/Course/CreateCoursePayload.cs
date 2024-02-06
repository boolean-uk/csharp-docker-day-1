namespace exercise.wwwapi.Payloads.Course
{
    public class CreateCoursePayload
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required int AvailableSpots { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }
    }
}
