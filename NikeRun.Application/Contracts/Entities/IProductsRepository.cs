using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Contracts.Entities
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        Task<List<Products>> GetProductsWithImageAndDetails();

        Task<bool> isProductExist(int productId);
    }
}
