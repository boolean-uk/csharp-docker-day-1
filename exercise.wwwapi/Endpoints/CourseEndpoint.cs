using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
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
            students.MapPost("/", Create);
            students.MapPut("/", Update);
            students.MapDelete("/", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Create(IRepository<Course> repository, CoursePost courseData) 
        {
            Course course = new Course()
            {
                Description = courseData.Description
            };
            Course result = await repository.Add(course);
            Payload<Course> payload = new Payload<Course>(result);
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Update(IRepository<Course> repository, int id, CoursePost courseData) 
        {
            Course course = await repository.GetById(id);
            course.Description = courseData.Description == string.Empty ? course.Description : courseData.Description;
            Course result = await repository.Update(course);
            Payload<Course> payload = new Payload<Course>(result);
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Delete(IRepository<Course> repositoryCourse, IRepository<Student> repositoryStudent, int id) 
        {
            var students = await repositoryStudent.Get();
            if (students.Any(x => x.CourseId == id)) { return TypedResults.BadRequest($"cannot delete course with id {id} because it violates foreign key constraint"); }
            var course = await repositoryCourse.GetById(id);
            var result = await repositoryCourse.Delete(course);
            Payload<Course> payload = new Payload<Course>(result);
            return TypedResults.Ok(payload);
        }
    }
}
