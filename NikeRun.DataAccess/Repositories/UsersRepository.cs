using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.DataAccess.NikeRunDBContext;
using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Entities;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess.Repositories;
public class UsersRepository : GenericRepository<Users>, IUsersRepository
{
    private readonly ITokenProviderService _tokenService;

    public UsersRepository(NikeRunDbContext dbContext, ITokenProviderService tokenService) : base(dbContext)
    {
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> LoginUser(Users user)
    {
        var createdToken = _tokenService.GenerateToken(user);

        return new LoginResponseDto
        {
            Token =  createdToken.CreatedToken,
            RefreshToken = await _tokenService.GenerateRefreshToken(user.Id, createdToken.JwtId),
            UserName = user.UserName,
        
        };

    }

    public async Task<BaseResponseModel> RegisterAsync(Users Users, string password)
    {
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        Users.PasswordHash = passwordHash;
        Users.PasswordSalt = passwordSalt;


        await _dbContext.Users.AddAsync(Users);
        await _dbContext.SaveChangesAsync();

        return new BaseResponseModel();

    }


    public async Task<bool> isUserExist(string email)
    {
        var isUserExist = await _dbContext.Users.AnyAsync(x => x.EmailAddress == email);

        if (!isUserExist)
        {
            return false;
        }

        return isUserExist;
    }

    public async Task<Users> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.EmailAddress.ToLower().Equals(email.ToLower()));

        return user!;
    }


    //Helper Functions

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

    }

  
}

