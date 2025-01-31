using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
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
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            return TypedResults.Ok(new Payload<IEnumerable<Student>> { Data = results });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var result = await repository.GetStudentById(id);
            if (result != null)
            {
                return TypedResults.Ok(new Payload<Student> { Data = result });
            }
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentDTO studentDTO)
        {
            var student = new Student
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                StudentNumber = studentDTO.StudentNumber
            };
            await repository.AddStudent(student);
            return TypedResults.Created($"/students/{student.Id}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, StudentDTO studentDTO)
        {
            var existingStudent = await repository.GetStudentById(id);

            if (existingStudent == null)
            {
                return TypedResults.NotFound();
            }

            existingStudent.FirstName = studentDTO.FirstName;
            existingStudent.LastName = studentDTO.LastName;
            existingStudent.StudentNumber = studentDTO.StudentNumber;

            var updatedStudent = await repository.UpdateStudent(id, existingStudent);

            return TypedResults.Created($"/students/{id}", updatedStudent);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var student = await repository.GetStudentById(id);
            if (student == null)
            {
                return TypedResults.NotFound();
            }

            await repository.DeleteStudent(id);
            return TypedResults.Ok(student);
        }
    }


}
