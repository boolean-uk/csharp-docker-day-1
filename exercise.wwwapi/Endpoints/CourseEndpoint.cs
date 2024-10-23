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
            students.MapGet("/course/{id}", GetCourse);
            students.MapPost("/createcourse", CreateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository repository, int id)
        {
            var result = await repository.GetCourse(id);
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCourse(IRepository repository, CourseDTO course)
        {
            var result = await repository.CreateCourse(course);
            return TypedResults.Ok(result);
        }
    }
}
