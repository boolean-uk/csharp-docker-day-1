using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Courses;
using exercise.wwwapi.DataTransferObjects.InputDTOs;
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
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/", PostCourse);
            courses.MapPut("/{id}", PutCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetCourses(IRepository<Course> repo)
        {
            IEnumerable<Course> courses = await repo.GetAll();

            IEnumerable<CourseDTO> coursesOut = courses.Select(c => new CourseDTO(c));
            Payload<IEnumerable<CourseDTO>> payload = new Payload<IEnumerable<CourseDTO>>() { data = coursesOut };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetCourse(IRepository<Course> repo, int id)
        {
            Course? course = await repo.Get(id);

            if (course == null)
            {
                return TypedResults.NotFound($"No course with ID {id} found.");
            }

            CourseDTO courseOut = new CourseDTO(course);
            Payload<CourseDTO> payload = new Payload<CourseDTO>() { data = courseOut };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> PostCourse(IRepository<Course> repo, CourseInputPostDTO coursePost)
        {
            DateTime startDate;
            try
            {
                //startDate = DateTime.Parse(coursePost.CourseStartDate);
                startDate = coursePost.CourseStartDate;
            }
            catch (FormatException fe)
            {
                return TypedResults.BadRequest($"Could not interpret the provided startDate, {coursePost.CourseStartDate}.");
            }

            Course course = new Course()
            {
                CourseTitle = coursePost.CourseTitle,
                CourseStartDate = startDate,
            };

            Course createdCourse = await repo.Insert(course);

            CourseDTO courseOut = new CourseDTO(createdCourse);
            Payload<CourseDTO> payload = new Payload<CourseDTO>() { data = courseOut };
            return TypedResults.Created($"/{createdCourse.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> PutCourse(IRepository<Course> repo, int id, CourseInputPutDTO coursePut)
        {
            Course? dbCourse = await repo.Get(id);

            if (dbCourse == null)
            {
                return TypedResults.NotFound($"No course with ID {id} found.");
            }

            DateTime startDate;
            if (coursePut.CourseStartDate != null)
            {
                try
                {
                    // startDate = DateTime.Parse(coursePut.CourseStartDate);
                    startDate = (DateTime)coursePut.CourseStartDate;
                }
                catch (FormatException fe)
                {
                    return TypedResults.BadRequest($"Could not interpret the provided startDate, {coursePut.CourseStartDate}.");
                }
            }
            else 
            {
                startDate = dbCourse.CourseStartDate;
            }

            Course course = new Course() 
            {
                Id = id,
                CourseTitle = coursePut.CourseTitle ?? dbCourse.CourseTitle,
                CourseStartDate = startDate,
            };

            Course updatedCourse = await repo.Update(id, course);

            CourseDTO courseOut = new CourseDTO(updatedCourse);
            Payload<CourseDTO> payload = new Payload<CourseDTO>() { data = courseOut };
            return TypedResults.Created($"/{updatedCourse.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteCourse(IRepository<Course> repo, int id) 
        {
            Course? dbCourse = await repo.Get(id);

            if (dbCourse == null)
            {
                return TypedResults.NotFound($"No course with ID {id} found.");
            }

            Course courseDeleted = await repo.Delete(id);
            CourseDTO courseOut = new CourseDTO(courseDeleted);
            Payload<CourseDTO> payload = new Payload<CourseDTO>() { data = courseOut };
            return TypedResults.Created($"/{courseDeleted.Id}", payload);
        }
    }
}
