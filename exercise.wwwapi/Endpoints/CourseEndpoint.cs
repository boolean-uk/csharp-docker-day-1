using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/", AddCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            var result = await repository.GetCourseById(id);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCourse(IRepository repository, CoursePayload course)
        {
            var c = new Course()
                { Title = course.Title, StartDate = course.StartDate, AverageGrade = course.AverageGrade };
            var result = await repository.AddCourse(c);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, CoursePayload course, int id)
        {
            var c = repository.GetCourseById(id).Result;
            c.Title = course.Title;
            c.StartDate = course.StartDate;
            c.AverageGrade = course.AverageGrade;
            var result = await repository.UpdateCourse(c);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var c = repository.GetCourseById(id).Result;
            var result = await repository.DeleteCourse(c);
            var payload = new Payload<Course>() { Data = result };
            return TypedResults.Ok(payload);
        }
    }
}
