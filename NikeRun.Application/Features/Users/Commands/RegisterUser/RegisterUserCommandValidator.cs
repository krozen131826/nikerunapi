using FluentValidation;
using NikeRun.Application.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUsersRepository _userRepository;

        public RegisterUserCommandValidator(IUsersRepository userRepository)
        {
            _userRepository = userRepository;


            RuleFor(v => v.request.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .NotNull()
                .MaximumLength(15).WithMessage("Username must not exceed 15 characters.");

            RuleFor(v => v.request.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

            RuleFor(v => v.request.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

            RuleFor(v => v.request.EmailAddress)
                .NotEmpty().WithMessage("EmailAddress is required.")
                .NotNull()
                .EmailAddress().WithMessage("Please Enter a valid Email Address");

            RuleFor(v => v.request.Address)
                .NotEmpty().WithMessage("Address is required.")
                .NotNull();

            RuleFor(v => v.request.Password)
               .NotEmpty().WithMessage("Password is required.")
               .NotNull()
               .MinimumLength(8).WithMessage("Password Must Be Atleast 8 Charaters Long");

            RuleFor(v => v.request.ConfirmPassword)
               .NotEmpty().WithMessage("ConfirmPassword is required.")
               .NotNull()
               .Equal(x => x.request.Password).WithMessage("ConfirmPassword must match with Password");

            RuleFor(v => v.request.ContactNumber)
               .NotEmpty().WithMessage("ContactNumber is required.")
               .NotNull();

            RuleFor(e => e)
                .MustAsync(isUserExist).WithMessage("User Already Exist");
        }


        private async Task<bool> isUserExist(RegisterUserCommand e, CancellationToken token)
        {
            return !(await _userRepository.isUserExist(e.request.EmailAddress));
        }
    }
}
