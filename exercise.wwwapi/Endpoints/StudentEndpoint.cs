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
            students.MapGet("/{id}", GetStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            try
            {
                var results = await repository.GetAll();
                List<StudentDTO> studentDTOs = new List<StudentDTO>();
                foreach (var student in results)
                {
                    StudentDTO studentDTO = new StudentDTO()
                    {
                        CourseName = student.Course.Name,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth
                    };
                    studentDTOs.Add(studentDTO);
                    Console.WriteLine(studentDTO.FirstName);
                }
                var payload = new Payload<IEnumerable<StudentDTO>>() { Data = studentDTOs };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
        {
            try
            {
                var student = await repository.GetById(id);
                StudentDTO studentDTO = new StudentDTO()
                {
                    CourseName = student.Course.Name,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth
                };

                var payload = new Payload<StudentDTO>() { Data = studentDTO };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex) 
            { 
                return TypedResults.Problem(ex.Message);
            }


        }


    }


}
