using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            courses.MapPost("/", AddCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<List<DTOCourse>>() { Data = new List<DTOCourse>() };

            foreach (var course in results)
            {
                DTOCourse dtoCourse = new DTOCourse() { Id = course.Id, Title = course.Title, StartsAt = course.StartsAt, AverageGrade = course.AverageGrade };
                foreach (Student student in course.Students) 
                {
                    dtoCourse.Students.Add(new StudentForCourse() {Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth });
                }
                payload.Data.Add(dtoCourse);
            }
            return TypedResults.Ok(payload);
        }
        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            Course course = await repository.GetCourseById(id);

            if (course != null)
            {
                DTOCourse dtoCourse = new DTOCourse() { Id = course.Id, Title = course.Title, StartsAt = course.StartsAt, AverageGrade = course.AverageGrade };
                foreach (Student student in course.Students)
                {
                    dtoCourse.Students.Add(new StudentForCourse() { Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth });
                }
                return TypedResults.Ok(new Payload<DTOCourse>() { Data = dtoCourse });
            }
            return TypedResults.NotFound(new Payload<string>() { Data = "Course does not exist in database..." });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCourse(IRepository repository, CoursePostModel model)
        {
            try
            {
                DateTime startsAt = DateTime.ParseExact(model.StartsAt, "yyyy/mm/dd", CultureInfo.CurrentCulture);

                Course course = await repository.AddCourse(new Course { Title = model.Title, StartsAt = startsAt, AverageGrade = model.AverageGrade });
                DTOCourse dtoCourse = new DTOCourse() { Id = course.Id, Title = course.Title, StartsAt = course.StartsAt, AverageGrade = course.AverageGrade };
                
                return TypedResults.Created("", new Payload<DTOCourse>() { Data = dtoCourse});
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
    }
}
