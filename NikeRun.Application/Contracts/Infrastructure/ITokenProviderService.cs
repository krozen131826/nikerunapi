using NikeRun.Application.Contracts.Entities;
using NikeRun.Domain.Entities;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Contracts.Infrastructure
{
    public interface ITokenProviderService : IGenericRepository<RefreshTokens>
    {
        CreateTokenModel GenerateToken(Users user);
        Task<string> GenerateRefreshToken(int id, string jwtId);
    }
}
