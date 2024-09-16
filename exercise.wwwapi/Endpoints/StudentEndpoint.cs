using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var result = await repository.GetStudentById(id);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentPayload student)
        {
            var s = new Student()
                { FirstName = student.FirstName, LastName = student.LastName, BirthDate = student.BirthDate };
            var result = await repository.AddStudent(s);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentPayload student, int id)
        {
            var s = repository.GetStudentById(id).Result;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            s.BirthDate = student.BirthDate;
            var result = await repository.UpdateStudent(s);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var s = repository.GetStudentById(id).Result;
            var result = await repository.DeleteStudent(s);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }
    }
}
