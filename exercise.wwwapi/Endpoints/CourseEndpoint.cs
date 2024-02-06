using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IStudentRepository repository)
        {
            throw new NotImplementedException();
            /*
            var results = await repository.GetCourses();
            var payload = new StudentPayload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
            */
        }
    }
}
