using MediatR;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(RegisterUserRequestDto request) : IRequest<BaseResponseModel<string>>;

}
