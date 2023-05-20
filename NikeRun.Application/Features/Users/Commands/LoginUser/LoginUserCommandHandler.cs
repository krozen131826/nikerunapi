using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.Application.Exception;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.LoginUser;
internal sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponseModel<LoginResponseDto>>
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

    public async Task<BaseResponseModel<LoginResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var loginUserResponse = new BaseResponseModel<LoginResponseDto>();

        var validators = new LoginUserCommandValidator(_userRepository, _utilitiesService);

        var validationResults = await validators.ValidateAsync(request);

        var user = await _userRepository.GetUserByEmail(request.request.EmailAddress);

        if (validationResults.Errors.Count() > 0)
        {
            throw new ValidationErrorsException(validationResults);
        }
        if (loginUserResponse.Success)
        {
            loginUserResponse.Message = "Login Successfull";

            var result = await _userRepository.LoginUser(user!);

            loginUserResponse.Data = result;

        }

        return loginUserResponse;
    }
}
   

