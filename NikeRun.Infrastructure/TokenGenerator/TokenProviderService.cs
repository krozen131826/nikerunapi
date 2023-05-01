using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.DataAccess.NikeRunDBContext;
using NikeRun.DataAccess.Repositories;
using NikeRun.Domain.Entities;
using NikeRun.Domain.Models.Response;
using NikeRun.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Infrastructure.TokenGenerator
{
    public class TokenProviderService : GenericRepository<RefreshTokens>, ITokenProviderService
    {
        private readonly IConfiguration _config;

        public TokenProviderService(NikeRunDbContext dbContext, IConfiguration config): base(dbContext)
        {
            _config = config;
        }

        public CreateTokenModel GenerateToken(Users user)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("SecretKey:Key").Value));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
              
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.EmailAddress),
                    new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                }),
                
                Expires = DateTime.Now.ToLocalTime().AddMinutes(10),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

            };

            var jwt =  jwtTokenHandler.CreateToken(tokenDescriptor);


            return new CreateTokenModel()
            {
                CreatedToken = jwtTokenHandler.WriteToken(jwt),
                JwtId = jwt.Id.ToString(),
            };

        }

        public async Task<string> GenerateRefreshToken(int id, string jwtId)
        {

            var refreshToken = new RefreshTokens()
            {
                UserId = id,
                JwtId = jwtId,
                RefToken = GenerateRandomString(25),
                CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")),
                ExpiryDate = Convert.ToDateTime(DateTime.Now.AddDays(7).ToString("MM/dd/yyyy hh:mm tt")),
                IsRevoked = false,
                IsUsed = false,

            };

            await _dbContext.RefreshToken.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();

            return refreshToken.RefToken;

        }

        private string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

    }
}
