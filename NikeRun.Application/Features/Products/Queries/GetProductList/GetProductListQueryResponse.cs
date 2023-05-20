using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Products.Queries.GetProductList;
public class GetProductListQueryResponse : BaseResponseModel<ProductsDto>
{
    public GetProductListQueryResponse() : base()
    {
        
    }

    public List<ProductsDto> ProductList { get; set; } = new List<ProductsDto>();
}

