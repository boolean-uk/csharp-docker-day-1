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
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{Id}", UpdateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, Course course)
        {
            Course createdCourse = await repository.AddCourse(course);
            Payload<Course> payload = new Payload<Course> { Data = createdCourse };
            return TypedResults.Created("", payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, Course course)
        {
            Course updatedCourse = await repository.UpdateCourse(id, course);
            Payload<Course> payload = new Payload<Course>() { Data = updatedCourse };
            return TypedResults.Created("", payload);
        }
    }
}
