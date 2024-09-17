using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Payloads;
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
            courses.MapGet("/GetCourseById/{id}", GetCourse);
            courses.MapPost("/CreateCourse", CreateCourse);
            courses.MapPut("/UpdateCourse/{id}", UpdateCourseById);
            courses.MapDelete("DeleteCourse/{id}", DeleteCourseById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourseById(IRepository repository, int courseId)
        {
            try
            {
                var results = await repository.DeleteCourse(courseId);
                var payload = new Payload<CourseDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourseById(IRepository repository, int courseId, CoursePayload payloadCourse)
        {
            try
            {
                var results = await repository.UpdateCourse(courseId, payloadCourse);
                var payload = new Payload<CourseDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, CoursePayload payloadCourse)
        {
            try
            {
                var results = await repository.CreateCourse( payloadCourse);
                var payload = new Payload<CourseDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository repository, int courseId)
        {
            try
            {
                var results = await repository.GetCourse(courseId);
                var payload = new Payload<CourseDTO>() { Data = results };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<CourseDTO>>() { Data = results };
            return TypedResults.Ok(payload);
        }
    }
}
