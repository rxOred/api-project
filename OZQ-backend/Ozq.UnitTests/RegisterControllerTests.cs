using Ozq.Api.Dtos;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Ozq.Api.Repositories;
using Ozq.Api.Entities;
using Ozq.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ozq.UnitTests
{
    public class UnitTest3
    {
        [Fact]
        public async Task Register_NonExistingUser_ReturnsNull()
        {
            var userDto = new CreateUserDto()
            {
                Contact = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            };

            var repositoryStub = new Mock<IUserRepository>();
            var controller = new RegisterController(repositoryStub.Object);

            var result = await controller.Register(userDto);
            Assert.IsType<OkObjectResult>(result.Result);
            var dto = (result.Result as CreatedAtActionResult).Value as UserDto;
            Assert.Equal(userDto.Contact, dto.Contact);
            Assert.Equal(userDto.Count, dto.Count);
            Assert.Equal(userDto.Price, dto.Price);
            Assert.Equal(userDto.Name, dto.Name);
        }
    }
}