using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
            students.MapPut("/{id}", EditStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            if (results != null)
            {
                Payload<List<StudentDTOGet>> payload = new Payload<List<StudentDTOGet>>();
                payload.Data = new List<StudentDTOGet>();
                foreach (var student in results)
                {
                    payload.Data.Add(new StudentDTOGet()
                    {
                        StudentId = student.StudentId,
                        StudentName = student.Name,
                        DateOfBirth = student.DateOfBirth,
                        AverageGrade = student.AverageGrade
                    });
                }
                payload.status = "success";
                return TypedResults.Ok(payload);
                

            }
            else
            {
                return TypedResults.NotFound("No students found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPOSTModel model)
        {
            var newStudent = await repository.CreateStudent(new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth.ToUniversalTime()
            });
            if (newStudent != null)
            {
                StudentDTOCreated createdStudent = new StudentDTOCreated()
                {
                    StudentId = newStudent.StudentId,
                    StudentName = newStudent.Name,
                    DateOfBirth = newStudent.DateOfBirth.ToUniversalTime()
                };
                return TypedResults.Created("success", createdStudent);
            }
            else
            {
                return TypedResults.BadRequest("Could not create student");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> EditStudent(IRepository repository, StudentPUTModel model, int id)
        {
            var edited = await repository.GetStudentById(id);
            if (edited != null)
            {
                StudentPUTModel innParams = (new StudentPUTModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth
                });
                if (innParams.FirstName != "")
                {
                    edited.FirstName = innParams.FirstName;
                }
                if (innParams.LastName != "")
                {
                    edited.LastName = innParams.LastName;
                }
                if (innParams.DateOfBirth != null)
                {
                    edited.DateOfBirth = (DateTime)innParams.DateOfBirth.ToUniversalTime();
                }
                await repository.EditStudent(edited);
                StudentDTOCreated responseStudent = new StudentDTOCreated()
                {
                    StudentId = edited.StudentId,
                    StudentName = edited.Name,
                    DateOfBirth = edited.DateOfBirth
                };
                return TypedResults.Created("success", edited);
            }
            else
            {
                return TypedResults.BadRequest("Could not update Student");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var deleted = await repository.DeleteStudent(id);
            if (deleted != null)
            {
                StudentDTOGet deletedStudent = new StudentDTOGet()
                {
                    StudentId = deleted.StudentId,
                    StudentName = deleted.Name,
                    DateOfBirth = deleted.DateOfBirth
                };
                return TypedResults.Ok(deletedStudent);
            }
            else
            {
                return TypedResults.NotFound("Could not delete - student not found");
            }
        }


    }


}
