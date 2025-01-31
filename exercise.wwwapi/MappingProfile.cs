using AutoMapper;
using exercise.wwwapi.DTO;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDTO>();
        CreateMap<StudentDTO, Student>();

        CreateMap<Course, CourseDTO>();
        CreateMap<CourseDTO, Course>();
    }   
}
