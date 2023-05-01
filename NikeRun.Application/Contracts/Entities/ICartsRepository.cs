using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Contracts.Entities
{
    public interface ICartsRepository : IGenericRepository<Carts>
    {
        Task<List<Carts>> GetUserCartsByUserId(int userId);

        Task<bool>IsCartItemExist(int cartId, int userId);
    }
}
