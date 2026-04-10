using AutoMapper;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<AddressCreateDTO, Address>();
        CreateMap<AddressUpdateDTO, Address>();

        CreateMap<Branch, BranchDTO>().ReverseMap();
        CreateMap<BranchCreateDTO, Branch>();
        CreateMap<BranchUpdateDTO, Branch>();

        CreateMap<Course, CourseDTO>()
            .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.Students.Count))
            .ForMember(dest => dest.SubjectCount, opt => opt.MapFrom(src => src.Subjects.Count));
        
        CreateMap<CourseCreateDTO, Course>();
        CreateMap<CourseUpdateDTO, Course>();


        CreateMap<Subject, SubjectDTO>()
            .ForMember(dest => dest.TeacherCount, opt => opt.MapFrom(src => src.Teachers.Count))
            .ForMember(dest => dest.CourseCount, opt => opt.MapFrom(src => src.Courses.Count));

        CreateMap<SubjectCreateDTO, Subject>();
        CreateMap<SubjectUpdateDTO, Subject>();

        CreateMap<Student, StudentDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));

        CreateMap<Student, StudentDetailsDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));

        CreateMap<StudentCreateDTO, Student>();
        CreateMap<StudentUpdateDTO, Student>();


        CreateMap<Teacher, TeacherDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(s => s.SubjectName)));

        CreateMap<Teacher, TeacherDetailsDTO>()
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));

        CreateMap<TeacherCreateDTO, Teacher>();
        CreateMap<TeacherUpdateDTO, Teacher>();
    }
}
