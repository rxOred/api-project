using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ozq.Api.Dtos;
using Ozq.Api.Repositories;
using Ozq.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Ozq.Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return Ok(items);
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.AsDto());
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto dto)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                Count = dto.Count,
                Category = dto.Category,
                Image = dto.Image,
                Description = dto.Description
            };
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/id
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemCount(Guid id, UpdateItemDto dto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item updatedItem = existingItem with {
                Count = dto.Count
            };

            await repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }
    }
}