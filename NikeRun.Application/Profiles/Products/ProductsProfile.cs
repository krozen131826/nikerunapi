using AutoMapper;
using NikeRun.Application.Features.Products.Queries.GetProductList;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Profiles.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Domain.Entities.Products, ProductsDto>().ReverseMap();
        }
    }
}
