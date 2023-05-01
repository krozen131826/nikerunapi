using AutoMapper;
using NikeRun.Domain.Dtos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Profiles.Carts
{
    public class CartsProfile : Profile
    {
        public CartsProfile()
        {
            CreateMap<Domain.Entities.Carts, CartDto>().ReverseMap();
            CreateMap<UpdateCartDto, Domain.Entities.Carts>().ReverseMap();
        }
    }
}
