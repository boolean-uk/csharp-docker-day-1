using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTOs;
using System.Net.Sockets;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, GetCourseDTO>();

        CreateMap<Student, GetCourseStudentDTO>();

        CreateMap<PostCourseDTO, Course>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.Students, opt => opt.Ignore());

        CreateMap<Student, GetStudentDTO>();

        CreateMap<Course, GetStudentCourseDTO>();

        CreateMap<PostStudentDTO, Student>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.Course, opt => opt.Ignore());
    }
}