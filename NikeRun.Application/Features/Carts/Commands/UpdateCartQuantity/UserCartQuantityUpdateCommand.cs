using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using NikeRun.Domain.Dtos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.UpdateCartQuantity
{
    public record UserCartQuantityUpdateCommand(int cartId, int userId,JsonPatchDocument<UpdateCartDto> patchDocument) : IRequest<UserCartQuantityUpdateCommandResponse>
    {
    }
}
