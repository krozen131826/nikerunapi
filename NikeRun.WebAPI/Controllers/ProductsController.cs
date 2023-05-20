using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeRun.Application.Features.Products.Queries.GetProductList;
using NikeRun.Domain.Models.Response;

namespace NikeRun.WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("list")]
        public async Task<ActionResult<BaseResponseModel<string>>> GetProductList()
        {
            var productListDto = await _mediatr.Send(new GetProductListQuery());

            return Ok(productListDto);
        }
    }
}
