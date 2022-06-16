using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Ozq.Api.Dtos;
using Ozq.Api.Entities;
using Ozq.Api.Repositories;

namespace Ozq.Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("register")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository repository;

        public RegisterController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(CreateUserDto dto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                Contact = dto.Contact,
                Password = dto.Password
            };
            await repository.CreateUserAsync(user);
            return Ok("User registered succesfully");
        }
    }
}