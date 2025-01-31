using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            
            students.MapGet("/", GetCourses);
            students.MapGet("/{id}", GetCourse);
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
            
            students.MapPut("/{courseId}/students", AddStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetCourses(IRepository<DataModels.Course> repository, IMapper mapper)
        {
            var results = await repository.GetAll(c => c.Students);
            var payload = new Payload<IEnumerable<CourseResponse>>() { Data = mapper.Map<IEnumerable<CourseResponse>>(results) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetCourse(IRepository<DataModels.Course> repository, IMapper mapper, Guid id)
        {
            var result = await repository.Get(x => x.Id == id, c => c.Students);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            var payload = new Payload<CourseResponse>() { Data = mapper.Map<CourseResponse>(result) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateCourse(IRepository<DataModels.Course> repository, IMapper mapper, CoursePost course)
        {
            var result = await repository.Add(mapper.Map<DataModels.Course>(course));
            var payload = new Payload<DTO.Course>() { Data = mapper.Map<CourseResponse>(result) };
            return TypedResults.Created($"/courses/{result.Id}", payload);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateCourse(IRepository<DataModels.Course> repository, IMapper mapper, Guid id, CoursePut course)
        {
            var result = await repository.Get(x => x.Id == id, c => c.Students);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            var updated = mapper.Map(course, result);
            await repository.Update(updated);
            var payload = new Payload<CourseResponse>() { Data = mapper.Map<CourseResponse>(updated) };
            return TypedResults.Ok(payload);
        }
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteCourse(IRepository<DataModels.Course> repository, Guid id)
        {
            var result = await repository.Get(x => x.Id == id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            
            await repository.Delete(result);
            return TypedResults.NoContent();
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> AddStudent(IRepository<DataModels.Course> repository, IRepository<DataModels.Student> studentRepository, IMapper mapper, Guid courseId, Guid studentId)
        {
            var course = await repository.Get(x => x.Id == courseId, c => c.Students);
            if (course == null)
            {
                return TypedResults.NotFound();
            }
            
            var student = await studentRepository.Get(x => x.Id == studentId);
            if (student == null)
            {
                return TypedResults.NotFound();
            }
            
            course.Students.Add(student);
            await repository.Update(course);
            
            var payload = new Payload<CourseResponse>() { Data = mapper.Map<CourseResponse>(course) };
            return TypedResults.Ok(payload);
        }
    }
}
