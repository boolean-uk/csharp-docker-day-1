using exercise.wwwapi.DataTransferObjects.CourseDTOs;
using exercise.wwwapi.Payloads.Course;
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
            courses.MapPut("/", AddCourse);
            courses.MapPost("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteACourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(ICourseRepository repository)
        {
            var returnCourses = new List<CourseDTO>();
            var courses = await repository.GetCourses();
            foreach (var course in courses)
            {
                returnCourses.Add(new CourseDTO(course));
            }

            return TypedResults.Ok(returnCourses);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCourse(ICourseRepository repository, CreateCoursePayload payload)
        {
            //Check DateTimes
            if (string.IsNullOrWhiteSpace(payload.Title) || string.IsNullOrWhiteSpace(payload.Description))
            {
                return TypedResults.BadRequest("Incomplete course data.");
            }

            var course = await repository.AddCourse(payload.Title, payload.Description, payload.AvailableSpots, payload.StartDate, payload.EndDate);
            return TypedResults.Created($"courses/{course.Id}", new CourseDTO(course));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(ICourseRepository repository, int id, UpdateCoursePayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.Title) && string.IsNullOrWhiteSpace(payload.Description) && payload.AvailableSpots == null && payload.StartDate == null && payload.EndDate == null)
            {
                return TypedResults.BadRequest("Empty data");
            }

            var course = await repository.UpdateCourse(id, payload.Title, payload.Description, payload.AvailableSpots, payload.StartDate, payload.EndDate);
            return course == null ? TypedResults.NotFound("Student not found") : TypedResults.Ok(new CourseDTO(course));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteACourse(ICourseRepository repository, int id)
        {
            var course = await repository.DeleteCourse(id);
            return course == null ? TypedResults.NotFound("Course not found") : TypedResults.Ok(new CourseDTO(course));
        }
    }
}
