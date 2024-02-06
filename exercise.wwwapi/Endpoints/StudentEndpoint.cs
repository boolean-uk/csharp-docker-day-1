using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint GET/PUT/POST/DELETE
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{student.Id}", GetStudent);
            students.MapPut("/{student.Id}", UpdateStudent);
            students.MapPost("/{student.Id}", CreateStudent);
            students.MapDelete("/{student.Id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> GetStudent(IRepository repository, int id)
        {
            var student = await repository.GetStudent(id);
            if(student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            return TypedResults.Ok(student);
        }
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentUpdatePayload data, int id)
        {
            //Get student with id and check if exists
            var student = await repository.GetStudent(id);
            if (student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            //Check payload data is valid
            if(data.FirstName == null || data.LastName==null || data.Dob == null || data.CourseTitle == null || data.StartDate == null || data.AvgGrade == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Update student in repository via UpdateStudent()
            student = await repository.UpdateStudent(id, data.FirstName, data.LastName, data.Dob, data.CourseTitle, data.StartDate, data.AvgGrade);
            //Return TypedResults.created
            return TypedResults.Created($"/{student.Id}", student);
        }
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPostPayload data)
        {
            //Check payload data is valid
            if(data.FirstName == null || data.LastName == null || data.Dob == null || data.CourseTitle == null || data.StartDate == null || data.AvgGrade == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Create new student in repo via CreateStudent()
            var student = await repository.CreateStudent(data.FirstName, data.LastName, data.Dob, data.CourseTitle, data.StartDate, data.AvgGrade);
            return TypedResults.Created($"/{student.Id}", student);
        }
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            //Get student with id and check if exists
            var student = await repository.GetStudent(id);
            if (student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            //Run DeleteStudent()
            student = await repository.DeleteStudent(id);
            //Return TypedResults.Ok
            return TypedResults.Ok(student);
        }
    }
}
