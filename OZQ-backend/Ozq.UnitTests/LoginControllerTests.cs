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
    public class UnitTest2
    {
        [Fact]
        public async Task Authenticate_NonExistingUser_ReturnsNull()
        {
            var repositoryStub = new Mock<IUserRepository>();
            repositoryStub.Setup(repo => repo.GetUserAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);
            
            var configStub = new Mock<IConfiguration>();
            var controller = new LoginController(repositoryStub.Object, configStub.Object);

            var result = await controller.Authenticate(new LoginUserDto());
            Assert.Null(result);
        }
    }
}