using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Ozq.Api.Repositories;
using Ozq.Api.Entities;
using Ozq.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ozq.UnitTests
{
    public class UnitTest4
    {
        [Fact]
        public async Task GetOrder_NonExistingOrder_ReturnsNotFound()
        {
            var repositoryStub = new Mock<IOrderRespository>();
            repositoryStub.Setup(repo => repo.GetOrderAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Order)null);
            var controller = new OrdersController(repositoryStub.Object);

            var result = await controller.GetOrder(new Guid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetOrder_ExistingOrder_ReturnOrder()
        {
            var repositoryStub = new Mock<IOrderRespository>();
            repositoryStub.Setup(repo => repo.GetOrderAsync(It.IsAny<Guid>()))
                .ReturnsAsync(GenerateRandomOrder());
            var controller = new OrdersController(repositoryStub.Object);

            var result = await controller.GetOrder(new Guid());

            Assert.IsType<OkObjectResult>(result.Result);
        }

        private Order GenerateRandomOrder()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Total = 1000,
                OrderDate = DateTime.UtcNow
            };
        }
    }
}