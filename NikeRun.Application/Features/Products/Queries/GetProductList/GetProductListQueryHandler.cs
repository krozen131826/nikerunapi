using AutoMapper;
using MediatR;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Products.Queries.GetProductList
{
    internal sealed class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, GetProductListQueryResponse>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductListQueryResponse> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var getProductListQueryResponse = new GetProductListQueryResponse();

            getProductListQueryResponse.ProductList = _mapper.Map<List<ProductsDto>>(await _productRepository.GetProductsWithImageAndDetails());

            return getProductListQueryResponse;

        }

    }
}
