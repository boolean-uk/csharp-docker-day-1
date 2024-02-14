using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
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
            students.MapPost("/", CreateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses([FromServices]IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, Course course)
        {
            var newCourse = await repository.CreateCourse(course);
            if (newCourse == null)
            {
                return TypedResults.BadRequest("Failed to create a course");
            }

            var payload = new Payload<Course>() { data = newCourse };
            return TypedResults.Created($"/appointment {newCourse.Id}", payload);

        }

    }
}
