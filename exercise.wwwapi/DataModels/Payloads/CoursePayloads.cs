namespace exercise.wwwapi.DataModels.Payloads
{
    public class CoursePayloads
    {

        public record CoursePostPayload(string title, DateTimeOffset start);
        public record CoursePutPayload(string? title, DateTimeOffset? start);

    }
}
