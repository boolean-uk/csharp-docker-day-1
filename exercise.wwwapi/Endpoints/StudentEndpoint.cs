﻿using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTOs;
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
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", AddStudent);
            students.MapPatch("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository, IMapper mapper)
        {
            var results = await repository.GetStudents();
            var studentDtos = mapper.Map<IEnumerable<GetStudentDTO>>(results);

            var payload = new Payload<IEnumerable<GetStudentDTO>>() { Data = studentDtos };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository repository, IMapper mapper, int id)
        {
            Student student = null;
            try
            {
                student = await repository.GetStudent(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
            var studentDTO = mapper.Map<GetStudentDTO>(student);

            var payload = new Payload<GetStudentDTO>() { Data = studentDTO };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, IMapper mapper, PostStudentDTO studentDTO)
        {
            Student student = mapper.Map<Student>(studentDTO);
            var createdStudent = await repository.AddStudent(student);
            var getStudentDTO = mapper.Map<GetStudentDTO>(createdStudent);
            var location = $"/students/{createdStudent.Id}";

            var payload = new Payload<GetStudentDTO>() { Data = getStudentDTO };

            return TypedResults.Created(location, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, IMapper mapper, PatchStudentDTO studentDTO, int id)
        {

            Student updatedStudent = null;
            try
            {
                updatedStudent = await repository.UpdateStudent(studentDTO, id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var getStudentDTO = mapper.Map<GetStudentDTO>(updatedStudent);
            var location = $"/students/{updatedStudent.Id}";

            var payload = new Payload<GetStudentDTO>
            {
                Data = getStudentDTO
            };

            return TypedResults.Created(location, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, IMapper mapper, int id)
        {
            Student deletedStudent = null;

            try
            {
                deletedStudent = await repository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var getStudentDTO = mapper.Map<GetStudentDTO>(deletedStudent);

            var payload = new Payload<GetStudentDTO>
            {
                Data = getStudentDTO
            };

            return TypedResults.Ok(payload);
        }

    }
  

}
