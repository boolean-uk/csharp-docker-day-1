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
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var students = await repository.GetAll();
            var studentResponse = students.Select(s => new StudentDTO(s));
            var response = new Response<IEnumerable<StudentDTO>>() { Data = studentResponse };
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository<Student> repository, int id)
        {
            var student = await repository.GetById(id);
            var response = new Response<StudentDTO>() { Data = new StudentDTO(student) };
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository<Student> repository, StudentPayload model)
        {
            var students = await repository.GetAll();

            if (students.Any(s => s.FirstName == model.FirstName))
            {
                return TypedResults.BadRequest($"{model.FirstName} already exists");
            }

            var addStudent = new Student() { FirstName = model.FirstName, LastName = model.LastName, DoB = model.DoB, CourseId = model.CourseId};
            addStudent = await repository.Add(addStudent);
            var response = new Response<StudentDTO>() { Data = new StudentDTO(addStudent) };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentPayload model)
        {
            var updateStudent = await repository.GetById(id);
            updateStudent.FirstName = model.FirstName;
            updateStudent.LastName = model.LastName;
            updateStudent.DoB = model.DoB;

            updateStudent = await repository.Update(updateStudent);

            var response = new Response<StudentDTO>() { Data = new StudentDTO(updateStudent) };

            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            Response<IEnumerable<StudentDTO>> response = new();
            List<StudentDTO> StudentDTO = new();
            var deletedStudent = await repository.Delete(id);
            StudentDTO.Add(new StudentDTO(deletedStudent));
            response.Data = StudentDTO;
            return TypedResults.Ok(response);
        }


    }


}
