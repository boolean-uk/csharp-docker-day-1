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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            Payload<List<GetStudentDto>> output = new();
            output.data = new();
            foreach(Student student in await repository.Get())
            {
                output.data.Add(new GetStudentDto(student));
            }
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, PostStudent newStudent)
        {
            Payload<StudentDto> output = new();

            var students = await repository.Get();
            Student student = new Student(newStudent);
            student.Id = students.Last().Id + 1;

            output.data = new StudentDto(await repository.Create(student));
            return TypedResults.Created($"/{output.data.Id}", output);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, PostStudent updateStudent)
        {
            Payload<GetStudentDto> output = new();

            Student student = await repository.GetById(id);
            if (student == null)
            {
                output.status = "not found";
                return TypedResults.NotFound(output);
            }

            student.FirstName = updateStudent.FirstName != null ? updateStudent.FirstName : output.data.FirstName;
            student.LastName = updateStudent.LastName != null ? updateStudent.LastName : output.data.LastName;
            student.DOB = updateStudent.DOB != null ? updateStudent.DOB : output.data.DOB;
            student.CourseId = updateStudent.CourseId != null ? updateStudent.CourseId : output.data.CourseId;

            output.data = new GetStudentDto(await repository.Update(student));

            return TypedResults.Created($"/{output.data.Id}", output);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            Payload<StudentDto> output = new();
            Student student = await repository.GetById(id);
            if (student == null)
            {
                output.status = "failed";
                return TypedResults.NotFound(output);
            }
            output.data = new StudentDto(await repository.Delete(id));
            if (output.data == null)
            {
                output.status = "failed";
                return TypedResults.NotFound(output);
            }
            return TypedResults.Ok(output);
        }
    }
  

}
