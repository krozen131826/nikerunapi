using MediatR;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Queries.GetUserById
{
    public record GetUsersByEmailQuery(string email) : IRequest<BaseResponseModel<UserDetailsDto>>
    {

    }
}
