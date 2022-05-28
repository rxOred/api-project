using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ozq_backend.Dtos;
using ozq_backend.Repositories;
using ozq_backend.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ozq_backend.Controllers
{
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
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            if (items is null)
            {
                return null;
            }
            return items;
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
            return item.AsDto();
        }

        // requires authorization to perform this action
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