using AutoMapper;
using ePregledi.Models.Models;
using ePregledi.Models.Responses;

namespace ePregledi.API.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserRegistrationResult, User>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.UserId, memberOptions => memberOptions.MapFrom(src => src.Id));

            CreateMap<User, User>().ReverseMap();

            CreateMap<User, DoctorViewModel>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.MapFrom(src => src.DoctorId));

            CreateMap<DoctorViewModel, User>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.DoctorId, memberOptions => memberOptions.MapFrom(src => src.Id));

            CreateMap<DoctorViewModel, UserRole>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.DoctorId, memberOptions => memberOptions.MapFrom(src => src.UserId))
                .ForMember(destinationMember => destinationMember.FirstName, memberOptions => memberOptions.MapFrom(src => src.User.FirstName))
                .ForMember(destinationMember => destinationMember.LastName, memberOptions => memberOptions.MapFrom(src => src.User.LastName));

            CreateMap<User, PatientViewModel>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.MapFrom(src => src.PatientId));

            CreateMap<PatientViewModel, User>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.PatientId, memberOptions => memberOptions.MapFrom(src => src.Id));

            CreateMap<User, UserEditViewModel>()
                .ReverseMap()
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.MapFrom(src => src.UserId));

            CreateMap<Examination, Examination>()
                .ReverseMap();
        }
    }
}
