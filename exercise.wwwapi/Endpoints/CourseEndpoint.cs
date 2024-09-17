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
            courses.MapPost("/Create", CreateCourse);
            courses.MapPut("/Update{id}", UpdateCourse);
            courses.MapDelete("/Delete{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<CoursePayload>>(results);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, InputCourseDTO data)
        {
            var result = await repository.AddCourse(data);
            var payload = new Payload<CoursePayload>(result);
            return TypedResults.Created($"http://localhost:5137/courses/{payload.Data.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository repository, InputCourseDTO data, int courseId)
        {
            var result = await repository.UpdateCourse(courseId, data);
            var payload = new Payload<CoursePayload>(result);
            return TypedResults.Created($"http://localhost:5137/courses/{payload.Data.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int courseId)
        {
            var result = await repository.RemoveCourse(courseId);
            var payload = new Payload<CoursePayload>(result);
            return TypedResults.Ok(payload);
        }
    }
}
