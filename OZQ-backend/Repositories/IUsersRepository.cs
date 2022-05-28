using System;
using System.Threading.Tasks;
using ozq_backend.Entities;

namespace ozq_backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        System.Threading.Tasks.Task CreateUserAsync(User user);
    }
}