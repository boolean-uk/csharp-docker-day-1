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
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(typeof(Payload<IEnumerable<StudentResponse>>), StatusCodes.Status200OK)]
        private static async Task<IResult> GetStudents(IRepository<DataModels.Student> repository, IMapper mapper)
        {
            var results = await repository.GetAll(s => s.Courses);
            var payload = new Payload<IEnumerable<StudentResponse>>() { Data = mapper.Map<IEnumerable<StudentResponse>>(results) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(typeof(Payload<StudentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetStudent(IRepository<DataModels.Student> repository, IMapper mapper, Guid id)
        {
            var result = await repository.Get(x => x.Id == id, s => s.Courses);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            var payload = new Payload<StudentResponse>() { Data = mapper.Map<StudentResponse>(result) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(typeof(Payload<StudentResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateStudent(IRepository<DataModels.Student> repository, IMapper mapper, StudentPost student)
        {
            var result = await repository.Add(mapper.Map<DataModels.Student>(student));
            var payload = new Payload<StudentResponse>() { Data = mapper.Map<StudentResponse>(result) };
            return TypedResults.Created($"/students/{result.Id}", payload);
        }
        
        [ProducesResponseType(typeof(Payload<StudentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateStudent(IRepository<DataModels.Student> repository, IMapper mapper, Guid id, StudentPut student)
        {
            var result = await repository.Get(x => x.Id == id, s => s.Courses);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            mapper.Map(student, result);
            await repository.Update(result);
            
            var payload = new Payload<StudentResponse>() { Data = mapper.Map<StudentResponse>(result) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteStudent(IRepository<DataModels.Student> repository, Guid id)
        {
            var result = await repository.Get(x => x.Id == id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            await repository.Delete(result);
            return TypedResults.NoContent();
        }
    }
}
