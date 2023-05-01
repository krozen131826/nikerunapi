using AutoMapper;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using NikeRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NikeRun.Domain.Dtos.Users;

namespace NikeRun.Application.Profiles.Users
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Domain.Entities.Users, RegisterUserRequestDto>().ReverseMap();
            CreateMap<RegisterUserRequestDto, Domain.Entities.Users>().ReverseMap();
            CreateMap<Domain.Entities.Users, UserUpdateRequestDto>().ReverseMap();
        }
    }
}
