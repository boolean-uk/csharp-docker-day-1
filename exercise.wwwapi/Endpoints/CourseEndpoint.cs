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
            courses.MapPut("/{id}/", UpdateCourse);
            courses.MapDelete("/{id}/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var courses = await repository.GetCourses();
            var courseDto = new List<CourseResponseDTO>();
            foreach (Course course in courses)
            {
                courseDto.Add(new CourseResponseDTO(course));
            }
            return TypedResults.Ok(courseDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(CreateCoursePayload payload, IRepository repository)
        {
            if (payload.CourseTitle == "" || payload.startdate == null)
            {
                return Results.BadRequest("A non-empty Title and/or start date is required");
            }

            Course? course = await repository.CreateCourse(payload.CourseTitle, payload.startdate);
            if (course == null)
            {
                return Results.BadRequest("Failed to create course.");
            }

            return TypedResults.Ok(new CourseResponseDTO(course));
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCourse(int courseId, UpdateCoursePayload payload, IRepository Repository)
        {
            Course? course = await Repository.GetACourse(courseId);
            if (course == null)
            {
                return TypedResults.NotFound("Course not found");
            }
            Course? courseUpdated = await Repository.UpdateCourse(courseId, payload.newTitle, payload.newStartDate);
            if (courseUpdated == null)
            {
                return Results.BadRequest("Failed to update course.");
            }

            return TypedResults.Created($"/courses/{courseUpdated.Id}", new CourseResponseDTO(courseUpdated));
        }

        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteCourse(int courseId, IRepository repository)
        {
            Course? course = await repository.GetACourse(courseId);
            if (course == null)
            {
                return TypedResults.NotFound("Course not found");
            }
            Course? courseDelete = await repository.DeleteCourse(courseId);
            if (courseDelete == null)
            {
                return Results.BadRequest("Failed to delete course.");
            }

            return TypedResults.Ok(new CourseResponseDTO(course));
        }
    }
}
