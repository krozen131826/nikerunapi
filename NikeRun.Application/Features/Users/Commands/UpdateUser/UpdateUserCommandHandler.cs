using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Exception;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUserByEmail(request.emailAddress);

            var updateUserCommandResponse = new UpdateUserCommandResponse();

            var validator = new UpdateUserCommandValidator(_userRepository);

            var validationResults = await validator.ValidateAsync(request);

            if (validationResults.Errors.Count() > 0)
            {

                throw new ValidationErrorsException(validationResults);
              
                //updateUserCommandResponse.Success = false;
                //updateUserCommandResponse.ValidationErrors = new List<string>();

                //foreach (var errors in validationResults.Errors)
                //{
                //    updateUserCommandResponse.ValidationErrors.Add(errors.ErrorMessage);
                //}
            }

            if (updateUserCommandResponse.Success)
            {


                var mappedUser = _mapper.Map<UserUpdateRequestDto>(user);

                request.patchDocument.ApplyTo(mappedUser);


                var userToUpdate = _mapper.Map(mappedUser, user);

                updateUserCommandResponse.Message = "Update Successfull"; 

                await _userRepository.UpdateAsync(userToUpdate);
            }

            return updateUserCommandResponse;


        }
    }
}
