using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Features.Products.Queries.GetProductList
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<Images> Image { get; set; } = new List<Images>();
        public List<ProductDetails> ProductDetails { get; set; } = new List<ProductDetails>();
    }
}
