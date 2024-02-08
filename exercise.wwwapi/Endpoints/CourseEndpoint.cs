using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static exercise.wwwapi.DataModels.Payloads.CoursePayloads;

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
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        private static async Task<IResult> DeleteCourse(int id, IRepository repository)
        {
            var result = await repository.deleteCourse(id);
            if (result == null)
            {
                return TypedResults.NotFound($"Cours with id: {id} could not be found");
            }
            return TypedResults.Ok(new CourseDataDTO(result, "success"));
        }

        private static async Task<IResult> UpdateCourse(int id, CoursePutPayload payload, IRepository repository)
        {
            if (payload.title == "")
            {
                return TypedResults.BadRequest("Updated title can not be of type empty");
            }
            

            var result = await repository.updateCourse(id, payload.title, payload.start);
            if (result == null)
            {
                return TypedResults.NotFound($"User with id: {id} could not be found");
            }
            return TypedResults.Created($"/customers/{id}", new CourseDataDTO(result, "success"));
        }

        private static async Task<IResult> CreateCourse(CoursePostPayload payload, IRepository repository)
        {
            if (payload.title == null || payload.title == "")
            {
                return TypedResults.BadRequest($"Title must be a non-empty value! You entered: {payload.title}");
            }
            if (payload.start == null)
            {
                return TypedResults.BadRequest($"Course start must be a non-empty value! You entered: {payload.start}");
            }
           
            var result = await repository.createCourse(payload.title, payload.start);

            if (result == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Created("/students", new CourseDataDTO(result, "success"));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.getCourses();
            if (results == null)
            {
                return TypedResults.NotFound("No courses is in the db");
            }
            var payload = new List<CourseDTO>();
            foreach (var course in results)
            {
                payload.Add(new CourseDTO(course));
            }
            var dataDTO = new CourseListDataDTO(payload, "success");
            //var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        
    }
}
