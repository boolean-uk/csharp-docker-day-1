using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("/students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", PostStudent);
            students.MapPut("/{id}", PutStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var students = await repository.Get();
            var studentOutputDtos = students.Select(StudentOutputDto.Create);
            

            var payload = new Payload<IEnumerable<StudentOutputDto>>() { data = studentOutputDtos };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PostStudent(IRepository<Student> repository, StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return TypedResults.BadRequest("Student data is required.");
            }

            var student = new Student()
            {
                AvgGrade = studentDto.AvgGrade,
                DOB = studentDto.DOB,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
            };

            var createdStudent = await repository.Insert(student);
            return TypedResults.Created($"/students/{createdStudent.Id}", new Payload<StudentOutputDto> { data = StudentOutputDto.Create(createdStudent) });
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> PutStudent(IRepository<Student> repository, int id, StudentDto studentDto)
        {
            var student = await repository.GetById(id);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found.");
            }

            student.FirstName = studentDto.FirstName; 
            student.LastName = studentDto.LastName;
            student.AvgGrade = studentDto.AvgGrade;
            student.DOB = studentDto.DOB;

            var updatedStudent = await repository.Update(student);

            return TypedResults.Created($"students/{id}", new Payload<StudentOutputDto> { data = StudentOutputDto.Create(updatedStudent) });
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var student = await repository.Delete(id);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found.");
            }

            return TypedResults.Ok(new Payload<StudentOutputDto> { data = StudentOutputDto.Create(student) });
        }
    }
}
