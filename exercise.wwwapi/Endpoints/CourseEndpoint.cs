using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
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
            students.MapGet("/{id}", getCourseById);
            students.MapPost("/", CreateCourse);
            students.MapPost("/{id}", EditCourse);
            students.MapDelete("/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
                var results = await repository.GetCourses();
                var courseDTOs = results.Select(c => new GetCourseDTO()
                {
                    courseName = c.courseName,
                    id = c.Id,
                    students = c.student.Select(s => new GetStudentDTO()
                    {
                        courseId = s.courseId,
                        DateOfBirth = s.DateOfBirth,
                        firstName = s.firstName,
                        lastName = s.lastName,
                        Id = s.Id
                    }).ToList()
                });

            var response = new Payload<IEnumerable<GetCourseDTO>>("Success", courseDTOs);
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> getCourseById (IRepository repository, int id) { 
            var result = await repository.GetCourse(id);
            var courseDTO = new GetCourseDTO()
            {
                courseName = result.courseName,
                id = result.Id,
                students = result.student.Select(s => new GetStudentDTO()
                {
                    courseId = s.courseId,
                    DateOfBirth = s.DateOfBirth,
                    firstName = s.firstName,
                    lastName = s.lastName,
                    Id = s.Id
                }).ToList()
            };
            var response = new Payload<GetCourseDTO>("Success", courseDTO);
            return TypedResults.Ok(response);
        }   


        public static async Task<IResult> CreateCourse(IRepository repository, CreateCourseDTO dto)
        {
            var course = new Course()
            {
                courseName = dto.courseName,
                student = new List<Student>()
            };
            var result = await repository.AddCourse(course);
            var response = new Payload<GetCourseDTO>("Success", new GetCourseDTO()
            {
                courseName = result.courseName,
                id = result.Id,
                students = result.student.Select(s => new GetStudentDTO()
                {
                    courseId = s.courseId,
                    DateOfBirth = s.DateOfBirth,
                    firstName = s.firstName,
                    lastName = s.lastName,
                    Id = s.Id
                }).ToList()
            });
            return TypedResults.Ok(response);
        }

       public static async Task<IResult> EditCourse(IRepository repository, int id, CreateCourseDTO dto)
        {
            var course = new Course()
            {
                courseName = dto.courseName,
                student = new List<Student>()
            };
            var result = await repository.UpdateCourse(course);
            var response = new Payload<GetCourseDTO>("Success", new GetCourseDTO()
            {
                courseName = result.courseName,
                id = result.Id,
                students = result.student.Select(s => new GetStudentDTO()
                {
                    courseId = s.courseId,
                    DateOfBirth = s.DateOfBirth,
                    firstName = s.firstName,
                    lastName = s.lastName,
                    Id = s.Id
                }).ToList()
            });
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var result = await repository.DeleteCourse(id);
            var response = new Payload<GetCourseDTO>("Success", new GetCourseDTO()
            {
                courseName = result.courseName,
                id = result.Id,
                students = result.student.Select(s => new GetStudentDTO()
                {
                    courseId = s.courseId,
                    DateOfBirth = s.DateOfBirth,
                    firstName = s.firstName,
                    lastName = s.lastName,
                    Id = s.Id
                }).ToList()
            });
            return TypedResults.Ok(response);
        }
    }
}
