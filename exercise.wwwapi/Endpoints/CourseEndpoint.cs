using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public class CoursePayload
    {

        public string? CourseName { get; set; }
        public string? TutorName { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Capacity { get; set; }
        public string? Location { get; set; }

        public bool AllFieldsFilled()
        {
            if (String.IsNullOrEmpty(CourseName)) { return false; }
            if (String.IsNullOrEmpty(TutorName)) { return false; }
            if (String.IsNullOrEmpty(Location)) { return false; }
            if (!StartDate.HasValue) { return false; }
            if (!Capacity.HasValue) { return false; }


            return true;
        }

    }
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
            students.MapGet("/{id:int}", GetCourseById);
            students.MapPut("/{id:int}", UpdateCourseById);
            students.MapDelete("/{id:int}", RemoveCourseById);
            students.MapPost("/", CreateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(ICourseRepository repository)
        {
            List<Course> courses = await repository.GetCourses();

            return TypedResults.Ok(CourseClassDTO.FromListOfCourses(courses));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(int id, ICourseRepository repository)
        {
            Course? course = await repository.GetCourseById(id);
            if (course == null) { return TypedResults.NotFound(); }

            return TypedResults.Ok(new CourseClassDTO(course));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourseById(int id, CoursePayload payload, ICourseRepository repository)
        {
            if (!payload.AllFieldsFilled()) { return TypedResults.BadRequest("All fields must be filled."); }

            Course updateCourse = new Course()
            {
                CourseName = payload.CourseName,
                TutorName = payload.TutorName,
                Capacity = payload.Capacity.Value,
                StartDate = payload.StartDate.Value,
                Location = payload.Location
            };

            Course? course = await repository.UpdateCourseById(id, updateCourse);
            if (course == null) { return TypedResults.NotFound(); }
            course = await repository.GetCourseById(course.Id);
            return TypedResults.Created("", new CourseClassDTO(course));
        }
        public static async Task<IResult> CreateCourse(CoursePayload payload, ICourseRepository repository)
        {
            if (!payload.AllFieldsFilled()) { return TypedResults.BadRequest("All fields must be filled."); }

            Course updateCourse = new Course()
            {
                CourseName = payload.CourseName,
                TutorName = payload.TutorName,
                Capacity = payload.Capacity.Value,
                StartDate = payload.StartDate.Value,
                Location = payload.Location
            };

            Course? course = await repository.CreateCourse(updateCourse);
            if (course == null) { return TypedResults.NotFound(); }
            course = await repository.GetCourseById(course.Id);
            return TypedResults.Created("", new CourseClassDTO(course));
        }

        public static async Task<IResult> RemoveCourseById(int id, ICourseRepository repository)
        {
            Course? course = await repository.DeleteCourseById(id);
            if (course == null) { return TypedResults.NotFound(); }
            

            return TypedResults.Ok(new CourseClassDTO(course));
        }
    }
}
