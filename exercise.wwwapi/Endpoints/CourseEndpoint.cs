using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.CourseDTOs;
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
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<GetCourseDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(int id, IRepository repository)
        {
            var results = await repository.GetCourseById(id);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Course with id {id} not found." });
            var payload = new Payload<GetCourseDTO>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(CreateCourseDTO cDTO, IRepository repository)
        {
            var results = await repository.CreateCourse(cDTO);
            var payload = new Payload<GetCourseDTO>() { data = results };
            return TypedResults.Created(" ", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(int id, UpdateCourseDTO uDTO, IRepository repository)
        {
            var results = await repository.UpdateCourse(id, uDTO);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Course with id {id} not found." });
            var payload = new Payload<GetCourseDTO>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(int id, IRepository repository)
        {
            var results = await repository.DeleteCourse(id);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Course with id {id} not found." });
            var payload = new Payload<GetCourseDTO>() { data = results };
            return TypedResults.Ok(payload);
        }
    }
}
