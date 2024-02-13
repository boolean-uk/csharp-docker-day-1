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
            students.MapPost("/", PostCourse);
            students.MapDelete("/{id}", DeleteCourse);
            students.MapPut("/{id}", PutCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.Get();
            var DTOs = new List<CourseDTO>();
            foreach (var student in results)
            {
                DTOs.Add(CreateCourseDTO(student));
            }

            var payload = new Payload<IEnumerable<CourseDTO>>() { data = DTOs.OrderBy(c=>c.CourseId) };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostCourse(IRepository<Course> repository, InputCourse input)
        {
            var course = await repository.Get();
            var entity = new Course()
            {
                Id = (course.Count() == 0 ? 0 : course.Max(patient => patient.Id) + 1),
                CourseName = input.CourseName,
                StartDate = input.StartDate.ToUniversalTime(),
                AverageGrade = input.AverageGrade,
            };
            CourseDTO DTO = CreateCourseDTO(await repository.Insert(entity));
            var payload = new Payload<CourseDTO>() { data = DTO };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var student = await repository.GetById(id);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found.");
            }
            var result = await repository.Delete(id);
            var payload = new Payload<CourseDTO>() { data = CreateCourseDTO(result) };
            return result != null ? TypedResults.Ok(payload) : Results.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutCourse(IRepository<Course> repository, int id, InputCourse input)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound(id);
            }

            entity.CourseName = input.CourseName != null ? input.CourseName : entity.CourseName;
            entity.StartDate = input.StartDate != null ? input.StartDate.ToUniversalTime() : entity.StartDate;
            entity.AverageGrade = input.AverageGrade != null ? input.AverageGrade : entity.AverageGrade;
            var result = await repository.Update(entity);
            var payload = new Payload<CourseDTO>() { data = CreateCourseDTO(result) };
            return TypedResults.Created($"/{entity.Id}", entity);
        }
        static CourseDTO CreateCourseDTO(Course Course)
        {
            var students = new List<StudentsForCourseDTO>();
            foreach(var student in Course.Students)
            {
                students.Add(new StudentsForCourseDTO
                {
                    DateOfBirth = student.DateOfBirth,
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                });
            }
            return new CourseDTO

            {
                AverageGrade = Course.AverageGrade,
                StartDate = Course.StartDate,
                CourseId = Course.Id,
                CourseName = Course.CourseName,
                Students = students.OrderBy(s=>s.StudentId).ToList(),
            };
        }
    }
}
