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
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/", AddCourse);
            courses.MapDelete("/{id}", DeleteCourse);
            courses.MapPut("/{id}", UpdateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetCourseById(IRepository<Course> repository, IRepository<Student> studentrepo, int id)
        {
            var results = await repository.GetById(id);
            var getstudents = await studentrepo.GetAll();

            if (results != null)
            {
                return TypedResults.Ok(results);
            }
            return TypedResults.BadRequest("Course not found");

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCourse(IRepository<Course> courserepo,  string courseTitle)
        {
            var checkCourse = await courserepo.GetAll();

            if (checkCourse.Any(x => x.CourseTitle == courseTitle))
            {
                return TypedResults.BadRequest("Course already exist");

            }

            Course course = new Course()
            {
                CourseTitle = courseTitle,
                CourseStart = DateTime.UtcNow
                
            };

            var results = await courserepo.Create(course);
            if (results != null)
            {

                return TypedResults.Ok(results);
            }
            return TypedResults.BadRequest("Failed to add course");

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var checkCourse = await repository.GetById(id);
            if (checkCourse == null)
            {
                return TypedResults.NotFound("Course does not exist");
            }

            var deletecourse = await repository.Delete(id);
            if (deletecourse != null)
            {
                return TypedResults.Ok(deletecourse);
            }
            return TypedResults.BadRequest("Could not find and delete course");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, string courseTitle)
        {
            try
            {
                var entity = await repository.GetById(id);

                if (entity != null)
                {
                    if(courseTitle == "string") courseTitle = string.Empty;
                    
                    entity.CourseTitle = !string.IsNullOrEmpty(courseTitle) ? courseTitle : entity.CourseTitle;
                    var result = await repository.Update(entity);

                    return TypedResults.Ok(result);
                }
                else return Results.NotFound("Course does not exist");
            }
            catch (Exception ex) { return TypedResults.Problem(ex.Message); }
        }
    }
}
