using AutoMapper;
using FluentValidation;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NikeRun.Application.Features.Users.Commands.RegisterUser
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponseModel<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<BaseResponseModel<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var baseResponseModel = new BaseResponseModel<string>();
            var validators = new RegisterUserCommandValidator(_usersRepository);

            var validationResults = await validators.ValidateAsync(request);

            if (validationResults.Errors.Count() > 0)
            {
                throw new ValidationErrorsException(validationResults);
            }
            if (baseResponseModel.Success)
            {

                baseResponseModel.Message = "Registration Successfull";
                var userMapped = _mapper.Map<Domain.Entities.Users>(request.request);
                await _usersRepository.RegisterAsync(userMapped, request.request.Password);
            }

            return baseResponseModel;
        }

    }
}
