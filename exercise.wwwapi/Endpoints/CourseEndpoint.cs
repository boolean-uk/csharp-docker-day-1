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
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapPost("/", AddCourse);
            courses.MapDelete("/", DeleteCourse);
            courses.MapPut("/", UpdateCourse);

        }

        private static async Task<IResult> UpdateCourse(IRepository repository, int id, string name)
        {
            var updated = await repository.UpdateCourse(id,name);
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.Id = updated.Id;
            courseDTO.Name = updated.Name;
            return TypedResults.Ok(courseDTO);

        }

        private static async Task<IResult> DeleteCourse(IRepository repository,int id)
        {
            var deleted = await repository.DeleteCourse(id);
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.Id = deleted.Id;
            courseDTO.Name = deleted.Name;
            return TypedResults.Ok(courseDTO);

        }

        private static async Task<IResult> AddCourse(IRepository repository, string name)
        {
            var course= await repository.AddCourse(name);

            CourseDTO courseDTO=new CourseDTO();
            courseDTO.Id=course.Id;
            courseDTO.Name=course.Name;


            return TypedResults.Ok(courseDTO);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();

           
            var courseDTOs = results.Select(c => new CourseDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return TypedResults.Ok(courseDTOs);
        }

    }
}
