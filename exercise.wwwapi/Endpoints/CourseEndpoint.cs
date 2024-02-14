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
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
            
        }

        public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
        {
            var result = await repository.GetById(id);
            var payload = new Payload<object> { data = new { Id = result.Id, Title = result.Title, AverageGrade = result.AverageGrade, StartDate = result.StartDate } };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var result = await repository.Delete(id);
            var payload = new Payload<object> { data = new { Id = result.Id, Title = result.Title } };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CoursePost course)
        {
            var nc = new Course
            {
                Id = id,
                Title = course.Title,
                AverageGrade = course.AverageGrade,
                StartDate = course.StartDate,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await repository.Update(nc);
            return TypedResults.Ok(new Payload<object> { data = new { Id = result.Id, Title = result.Title, AverageGrade = result.AverageGrade, StartDate = result.StartDate } });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            var courses = new List<object>();
            foreach (var result in results)
            {
                courses.Add(new { Id = result.Id, Title = result.Title, AverageGrade = result.AverageGrade, StartDate = result.StartDate });
            }
            var payload = new Payload<IEnumerable<object>>() { data = courses };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
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
            return TypedResults.Created("", new Payload<object> { data = new { Id = result.Id, Title = result.Title, AverageGrade = result.AverageGrade, StartDate = result.StartDate } });
        }
    }
}
