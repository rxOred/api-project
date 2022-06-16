using System;
using System.Threading.Tasks;
using Ozq.Api.Entities;

namespace Ozq.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        System.Threading.Tasks.Task CreateUserAsync(User user);
    }
}