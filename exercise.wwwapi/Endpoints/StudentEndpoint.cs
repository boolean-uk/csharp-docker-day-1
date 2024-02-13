using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Courses;
using exercise.wwwapi.DataTransferObjects.StudentCourse;
using exercise.wwwapi.DataTransferObjects.Students;
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
            students.MapPost("/", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapGet("/{id}/courses", GetStudentCourses);
            students.MapPost("/courses", AddStudentToCourse);
        }

        public static async Task<IResult> AddStudentToCourse([FromServices] IRepository<StudentCourse> repository,
            [FromServices] IMapper mapper,
            [FromBody] AddStudentCourse addStudentCourse)
        {
            Payload<GetStudentCourse> payload = new();
            try
            {
                StudentCourse sCourse = mapper.Map<StudentCourse>(addStudentCourse);
                StudentCourse studentCourse = await repository.Add(sCourse);
                payload.Data = mapper.Map<GetStudentCourse>(studentCourse);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        public static async Task<IResult> GetStudentCourses(IRepository<Student> repository, IMapper mapper, int id)
        {
            Payload<IEnumerable<GetCourseDTO>> payload = new();
            try
            {
                Student student = await repository.Get(id, "Courses");
                payload.Data = student.Courses.Select(mapper.Map<GetCourseDTO>);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository, IMapper mapper)
        {
            Payload<IEnumerable<GetStudentDTO>> payload = new();
            try
            {
                var results = await repository.GetAll("Courses");
                payload.Data = results.Select(mapper.Map<GetStudentDTO>);
                return TypedResults.Ok(payload);
            } catch (Exception ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.BadRequest(payload);
            }
        }

        public static async Task<IResult> GetStudent(IRepository<Student> repository, IMapper mapper, int id) 
        {
            Payload<GetStudentDTO> payload = new();
            try
            {
                Student student = await repository.Get(id, "Courses");
                payload.Data = mapper.Map<GetStudentDTO>(student);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        public static async Task<IResult> AddStudent(IRepository<Student> repository, 
            IMapper mapper,
            AddStudentDTO addStudentDTO)
        {
            Payload<GetStudentDTO> payload = new();
            try
            {
                Student student = mapper.Map<Student>(addStudentDTO);
                student = await repository.Add(student);
                payload.Data = mapper.Map<GetStudentDTO>(student);
                return TypedResults.Created(nameof(AddStudent), payload);
            } catch (Exception ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.BadRequest(payload);
            }
        }

        public static async Task<IResult> UpdateStudent(IRepository<Student> repository,
            IMapper mapper,
            [FromRoute] int id,
            [FromBody] AddStudentDTO addStudentDTO)
        {
            Payload<GetStudentDTO> payload = new();
            try
            {
                Student student = mapper.Map<Student>(addStudentDTO);
                student = await repository.Update(student, id);
                payload.Data = mapper.Map<GetStudentDTO>(student);
                return TypedResults.Ok(student);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        public static async Task<IResult> DeleteStudent(IRepository<Student> repository,
            IMapper mapper,
            [FromRoute] int id)
        {
            Payload<GetStudentDTO> payload = new();
            try
            {
                Student student = await repository.Delete(id);
                payload.Data = mapper.Map<GetStudentDTO>(student);
                return TypedResults.Ok(student);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

    }
  

}
