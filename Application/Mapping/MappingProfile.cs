using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, User>()
                .ForPath(r => r.Email, act => act.MapFrom(x => new Email { EmailAddress = x.Email, Malling = x.IsMailing }))
                .ReverseMap();
            CreateMap<Register, Login>()
                .ForMember(dest => dest.LoginUser, act => act.MapFrom(x => x.Login));
            CreateMap<User, Response>();
        }
    }
}
