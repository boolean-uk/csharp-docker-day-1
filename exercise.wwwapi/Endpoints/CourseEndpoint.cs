using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Interfaces;
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
            students.MapPost("/", PostCourse);
            students.MapGet("/", GetAllCourses);
            students.MapGet("/{id}", GetCourseById);
            students.MapPut("/{id}", UpdateCourseById);
            students.MapDelete("/{id}", DeleteCourseById);
        }

        public static async Task<IResult> PostCourse(IRepository<Course> repository, CoursePost model)
        {
            var payload = new Payload<ICourse>()
            {
                data = model
            };

            var newInsert = await repository.Insert(DTOHelper.EntityMapper<Course>(model));
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(newInsert);
            payload.data = courseDTO;

            return TypedResults.Created($"/{courseDTO.Id}", newInsert);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllCourses(IRepository<Course> repository)
        {
            var results = await repository.SelectAll();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();

            if (results == null)
            {
                return TypedResults.NotFound("Could not find any courses");
            }

            foreach (var course in results)
            {
                courseDTOs.Add(DTOHelper.EntityMapper<CourseDTO>(course));
            }

            var payload = new Payload<IEnumerable<CourseDTO>>() { data = courseDTOs };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetCourseById(IRepository<Course> repository, int id)
        {
            var result = await repository.SelectById(id);
            if(result == null)
            {
                return TypedResults.NotFound("Could not find the course");
            }   
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(result);
            var payload = new Payload<CourseDTO>() { data = courseDTO };
            return TypedResults.Ok(payload);
        }

        //Too much. failed payload is just redundant I think. 
        public static async Task<IResult> UpdateCourseById(IRepository<Course> repository, int id, CoursePut model)
        {
            var failedPayload = new Payload<CoursePut>()
            {
                data = model
            };

            var existingCourse = await repository.SelectById(id);
            if (existingCourse == null)
            {
                failedPayload.status = "Could not find the existing course";
                return TypedResults.NotFound(failedPayload);
            }   
            var updatedCourse = DTOHelper.EntityMapper<Course>(model);
            //check if any of the model properties are null, if they are, use the existing course properties
            if (updatedCourse.CourseTitle == null)
            {
                updatedCourse.CourseTitle = existingCourse.CourseTitle;
            }
            if (updatedCourse.AverageGrade == null)
            {
                updatedCourse.AverageGrade = existingCourse.AverageGrade;
            }
            if (updatedCourse.StartDate == null)
            {
                updatedCourse.StartDate = existingCourse.StartDate;
            }

            var result = await repository.Update(id, updatedCourse);

            if (result == null)
            {
                failedPayload.status = "Could not update the course";
                return TypedResults.BadRequest(failedPayload);
            }
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(result);

            var SuccessPayload = new Payload<CourseDTO>()
            {
                data = courseDTO
            };

            return TypedResults.Ok(SuccessPayload);
        }

        public static async Task<IResult> DeleteCourseById(IRepository<Course> repository, int id)
        {
            var result = await repository.Delete(id);

            if (result == null)
            {
                return TypedResults.NotFound("Could not find the course");
            }
            var courseDTO = DTOHelper.EntityMapper<CourseDTO>(result);
            var payload = new Payload<CourseDTO>() { data = courseDTO };
            return TypedResults.Ok(payload);
        }
    }
}
