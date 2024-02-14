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
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
            students.MapPost("/addstudent", AddStudentToCourse);
            students.MapGet("/{id}/students", GetStudentsByCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            /*
            var results = await repository.GetCourses();
            var payload = (CourseDTO.FromCourses(results));
            return TypedResults.Ok(payload);
            */
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
            return TypedResults.Ok(CourseDTO.FromCourses(results));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourse(int id, IRepository repository)
        {
            var result = await repository.GetCourse(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new CourseDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(CreateCoursePayload payload, IRepository repository)
        {
            var result = await repository.CreateCourse(payload);
            return TypedResults.Ok(new CourseDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(int id, UpdateCoursePayload payload, IRepository repository)
        {
            var result = await repository.UpdateCourse(id, payload);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new CourseDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(int id, IRepository repository)
        {
            var result = await repository.GetCourse(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            await repository.DeleteCourse(id);
            return TypedResults.NoContent();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddStudentToCourse(CreateOrUpdateStudentCoursePayload payload, IRepository repository)
        {
            var result = await repository.AddStudentToCourse(payload);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentsByCourse(int id, IRepository repository)
        {
            var results = await repository.GetStudentsByCourse(id);
            return TypedResults.Ok(StudentDTO.FromStudents(results));
        }


    }
}
