using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    /// 
    public record CoursePostPayload(string title, DateTime startDate);
    public record CourseUpdatePayload(string? title, DateTime? startDate);
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
            students.MapPost("/", AddCourse);
            students.MapPut("/{id}", ChangeCourse);
            students.MapDelete("/{id}", RemoveCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            //var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(CourseResponseDTO.FromRepository(results));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCourse(IRepository repository, CoursePostPayload payload)
        {
            //Handling missing inputs
            if (payload.title == null || payload.title == "")
                return Results.BadRequest("Title not valid.");

            Course? course = await repository.AddCourse(payload.title, payload.startDate);
            if (course == null)
                return Results.BadRequest("Course already exists");

            CourseResponseDTO cou = CourseResponseDTO.FromARepository(course);
            return TypedResults.Created($"/courses{cou.Title} {cou.StartDate} ", cou);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> ChangeCourse(IRepository repository, CourseUpdatePayload posted, int id)
        {
            Course? course = await repository.GetCourse(id);
            if (course == null)
                return Results.NotFound("ID out of scope");

            course = await repository.ChangeCourse(course, posted.title, posted.startDate);
            if (course == null)
                return Results.BadRequest("Course already changed");

            CourseResponseDTO cou = CourseResponseDTO.FromARepository(course);
            return TypedResults.Created($"/courses{cou.Title} {cou.StartDate} ", cou);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> RemoveCourse(IRepository repository, int id)
        {
            Course? course = await repository.GetCourse(id);
            if (course == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(CourseResponseDTO.FromRepository(await repository.RemoveCourse(course)));
        }
    }
}