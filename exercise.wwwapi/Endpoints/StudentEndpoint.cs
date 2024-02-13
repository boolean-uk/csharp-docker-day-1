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
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
        {
            Student student = await repository.Get(id);
            if (student == null) return TypedResults.NotFound("student not found");
            Payload<Student> payload = new Payload<Student> { data = student };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, Student student)
        {
            if (student == null) return TypedResults.BadRequest("Student missing values");
            student = await repository.Create(student);
            Payload<Student> payload = new Payload<Student> { data = student };

            return TypedResults.Created($"students/{student.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, Student studentDto, int id)
        {
            Student student = await repository.Get(id);
            if (student == null) return TypedResults.NotFound("Student not found");
            
            student.CourseStartDate = studentDto.CourseStartDate;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.AverageGrade = studentDto.AverageGrade;
            student.CourseTitle = studentDto.CourseTitle;

            student = await repository.Update(student);

            Payload<Student> payload = new Payload<Student> { data = student };

            return TypedResults.Created($"students/{student.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            Student student = await repository.Get(id);
            if (student == null) return TypedResults.NotFound("Student not found");

            student = await repository.Delete(student);
            Payload<Student> payload = new Payload<Student> { data = student };

            return TypedResults.Ok(payload);
        }

    }
  

}
