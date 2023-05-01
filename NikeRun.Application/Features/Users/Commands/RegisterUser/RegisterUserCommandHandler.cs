using AutoMapper;
using FluentValidation;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NikeRun.Application.Features.Users.Commands.RegisterUser
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }
        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerUserCommandResponse = new RegisterUserCommandResponse();

            var validators = new RegisterUserCommandValidator(_usersRepository);

            var validationResults =  await validators.ValidateAsync(request);

            if (validationResults.Errors.Count() > 0)
            {
                registerUserCommandResponse.Success = false;
                registerUserCommandResponse.ValidationErrors = new List<string>();

                foreach (var errors in validationResults.Errors)
                {
                    registerUserCommandResponse.ValidationErrors.Add(errors.ErrorMessage);
                }
            }
            if (registerUserCommandResponse.Success) {

                registerUserCommandResponse.Message = "Registration Successfull";
                var userMapped = _mapper.Map<Domain.Entities.Users>(request.request);
                await _usersRepository.RegisterAsync(userMapped, request.request.Password);
            }

            return registerUserCommandResponse;
        }
    }
}
