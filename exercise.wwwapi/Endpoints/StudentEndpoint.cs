using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", CreateStudent);

            var courses = app.MapGroup("courses");

        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();

            var DTOs = from student in results
                       select new StudentDTO() 
                       {
                           Id = student.Id,
                           FirstName = student.FirstName,
                           LastName = student.LastName,
                           DateOfBirth = student.DateOfBirth,
                           AverageGrade = student.AverageGrade,
                           CourseTitle = student.CourseTitle,
                       };
            var payload = new Payload<IEnumerable<StudentDTO>>() { data = DTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> CreateStudent(IRepository<Student> repository, PostStudent student)
        {
            Payload<StudentDTO> payload = new Payload<StudentDTO>();

            var entity = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
            };
            await repository.Create(entity);

            var result = new StudentDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
            };
            payload.data = result;

            return TypedResults.Created(payload.status, payload);
        }
    }


}
