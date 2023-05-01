using MediatR;
using NikeRun.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand(LoginUserRequestDto request) : IRequest<LoginUserCommandResponse>;
}
