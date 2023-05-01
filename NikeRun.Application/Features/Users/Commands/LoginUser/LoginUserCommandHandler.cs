using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.LoginUser;
internal sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _userRepository;
    private readonly IUtilitiesService _utilitiesService;

    public LoginUserCommandHandler(IMapper mapper, IUsersRepository userRepository, IUtilitiesService utilitiesService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _utilitiesService = utilitiesService;
    }
    public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var loginUserCommandResponse = new LoginUserCommandResponse();

        var validators = new LoginUserCommandValidator(_userRepository, _utilitiesService);

        var validationResults = await validators.ValidateAsync(request);

        var user = await _userRepository.GetUserByEmail(request.request.EmailAddress);

        if (validationResults.Errors.Count() > 0)
        {
            loginUserCommandResponse.Success = false;
            loginUserCommandResponse.ValidationErrors = new List<string>();

            foreach (var errors in validationResults.Errors)
            {
                loginUserCommandResponse.ValidationErrors.Add(errors.ErrorMessage);
            }
        }
        if (loginUserCommandResponse.Success)
        {
            loginUserCommandResponse.Message = "Login Successfull";

            var result = await _userRepository.LoginUser(user!);

            loginUserCommandResponse.LoginResponse = result;

        }

        return loginUserCommandResponse;
    }
}

