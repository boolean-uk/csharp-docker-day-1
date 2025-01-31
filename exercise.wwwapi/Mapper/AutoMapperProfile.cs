using AutoMapper;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Student, DTO.Student>();
        CreateMap<Course, DTO.Course>();
        
        CreateMap<DTO.CoursePost, Course>();
        CreateMap<DTO.StudentPost, Student>();
        
        CreateMap<DTO.CoursePut, Course>();
        CreateMap<DTO.StudentPut, Student>();
        
        CreateMap<Student, DTO.StudentResponse>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
        CreateMap<Course, DTO.CourseResponse>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));
    }
}