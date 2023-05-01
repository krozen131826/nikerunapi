using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Queries.GetUserById
{
    public record GetUsersByEmailQuery(string email) : IRequest<GetUserByEmailResponse>
    {

    }
}
