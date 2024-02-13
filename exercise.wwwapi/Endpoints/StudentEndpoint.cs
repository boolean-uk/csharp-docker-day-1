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
            students.MapPost("/", PostStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", PutStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.Get();
            var DTOs = new List<StudentDTO>();
            foreach (var student in results)
            {
                DTOs.Add(CreateStudentDTO(student));
            }

            var payload = new Payload<IEnumerable<StudentDTO>>() { data = DTOs.OrderBy(d=>d.Id) };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostStudent(IRepository<Student> repository, InputStudent input)
        {
            var students = await repository.Get();
            var entity = new Student()
            {
                Id = (students.Count() == 0 ? 0 : students.Max(patient => patient.Id) + 1),
                FirstName = input.FirstName,
                LastName = input.LastName,
                CourseId = input.courseId,
                DateOfBirth = input.DateOfBirth.ToUniversalTime(),
            };
            StudentDTO DTO = CreateStudentDTO(await repository.Insert(entity));
            var payload = new Payload<StudentDTO>() { data = DTO };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var student = await repository.GetById(id);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found.");
            }
            var result = await repository.Delete(id);
            var payload = new Payload<StudentDTO>() { data = CreateStudentDTO(result) };
            return result != null ? TypedResults.Ok(payload) : Results.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutStudent(IRepository<Student> repository, int id, InputStudent input)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound(id);
            }

            entity.FirstName = input.FirstName != null ? input.FirstName : entity.FirstName;
            entity.LastName = input.LastName != null ? input.LastName : entity.LastName;
            entity.CourseId = input.courseId != null ? input.courseId : entity.CourseId;
            entity.DateOfBirth = input.DateOfBirth != null ? input.DateOfBirth : entity.DateOfBirth;
            var result = await repository.Update(entity);
            var payload = new Payload<StudentDTO>() { data = CreateStudentDTO(result) };
            return TypedResults.Created($"/{entity.Id}", entity);
        }
        static StudentDTO CreateStudentDTO(Student student)
        {
            return new StudentDTO
            {
                Course = new CourseForStudentDTO
                {
                    AverageGrade = student.Course.AverageGrade,
                    StartDate = student.Course.StartDate,
                    CourseId = student.CourseId,
                    CourseName = student.Course.CourseName
                },
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Id = student.Id,
            };
        }

    }
  

}
