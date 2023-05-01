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
    public class CartsRepository : GenericRepository<Carts>, ICartsRepository
    {
        public CartsRepository(NikeRunDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Carts>> GetUserCartsByUserId(int userId)
        {
            return await _dbContext.Carts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<bool> IsCartItemExist(int cartId, int userId)
        {
            return await _dbContext.Carts.AnyAsync(x => x.Id == cartId && x.UserId == userId);
        }
    }
}
