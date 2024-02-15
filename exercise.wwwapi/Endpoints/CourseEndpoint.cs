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
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
            courses.MapPut("/", AddCourseToStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            var response = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository<Course> repository, int id)
        {
            var results = await repository.Get(id); 
            var response = new Payload<Course>() { Data = results };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, CourseDTO courseDTO)
        {
            var course = new Course
            {
                Title = courseDTO.Title,
                StartDate = courseDTO.StartDate,
                AvgGrade = courseDTO.AvgGrade
            };

            var result = await repository.Add(course);
            var response = new Payload<Course>() { Data = result };
            return TypedResults.Created("", response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CourseDTO courseDTO)
        {
            var course = await repository.Get(id);

            course.Title = courseDTO.Title != null ? courseDTO.Title : course.Title;
            course.StartDate = courseDTO.StartDate != null ? courseDTO.StartDate : course.StartDate;
            course.AvgGrade = courseDTO.AvgGrade != null ? courseDTO.AvgGrade : course.AvgGrade;

            await repository.Update(course);
            var response = new Payload<Course>() { Data = course };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var course = await repository.Get(id);
            await repository.Delete(id);
            var response = new Payload<Course>() { Data = course };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCourseToStudent(IRepository<Course> courseRepo, IRepository<Student> studentRepo, int courseId, int studentId)
        {
            var student = await studentRepo.Get(studentId); 
            var course = await courseRepo.Get(courseId);

            student.Courses ??= new List<Course>();
            student.Courses.Add(course);

            await studentRepo.Update(student);

            var response = new Payload<Student>() { Data = student };
            return TypedResults.Ok(response);
        }
    }
}
