using Microsoft.AspNetCore.Mvc;
using Moq;
using Ozq.Api.Controllers;
using Ozq.Api.Dtos;
using Ozq.Api.Entities;
using Ozq.Api.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ozq.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetItemAsync_NonExistingItem_ReturnNotFound()
        {
            var repositoryStub = new Mock<IItemsRepository>();
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);

            var controller = new ItemsController(repositoryStub.Object);

            var result = await controller.GetItem(new Guid());

            Assert.IsType<NotFoundResult>(result.Result);
        }
        
        [Fact]
        public async Task GetTaskAsync_ExistingItem_ReturnsItem()
        {
            var repositoryStub = new Mock<IItemsRepository>();
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)GenerateRandomItem());

            var controller = new ItemsController(repositoryStub.Object);

            var result = await controller.GetItem(new Guid());

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreateItemAsync_NewItem_ReturnsNewItem()
        {
            var itemDto = new CreateItemDto()
            {
                Price = 100,
                Count = 100,
                Category = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Image = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };

            var repositoryStub = new Mock<IItemsRepository>();
            var controller = new ItemsController(repositoryStub.Object);
            var result = await controller.CreateItem(itemDto);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            var dto = (result.Result as CreatedAtActionResult).Value as ItemDto;
            Assert.Equal(itemDto.Category, dto.Category);
            Assert.Equal(itemDto.Count, dto.Count);
            Assert.Equal(itemDto.Price, dto.Price);
            Assert.Equal(itemDto.Name, dto.Name);
            Assert.Equal(itemDto.Description, dto.Description);
            Assert.Equal(itemDto.Image, dto.Image);
        }

        private Item GenerateRandomItem()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Price = 100,
                Count = 100,
                Category = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Image = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };
        }
    }
}