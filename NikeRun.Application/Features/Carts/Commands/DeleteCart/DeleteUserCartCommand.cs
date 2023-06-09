﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.DeleteCart
{
    public record DeleteUserCartCommand(int cartId): IRequest<DeleteUserCartCommandResponse>
    {
    }
}
