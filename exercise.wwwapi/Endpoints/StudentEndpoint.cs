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
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAllStudentsWithCourses();
            var response = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository<Student> repository, int id)
        {
            var student = await repository.GetSpecificStudentWithCourses(id);
            var response = new Payload<Student>() { Data = student };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, StudentDTO studentDTO)
        {
            var student = new Student
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                DoB = studentDTO.DoB
            }; 

            var result = await repository.Add(student);
            var response = new Payload<Student>() { Data = result };
            return TypedResults.Created("", response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentDTO studentDTO)
        {
            var student = await repository.Get(id);

            student.FirstName = studentDTO.FirstName != null ? studentDTO.FirstName : student.FirstName;
            student.LastName = studentDTO.LastName != null ? studentDTO.LastName : student.LastName;
            student.DoB = studentDTO.DoB != null ? studentDTO.DoB : student.DoB;

            await repository.Update(student);
            var response = new Payload<Student>() { Data = student };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id) 
        {
            var student = await repository.Get(id);
            await repository.Delete(id);
            var response = new Payload<Student>() { Data = student };
            return TypedResults.Ok(response);
        }

    }
}
