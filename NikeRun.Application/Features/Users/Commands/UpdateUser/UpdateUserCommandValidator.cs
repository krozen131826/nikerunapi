using AutoMapper;
using FluentValidation;
using Newtonsoft.Json.Linq;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUsersRepository _userRepository;
        public UpdateUserCommandValidator(IUsersRepository userRepository)
        {

            _userRepository = userRepository;

            RuleFor(x => x.patchDocument)
                .Custom((patchDocument, context) =>
                {
                    foreach (var doc in patchDocument.Operations)
                    {
                        if (doc.op != "replace")
                        {
                            context.AddFailure("Invalid Operation");
                        }
                    }
                });

            RuleFor(x => x.patchDocument.Operations.Where(x => x.path.Equals("/FirstName")))
            .NotNull()
            .NotEmpty().WithMessage("First Name Path is Required");

            RuleFor(x => x.patchDocument.Operations.Where(x => x.path.Equals("/LastName")))
            .NotNull()
            .NotEmpty().WithMessage("Last Name Path is Required");

            RuleFor(x => x.patchDocument.Operations.Where(x => x.path.Equals("/Address")))
            .NotNull()
            .NotEmpty().WithMessage("Address Path is Required");

            RuleFor(x => x.patchDocument.Operations.Where(x => x.path.Equals("/EmailAddress")))
             .NotNull()
             .NotEmpty().WithMessage("Email Address Path is Required");

            RuleFor(x => x.patchDocument.Operations.Where(x => x.path.Equals("/ContactNumber")))
             .NotNull()
             .NotEmpty().WithMessage("Contact Number Path is Required");

            RuleFor(x => x.patchDocument)
             .Custom((patchDocument, context) =>
                {
                    foreach (var docs in patchDocument.Operations)
                    {

                        if (docs.value is null)
                        {
                            context.AddFailure("Fields cannot be null");
                        }
                        if (String.IsNullOrEmpty(docs.value as string))
                        {
                            context.AddFailure("Fields cannot be empty");
                        }

                    }

             });

            RuleFor(e => e)
            .MustAsync(isUserExist).WithMessage("User Doesnt Exist");
        }


        private async Task<bool> isUserExist(UpdateUserCommand e, CancellationToken token)
        {

            return await _userRepository.isUserExist(e.emailAddress);
        }
    }
}
