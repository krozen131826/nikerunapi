using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Queries.GetUserById
{
    internal sealed class GetUserByEmailQueryHandler : IRequestHandler<GetUsersByEmailQuery, BaseResponseModel<UserDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailQueryHandler( IMapper mapper,IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<BaseResponseModel<UserDetailsDto>> Handle(GetUsersByEmailQuery request, CancellationToken cancellationToken)
        {
            var getUserDetailsResponse = new BaseResponseModel<UserDetailsDto>();

            var validator = new GetUserByEmailValidator(_usersRepository);

            var validatorResults = await validator.ValidateAsync(request);

            if (validatorResults.Errors.Count > 0)
            {
                throw new ValidationErrorsException(validatorResults);
            }

            if (getUserDetailsResponse.Success)
            {
                var userDetails = _usersRepository.GetUserByEmail(request.email);

                getUserDetailsResponse.Data = _mapper.Map<UserDetailsDto>(userDetails);
            }

            return getUserDetailsResponse;
        }
    }
}
