using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Commands.DeleteCart
{
    public class DeleteUserCartCommandResponse : BaseResponseModel<string>
    {
        public DeleteUserCartCommandResponse() :base()
        {
            
        }
    }
}
