using AutoMapper;
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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{studentId}/courses/{courseId}", AddStudentToCourse);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentDTO studentDTO)
        {
            var result = await repository.AddStudent(studentDTO);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, StudentDTO studentDTO)
        {
            var studentToEdit = await repository.GetStudent(id);
            if (studentToEdit == null)
            {
                return TypedResults.NotFound();
            }

            studentToEdit.Name = studentDTO.Name;
            studentToEdit.PhoneNumber = studentDTO.PhoneNumber;
            studentToEdit.Email = studentDTO.Email;

            var result = await repository.UpdateStudent(studentToEdit);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var result = await repository.DeleteStudent(id);
            var payload = new Payload<Student>() { Data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudentToCourse(IRepository repository, int studentId, int courseId, IMapper mapper)
        {
            var result = await repository.AddStudentToCourse(studentId, courseId);
            var studentDTO = mapper.Map<StudentDTO>(result);

            var payload = new Payload<StudentDTO>() { Data = studentDTO };

            return TypedResults.Ok(payload);
        }
    }
}
