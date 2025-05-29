using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LName));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<Course, CourseDTO>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => $"{src.Teacher.User.FName} {src.Teacher.User.LName}"));

            CreateMap<CourseDTO, Course>();
        }
    }
} 