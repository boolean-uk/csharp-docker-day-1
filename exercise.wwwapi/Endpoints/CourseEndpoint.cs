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
            courses.MapGet("/{course.Id}", GetCourse);
            courses.MapPut("/{courses.Id}", UpdateCourse);
            courses.MapPost("/{courses.Id}", CreateCourse);
            courses.MapDelete("/{courses.Id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = GetCourseDTO.FromRepository(await repository.GetCourses());
            var payload = new Payload<IEnumerable<GetCourseDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> GetCourse(IRepository repository, int id)
        {
            var course = new GetCourseDTO(await repository.GetCourse(id));
            if (course == null)
            {
                return TypedResults.NotFound($"No course with id {id} found.");
            }
            var payload = new Payload<GetCourseDTO>() { data = course };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CourseUpdatePayload data)
        {
            //Get course with id and check if exists
            var course = new CourseDTO(await repository.GetCourse(id));
            if (course == null)
            {
                return TypedResults.NotFound($"No course with id {id} found.");
            }
            //Check payload data is valid   string Title, string Description, string StartDate
            if (data.Title == null || data.Description == null || data.StartDate == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Update course in repository via UpdateCourse()
            course = new CourseDTO(await repository.UpdateCourse(id, data.Title, data.Description, data.StartDate));
            var payload = new Payload<CourseDTO>() { data = course };
            //Return TypedResults.created
            return TypedResults.Created($"/{course.Id}", payload);
        }
        public static async Task<IResult> CreateCourse(IRepository repository, CoursePostPayload data)
        {
            //Check payload data is valid
            if (data.Title == null || data.Description == null || data.StartDate == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Create new course in repo via CreateCourse()
            var course = new CourseDTO(await repository.CreateCourse(data.Title, data.Description, data.StartDate));
            var payload = new Payload<CourseDTO>() { data = course };
            return TypedResults.Created($"/{course.Id}", payload);
        }
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            //Get course with id and check if exists
            var course = new GetCourseDTO(await repository.GetCourse(id));
            if (course == null)
            {
                return TypedResults.NotFound($"No course with id {id} found.");
            }
            //Run DeleteCourse()
            course = new GetCourseDTO(await repository.DeleteCourse(id));
            var payload = new Payload<GetCourseDTO>() { data = course };
            //Return TypedResults.Ok
            return TypedResults.Ok(payload);
        }
    }
}
