using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ozq_backend.Dtos;
using ozq_backend.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ozq_backend.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository repository;
        private IConfiguration config;

        public LoginController(IUserRepository repository, IConfiguration config)
        {
            this.repository = repository;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginUserDto dto)
        {
            var user = await Authenticate(dto);
            if (user is null)
            {
                return NotFound("User not found");
            }
            var token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(Entities.User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Contact)
            };

            var token = new JwtSecurityToken
            (
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(40),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<Entities.User> Authenticate(LoginUserDto dto)
        {
            var user = await repository.GetUserAsync(dto.Username);
            if (user != null && user.Password == dto.Password)
            {
                return user;
            }
            return null;
        }
    }
}
