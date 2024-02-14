using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTO;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/", AddCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var entities = await repository.GetCourses();

            List<CourseDto> courses = new List<CourseDto>();

            foreach(var entity in entities)
            {
                var course = new CourseDto()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    StartDate = entity.StartDate,
                    Students = entity.Students.Select(x => new StudentListDto()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DateOfBirth = x.DateOfBirth,
                        AverageGrade = x.AverageGrade

                    }).ToList(),
                };
                courses.Add(course);
            }

            Payload<List<CourseDto>> result = new Payload<List<CourseDto>>();
            result.data = courses;
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            var entities = await repository.GetCourses();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Course not found");
            }

            var entity = await repository.GetCourseById(id);
            var course = new CourseDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                Students = entity.Students.Select(x => new StudentListDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    AverageGrade = x.AverageGrade

                }).ToList(),
            };
            Payload<CourseDto> result = new Payload<CourseDto>();
            result.data = course;

            return TypedResults.Ok(result);
        } 
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCourse(IRepository repository, AddCourseDto course)
        {
            Course entity = new Course();
            entity.Title = course.Title;
            entity.StartDate = course.StartDate;
            await repository.AddCourse(entity);

            var courseDto = new CourseDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
            };
            Payload<CourseDto> result = new Payload<CourseDto>();
            result.data = courseDto;

            return TypedResults.Created(nameof(AddCourse), entity);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository repository, AddCourseDto course, int id)
        {       
            var entities = await repository.GetCourses();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Course not found");
            }

            var entity = await repository.GetCourseById(id);

            entity.Title = course.Title;
            entity.StartDate = course.StartDate;

            await repository.UpdateCourse(entity, id);

            var courseDto = new CourseDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                Students = entity.Students.Select(x => new StudentListDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    AverageGrade = x.AverageGrade

                }).ToList(),
            };
            Payload<CourseDto> result = new Payload<CourseDto>();
            result.data = courseDto;

            return TypedResults.Ok(entity);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var entities = await repository.GetCourses();
            if (!entities.Any(x => x.Id == id))
            {
                return TypedResults.NotFound("Course not found");
            }
            var entity = await repository.GetCourseById(id);

            var courseDto = new CourseDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                Students = entity.Students.Select(x => new StudentListDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    AverageGrade = x.AverageGrade

                }).ToList(),
            };
 
            await repository.DeleteCourse(id);
            Payload<CourseDto> result = new Payload<CourseDto>();
            result.data = courseDto;

            return TypedResults.Ok(entity);
            

        }
    }
}
