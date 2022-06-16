using Ozq.Api.Dtos;
using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Ozq.Api.Repositories;
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
        }
    }
}