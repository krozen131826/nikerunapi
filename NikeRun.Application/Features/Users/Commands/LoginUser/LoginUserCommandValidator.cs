using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IUtilitiesService _utilitiesService;

        public LoginUserCommandValidator(IUsersRepository userRepository, IUtilitiesService utilitiesService)
        {
            _userRepository = userRepository;
            _utilitiesService = utilitiesService;

            RuleFor(v => v.request.EmailAddress)
            .NotNull().WithMessage("Email Address is Required")
            .EmailAddress().WithMessage("Please Enter Valid Email Address");

            RuleFor(v => v.request.Password)
            .NotNull().WithMessage("Password is Required")
            .MinimumLength(8).WithMessage("Password should be 8 Characters Long");

            RuleFor(e => e)
               .MustAsync(isUserExist).WithMessage("User Doesnt Exist");

            RuleFor(e => e)
               .MustAsync(VerifyUser).WithMessage("Invalid Credentials");
        }
        private async Task<bool> isUserExist(LoginUserCommand e, CancellationToken token)
        {
            return await _userRepository.isUserExist(e.request.EmailAddress);
        }

        private async Task<bool> VerifyUser(LoginUserCommand e, CancellationToken token)
        {
            var user = await _userRepository.GetUserByEmail(e.request.EmailAddress);

            if (user is null)
            {
                return false;
            }

            var isVerified = _utilitiesService.VerifyPasswordHash(e.request.Password, user.PasswordHash, user.PasswordSalt);

            if (!isVerified)
            {
                return false;

            }
            return isVerified;
        }
    }

}
