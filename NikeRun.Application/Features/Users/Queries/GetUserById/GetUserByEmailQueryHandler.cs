using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using NikeRun.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Queries.GetUserById
{
    internal sealed class GetUserByEmailQueryHandler : IRequestHandler<GetUsersByEmailQuery, GetUserByEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailQueryHandler( IMapper mapper,IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }
        public async Task<GetUserByEmailResponse> Handle(GetUsersByEmailQuery request, CancellationToken cancellationToken)
        {
            var getUserByEmailResponse = new GetUserByEmailResponse();
            var validator = new GetUserByEmailValidator(_usersRepository);

            var validatorResults = await validator.ValidateAsync(request);

            if (validatorResults.Errors.Count > 0)
            {
                getUserByEmailResponse.Success = false;
                getUserByEmailResponse.ValidationErrors = new List<string>();

                foreach (var errors in validatorResults.Errors)
                {
                    getUserByEmailResponse.ValidationErrors.Add(errors.ErrorMessage);

                }
            }

            if (getUserByEmailResponse.Success)
            {
                var userDetails = _usersRepository.GetUserByEmail(request.email);

                getUserByEmailResponse.GetUserDetailsDto = _mapper.Map<GetUserDetailsDto>(userDetails);

                return getUserByEmailResponse;

            }

            return getUserByEmailResponse;
        }
    }
}
