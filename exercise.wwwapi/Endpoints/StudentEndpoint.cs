using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
using exercise.wwwapi.Posts___Puts;
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
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            List<StudentDTO> students = new List<StudentDTO>();

            foreach (var student in results)
            {
                
                students.Add(CreateStudentDTO(student));
                
            }

            Payload<IEnumerable<StudentDTO>> payload = new Payload<IEnumerable<StudentDTO>>();
            payload.data = students;
            
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repo, StudentPostPut newStudent)
        {
            var students = await repo.GetAll();
            var entity = new Student()
            {
                Id = (students.Count() == 0 ? 0 : students.Max(dude => dude.Id) + 1),
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                DateOfBirth = newStudent.DateOfBirth,
                CourseId = newStudent.CourseId
            };

            StudentDTO dto = CreateStudentDTO(await repo.Create(entity));

            Payload<StudentDTO> payload = new Payload<StudentDTO>();
            payload.data = dto; 
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateStudent(IRepository<Student> repo, int id, StudentPostPut updateStudent)
        {
            var st = await repo.GetById(id);
            var entity = new Student()
            {
                Id = id,
                FirstName = updateStudent.FirstName,
                LastName = updateStudent.LastName,
                DateOfBirth = updateStudent.DateOfBirth,
                CourseId = updateStudent.CourseId,
            };
            var updated = await repo.Update(st);

            

            Payload<StudentDTO> payload = new Payload<StudentDTO>();
            payload.data = CreateStudentDTO(updated);
            return TypedResults.Created($"/{entity.Id}", entity);
        }

        public static async Task<IResult> DeleteStudent(IRepository<Student> repo, int id)
        {
            var entity = await repo.GetById(id);
            if(entity == null)
            {
                return TypedResults.NotFound();
            }

            var updated = await repo.Delete(id);


            Payload<StudentDTO> payload = new Payload<StudentDTO>();
            payload.data = CreateStudentDTO(updated);
            return TypedResults.Ok(payload);
        }

        static StudentDTO CreateStudentDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Course = new CourseStudentDTO()
                {
                    CourseId = student.CourseId,
                    CourseName = student.Course.CourseName,
                    AverageGrade = student.Course.AvgGrade,
                    StartDate = student.Course.StartOfCourse,
                }
            };
        }

    }
  

}
