using MediatR;
using NikeRun.Domain.Dtos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.AddToCart
{
    public record AddToCartCommand(string email, AddToCartDto cart) : IRequest<AddToCartCommandResponse>
    {
    }
}
