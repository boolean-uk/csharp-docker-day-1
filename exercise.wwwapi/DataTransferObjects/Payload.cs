using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }


    public record StudentPayload
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("courseTitle")]
        public string CourseTitle { get; set; }

        [JsonPropertyName("avgGrade")]
        public int AvgGrade { get; set; }

        public StudentPayload(string firstName, string lastName, string courseTitle, int avgGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            CourseTitle = courseTitle;
            AvgGrade = avgGrade;
        }
    }

}
