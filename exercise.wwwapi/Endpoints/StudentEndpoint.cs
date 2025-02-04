using System.Xml.Linq;
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
            students.MapPost("/", AddStudent);
            students.MapDelete("/", DeleteStudent);
            students.MapPut("/", UpdateStudent);
        }

        private static async Task<IResult> UpdateStudent(IRepository repository, int id, string name)
        {
            var updated = await repository.UpdateStudent(id, name);
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = updated.Id;
            studentDTO.Name = updated.Name;
            return TypedResults.Ok(studentDTO);

        }

        private static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var deleted = await repository.DeleteStudent(id);
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = deleted.Id;
            studentDTO.Name = deleted.Name;
            return TypedResults.Ok(studentDTO);
        }

        private static async Task<IResult> AddStudent(IRepository repository, string name)
        {
            var student = await repository.AddStudent(name);

            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = student.Id;
            studentDTO.Name = student.Name;


            return TypedResults.Ok(studentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();

            // Mapper Student til StudentDTO
            var studentDTOs = results.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

           
            return TypedResults.Ok(studentDTOs);
        }


    }


}
