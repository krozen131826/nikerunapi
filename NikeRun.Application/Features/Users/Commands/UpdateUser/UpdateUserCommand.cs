using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using NikeRun.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(string emailAddress, JsonPatchDocument<UserUpdateRequestDto> patchDocument) : IRequest<UpdateUserCommandResponse>
    {
    }
}
