using Microsoft.EntityFrameworkCore;
using NikeRun.Application.Contracts.Entities;
using NikeRun.DataAccess.NikeRunDBContext;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {

        public ProductsRepository(NikeRunDbContext dbContext): base(dbContext)
        {
        }

        public async Task<List<Products>> GetProductsWithImageAndDetails()
        {
            var products = await _dbContext.Products.Include(x => x.Image).Include(p => p.ProductDetails).ToListAsync();

            return products;
        }

        public async Task<bool> isProductExist(int productId)
        {
            var isProductExist = await _dbContext.Products.AnyAsync(x => x.Id == productId);

            if (!isProductExist)
            {
                return false;
            }

            return isProductExist;
        }
    }
}
