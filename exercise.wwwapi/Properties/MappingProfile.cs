using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects.Course;
using exercise.wwwapi.DataTransferObjects.Student;

namespace exercise.wwwapi.Properties
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            //Student: 
            //CreateMap<Student, OutStudentDTO>();
            CreateMap<InStudentDTO, Student>();

            CreateMap<Student, OutStudentDTO>()
            .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));

            //Course:
            CreateMap<Course, OutCourseDTO>();
            CreateMap<InCourseDTO, Course>();


        }
    }
}
