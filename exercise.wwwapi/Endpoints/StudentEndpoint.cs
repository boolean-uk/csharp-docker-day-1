using AutoMapper;
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
            students.MapPost("/", InsertStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);

            students.MapPost("/{studentId}/{courseId}", AddStudentToCourse);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository, IMapper mapper)
        {
            try
            {
                var results = await repository.GetAll();
                var response = mapper.Map<List<StudentGetDTO>>(results);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> InsertStudent(IRepository<Student> repository, IMapper mapper, StudentPostDTO student)
        {
            try
            {
                Student insert = mapper.Map<Student>(student);

                await repository.Insert(insert);

                return TypedResults.Created($"https://localhost:7242/students/{insert.Id}", insert);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentPostDTO student)
        {
            try
            {
                var target = await repository.GetById(id);

                if (target == null)
                    return Results.NotFound();
                if (student.Name != null)
                    target.Name = student.Name;

                await repository.Update(target);

                return TypedResults.Created($"https://localhost:7242/students/{target.Id}", target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            try
            {
                var target = await repository.GetById(id);

                if (await repository.Delete(id) != null)
                    return TypedResults.Ok(target);
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddStudentToCourse(IRepository<StudentCourse> repository, IRepository<Student> studentRepository, IRepository<Course> courseRepository, int studentId, int courseId)
        {
            try
            {
                var student = await studentRepository.GetById(studentId);
                var course = await courseRepository.GetById(courseId);

                if (student == null)
                    return TypedResults.NotFound("Student not found");
                if (course == null)
                    return TypedResults.NotFound("Course not found");

                await repository.Insert(new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = courseId
                });

                return TypedResults.Ok("Student added.");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
