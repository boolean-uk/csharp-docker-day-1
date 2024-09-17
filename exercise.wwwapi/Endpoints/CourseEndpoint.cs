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
            students.MapGet("/{id}", GetCourse);
            students.MapPost("/", CreateCourse);
            students.MapPut("/", UpdateCourse);
            students.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            try
            {
                var results = await repository.GetObjects();
                var payload = new Payload<IEnumerable<Course>>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteCourse(IRepository<Course> repository, IFilter<Course> filter, int id)
        {
            try
            {
                var results = await repository.DeleteObject(filter, id);
                var payload = new Payload<Course>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateCourse(IRepository<Course> repository, IFilter<Course> filter, int id, string courseTitle, string averageGrade, DateTime startDate)
        {
            try
            {
                var results = await repository.UpdateObject(filter, id, courseTitle, averageGrade, startDate);
                var payload = new Payload<Course>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateCourse(IRepository<Course> repository, IFilter<Course> filter, string courseTitle, string averageGrade, DateTime startDate)
        {
            try
            {
                var results = await repository.CreateObject(filter, new Course() { CourseTitle = courseTitle, AverageGrade = averageGrade, CourseStartDate = startDate});
                var payload = new Payload<Course>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> GetCourse(IRepository<Course> repository, IFilter<Course> filter, int id)
        {
            try
            {
                var results = repository.GetObject(filter, id);
                var payload = new Payload<Course>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
    }
}
