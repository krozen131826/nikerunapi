using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Carts.Queries
{
    public class GetUserCartValidator : AbstractValidator<GetUserCartListQuery>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserCartValidator(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            RuleFor(e => e)
               .MustAsync(isUserExist)
               .WithMessage("User Doesnt Exist");
        }

        private async Task<bool> isUserExist(GetUserCartListQuery e, CancellationToken token)
        {
            return await _usersRepository.isUserExist(e.emailAddress);
        }
    }
    
}
