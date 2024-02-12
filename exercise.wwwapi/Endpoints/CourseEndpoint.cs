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
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, CoursePost course)
        {
            var c = new Course
            {
                StartDate = course.StartDate,
                Title = course.Title,
                AverageGrade = course.AverageGrade,
                CreatedAt = DateTime.UtcNow
            };
            var result = await repository.Insert(c);

            return TypedResults.Created("", new Payload<Course> { data = result });
        }
    }
}
