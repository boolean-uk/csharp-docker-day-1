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
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();

            var DTOs = from course in results
                       select new CourseDTO()
                       {
                           Id = course.Id,
                           CourseCode = course.CourseCode,
                       };
            var payload = new Payload<IEnumerable<CourseDTO>>() { data = DTOs };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> CreateCourse(IRepository<Course> repository, PostCourse model)
        {
            Payload<CourseDTO> payload = new Payload<CourseDTO>();

            var entity = new Course()
            {
                CourseCode = model.CourseCode
            };
            await repository.Create(entity);

            var result = new CourseDTO()
            {
                CourseCode = model.CourseCode
            };
            payload.data = result;

            return TypedResults.Created(payload.status, payload);
        }
    }
}
