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
            students.MapGet("/{id}", GetCourseById);
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var courses = await repository.GetCourses();
            List<CourseDTO> results = new List<CourseDTO>();
            foreach (var course in courses)
            {
                results.Add(new CourseDTO(course));
            }
            var payload = new Payload<IEnumerable<CourseDTO>>() { data = results }; 
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            Course? result = await repository.GetCourseByID(id);
            if (result is null) return TypedResults.NotFound();
            return TypedResults.Ok(new Payload<CourseDTO>() { data = new CourseDTO(result) });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCourse(IRepository repository, CoursePayload payload)
        {
            Course course = await repository.CreateCourse(payload.courseTitle, payload.startDate);
            return TypedResults.Ok(new Payload<CourseDTO>() { data = new CourseDTO(course) });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CoursePayload payload)
        {
            Course? result = await repository.GetCourseByID(id);
            if (result is null) return TypedResults.NotFound();
            Course course = await repository.UpdateCourse(result, payload.courseTitle, payload.startDate);
            return TypedResults.Ok(new Payload<CourseDTO>() { data = new CourseDTO(course) });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            Course? result = await repository.GetCourseByID(id);
            if (result is null) return TypedResults.NotFound();
            repository.DeleteCourse(result);
            return TypedResults.Ok(new Payload<CourseDTO>() { data = new CourseDTO(result) });
        }
    }
}
