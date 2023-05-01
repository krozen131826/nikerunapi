using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeRun.Application.Features.Products.Queries.GetProductList;
using NikeRun.Domain.Models.Response;

namespace NikeRun.WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("list")]
        public async Task<ActionResult<BaseResponseModel>> GetProductList()
        {
            var productListDto = await _mediatr.Send(new GetProductListQuery());

            return Ok(productListDto);
        }
    }
}
