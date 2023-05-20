using NikeRun.Domain.Dtos.Users;
using NikeRun.Domain.Entities;
using NikeRun.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Contracts.Entities
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<BaseResponseModel<string>> RegisterAsync(Users Users, string password);
        Task<LoginResponseDto> LoginUser(Users user);
        Task<bool> isUserExist(string email);
        Task<Users> GetUserByEmail(string email);

    }
}
