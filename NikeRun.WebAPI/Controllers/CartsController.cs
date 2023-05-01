using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NikeRun.Application.Features.Carts.Commands.AddToCart;
using NikeRun.Application.Features.Carts.Commands.UpdateCartQuantity;
using NikeRun.Application.Features.Carts.Queries;
using NikeRun.Domain.Dtos.Carts;
using NikeRun.Domain.Entities;
using NikeRun.Domain.Models.Response;

namespace NikeRun.WebAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/cartList")]
        public async Task<ActionResult<List<CartDto>>> GetUserCart()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);

            var cartList = await _mediator.Send(new GetUserCartListQuery(email!, userId));

            return Ok(cartList);
        }

        [HttpPost("addToCart")]
        public async Task<ActionResult<BaseResponseModel>> AddToCart(AddToCartDto cart)
        {

            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);

            cart.UserId = userId;

            var results = await _mediator.Send(new AddToCartCommand(email!,cart));

            return Ok(results);
        }

        [HttpPatch("update/{cartId}")]
        public async Task<ActionResult<BaseResponseModel>> UserCartQuantityUpdate(int cartId,JsonPatchDocument<UpdateCartDto> patchDocument)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);

            var results = await _mediator.Send(new UserCartQuantityUpdateCommand(cartId, userId!, patchDocument));

            return Ok(results);
        }
    }
}
