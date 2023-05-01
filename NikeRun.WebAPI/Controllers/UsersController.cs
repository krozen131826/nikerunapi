﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NikeRun.Application.Features.Users.Commands.LoginUser;
using NikeRun.Application.Features.Users.Commands.RegisterUser;
using NikeRun.Application.Features.Users.Commands.UpdateUser;
using NikeRun.Domain.Models.Response;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Application.Features.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Authorization;

namespace NikeRun.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UsersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponseModel>> LoginUser(LoginUserRequestDto request)
        {
            var result = await _mediatr.Send(new LoginUserCommand(request));

            return Ok(result);
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponseModel>> RegisterUser(RegisterUserRequestDto request)
        {
            var result = await _mediatr.Send(new RegisterUserCommand(request));

            return Ok(result);
        }

        [HttpGet("userDetails")]
        public async Task<ActionResult<BaseResponseModel>> GetUserDetails()
        {

            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            var result = await _mediatr.Send(new GetUsersByEmailQuery(email!));

            return Ok(result);
        }

        [HttpPatch("patch/update")]
        public async Task<ActionResult<BaseResponseModel>> UpdateUserDetails(JsonPatchDocument<UserUpdateRequestDto> patchDocument) 
        {

            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            var result = await _mediatr.Send(new UpdateUserCommand(email!, patchDocument));

            return Ok(result);
        }

    }

}
