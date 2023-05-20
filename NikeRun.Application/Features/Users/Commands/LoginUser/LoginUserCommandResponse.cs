using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandResponse : BaseResponseModel<LoginResponseDto>
    {
        public LoginUserCommandResponse():base()
        {
        }

        public LoginResponseDto LoginResponse { get; set; } = default!;
    }
}
