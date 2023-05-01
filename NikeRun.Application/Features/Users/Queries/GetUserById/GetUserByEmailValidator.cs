using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByEmailValidator : AbstractValidator<GetUsersByEmailQuery>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailValidator(IUsersRepository usersRepository)
        {
            RuleFor(e => e)
             .MustAsync(isUserExist).WithMessage("User Doesnt Exist");
            _usersRepository = usersRepository;
        }

        private async Task<bool> isUserExist(GetUsersByEmailQuery e, CancellationToken token)
        {
            return await _usersRepository.isUserExist(e.email);
        }
    }
}
