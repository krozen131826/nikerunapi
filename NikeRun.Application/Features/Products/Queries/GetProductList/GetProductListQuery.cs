using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Products.Queries.GetProductList
{
    public record GetProductListQuery : IRequest<GetProductListQueryResponse>;
}
