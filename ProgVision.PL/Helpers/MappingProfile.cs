using ProgVision.DAL.Entities;
using ProgVision.PL.Dtos;
using AutoMapper;
using System.Linq;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;

namespace ProgVision.PL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Courses, CoursesReturnDto>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.TraniersName, opt => opt.MapFrom(src => string.Join(", ", src.Teachings.Select(t => t.Trainer.Name))));


            CreateMap<Categories, CategoriesReturnDto>()
           .ForMember(dest => dest.CategoriesId, opt => opt.MapFrom(src => src.Id));


            CreateMap<Trainers, TrainerReturnDto>()
            .ForMember(t => t.Id, o => o.MapFrom(src => src.Id))
            .ForMember(n => n.Name, o => o.MapFrom(src => src.Name));


            CreateMap<CoursesCreateDto, Courses>()
            .ForMember(dest => dest.TeachingsId, opt => opt.MapFrom(src => src.TraniersId))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
             .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<CoursesCreateDto, Teaching>()
            .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TraniersId));
            

            CreateMap<Students, StudentsQueryDto>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
           .ForMember(dest => dest.Collage, opt => opt.MapFrom(src => src.Collage))
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt)).ReverseMap();

            CreateMap<Revision, StudentsQueryDto>()
                .ForMember(dest => dest.Student_grade, opt => opt.MapFrom(src => src.Grade))
                .ForMember(dest => dest.Total_Right_Degree, opt => opt.MapFrom(src => src.TotalRightDegree))
                .ForMember(dest => dest.Total_Wrong_Degree, opt => opt.MapFrom(src => src.TotalWrongDegree)).ReverseMap();


            CreateMap<Courses, StudentsQueryDto>()
                .ForMember(dest => dest.Course_Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt)).ReverseMap();



        }



    }
}
