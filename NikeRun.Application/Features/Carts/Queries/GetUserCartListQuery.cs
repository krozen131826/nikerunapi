using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Queries
{
    public record GetUserCartListQuery(string emailAddress, int userId) : IRequest<GetUserCartResponse>;
}
