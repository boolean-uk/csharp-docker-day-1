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
            students.MapPost("/", AddCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            var payload = new Payload<IEnumerable<CourseResponse>>() { Data = Course.ToResponseDTO(results) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
        {
            var results = await repository.Get(id);
            if (results == null)
            {
                return TypedResults.NotFound($"Course with id {id} was not found");
            }
            var payload = new Payload<CourseResponse>() { Data = Course.ToResponseDTO(results) };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddCourse(IRepository<Course> repository, CoursePost course)
        {
            if (course == null)
            {
                return TypedResults.BadRequest("Invalid input: missing student");
            }
            if (string.IsNullOrEmpty(course.Name))
            {
                return TypedResults.BadRequest("Invalid input: please enter a course name");
            }

            Course newCourse = new Course
            {
                CourseName = course.Name,
            };

            var addedCourse = await repository.Add(newCourse);

            var payload = new Payload<CourseResponse> { Data = Course.ToResponseDTO(addedCourse) };

            return TypedResults.Created($"/{addedCourse.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CoursePost course)
        {
            if (course == null)
            {
                return TypedResults.BadRequest("Invalid input: missing course");
            }

            Course? oldCourse = await repository.Get(id);

            if (oldCourse == null)
            {
                return TypedResults.BadRequest($"Course with id {id} could not be found");
            }

            if (!string.IsNullOrEmpty(course.Name)) { oldCourse.CourseName = course.Name; }

            var updatedCourse = await repository.Update(oldCourse);
            var payload = new Payload<CourseResponse> { Data = Course.ToResponseDTO(updatedCourse) };

            return TypedResults.Created($"/{id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var deletedCourse = await repository.Delete(id);
            if (deletedCourse == null)
            {
                return TypedResults.NotFound($"Course with id {id} was not found");
            }

            var payload = new Payload<CourseResponse> { Data = Course.ToResponseDTO(deletedCourse) };

            return TypedResults.Ok(payload);
        }
    }
}
