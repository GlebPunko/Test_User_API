using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, User>().ReverseMap();
            CreateMap<Register, Login>()
                .ForMember(dest => dest.LoginUser, act => act.MapFrom(x => x.Login));
        }
    }
}
