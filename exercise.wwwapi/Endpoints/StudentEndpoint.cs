using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapPost("/", CreateStudent);
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudentById);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }

        public static async Task<IResult> CreateStudent(IRepository<Student> repository, IMapper mapper, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return TypedResults.BadRequest("Student name is invalid.");
            }

            var newStudent = new Student { Name = name };
            var createdStudent = await repository.Insert(newStudent);
            var studentDTO = mapper.Map<StudentDTO>(createdStudent);
            var payload = new Payload<StudentDTO>() { Data = studentDTO };
            return TypedResults.Created($"/students/{createdStudent.Id}", payload);
        }

        public static async Task<IResult> GetStudents(IRepository<Student> repository, IMapper mapper)
        {
            var results = await repository.Get();
            var studentDTOs = results.Select(student => mapper.Map<StudentDTO>(student));
            var payload = new Payload<IEnumerable<StudentDTO>>() { Data = studentDTOs };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetStudentById(IRepository<Student> repository, IMapper mapper, int id)
        {
            var student = await repository.GetById(id);
            if (student == null)
            {
                return TypedResults.NotFound();
            }

            var studentDTO = mapper.Map<StudentDTO>(student);
            var payload = new Payload<StudentDTO>() { Data = studentDTO };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, IMapper mapper, int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return TypedResults.BadRequest("Student name is invalid.");
            }

            var existingStudent = await repository.GetById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound();
            }

            existingStudent.Name = name;
            var updatedStudent = await repository.Update(existingStudent);
            var studentDTO = mapper.Map<StudentDTO>(updatedStudent);
            var payload = new Payload<StudentDTO>() { Data = studentDTO };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, IMapper mapper, int id)
        {
            var existingStudent = await repository.GetById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound();
            }

            var deletedStudent = await repository.Delete(id);
            var studentDTO = mapper.Map<StudentDTO>(deletedStudent);
            var payload = new Payload<StudentDTO>() { Data = studentDTO };
            return TypedResults.Ok(payload);
        }
    }
}
