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
            students.MapPost("/", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            return TypedResults.Ok(StudentDTO.FromRepository(results));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {
            var result = await repository.AddStudent(student);
            return TypedResults.Created("Created", new StudentDTO(result));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, Student student)
        {
            var existingStudent = await repository.GetStudentById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound();
            }
            
            var result = await repository.UpdateStudent(id, student);
            return TypedResults.Ok(new StudentDTO(result));
        }
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var existingStudent = await repository.GetStudentById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound();
            }
            
            await repository.DeleteStudent(id);
            return TypedResults.NoContent();
        }

        public static async Task<IResult> AddCourseOnStudent(IRepository repository, int id, int courseId)
            {
                var existingStudent = await repository.GetStudentById(id);
                if (existingStudent == null)
                {
                    return TypedResults.NotFound();
                }
                
                var existingCourse = await repository.GetCourseById(courseId);
                if (existingCourse == null)
                {
                    return TypedResults.NotFound();
                }
                
                var student = await repository.AddCourseOnStudent(id, courseId);
                return TypedResults.Ok(new StudentDTO(student));
            }

    }
  

}
