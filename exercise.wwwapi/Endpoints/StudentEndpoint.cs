using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
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
            students.MapPost("/", createStudent);
            students.MapPost("/{id}", editStudent);
            students.MapDelete("/{id}", deleteStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var studentDTOs = results.Select(s => new GetStudentDTO()
            {
                courseId = s.courseId,
                DateOfBirth = s.DateOfBirth,
                firstName = s.firstName,
                lastName = s.lastName,
                Id = s.Id
            });
            var response = new Payload<IEnumerable<GetStudentDTO>>("Success", studentDTOs);
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> createStudent(IRepository repository, CreateStudentDTO dto)
        {
            var student = new Student()
            {
                firstName = dto.firstName,
                lastName = dto.lastName,
                courseId = 0,
                DateOfBirth = dto.DateOfBirth

            };
            var result = await repository.AddStudent(student);
            var response = new Payload<GetStudentDTO>("Success", new GetStudentDTO()
            {
                courseId = result.courseId,
                DateOfBirth = result.DateOfBirth,
                firstName = result.firstName,
                lastName = result.lastName,
                Id = result.Id
            });
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> editStudent(IRepository repository, int id, CreateStudentDTO dto)
        {
            var student = new Student()
            {
                firstName = dto.firstName,
                lastName = dto.lastName,
                courseId = 0,
                DateOfBirth = dto.DateOfBirth

            };
            var result = await repository.UpdateStudent(student);
            var response = new Payload<GetStudentDTO>("Success", new GetStudentDTO()
            {
                courseId = result.courseId,
                DateOfBirth = result.DateOfBirth,
                firstName = result.firstName,
                lastName = result.lastName,
                Id = result.Id
            });
            return TypedResults.Ok(response);
        }

        public static async Task<IResult> deleteStudent(IRepository repository, int id) {
                
            var student = await repository.DeleteStudent(id);
            var response = new Payload<GetStudentDTO>("Success", new GetStudentDTO()
            {
                courseId = student.courseId,
                DateOfBirth = student.DateOfBirth,
                firstName = student.firstName,
                lastName = student.lastName,
                Id = student.Id
            });

            return TypedResults.Ok(response);
       
        
        }




    }
}
