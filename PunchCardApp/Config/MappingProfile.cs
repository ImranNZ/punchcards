using AutoMapper;
using PunchCardApp.Models;
using PunchCardApp.ViewModels;

namespace PunchCardApp.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(destination => destination.Email, map => map.MapFrom(source => source.Email))
                .ForMember(destination => destination.Name, map => map.MapFrom(source => source.Name))
                .ForMember(destination => destination.Password, map => map.MapFrom(source => source.Password))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<User, UserViewModel>()
                .ForMember(destination => destination.Email, map => map.MapFrom(source => source.Email))
                .ForMember(destination => destination.Name, map => map.MapFrom(source => source.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunchCardViewModel, PunchCard>()
                .ForMember(destination => destination.PunchIn, map => map.MapFrom(source => source.PunchIn))
                .ForMember(destination => destination.PunchOut, map => map.MapFrom(source => source.PunchOut))
                .ForMember(destination => destination.Description, map => map.MapFrom(source => source.Description))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}