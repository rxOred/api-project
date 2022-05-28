using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ozq_backend.Repositories;
using ozq_backend.Entities;
using ozq_backend.Dtos;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ozq_backend.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRespository repository;

        public OrdersController(IOrderRespository repository)
        {
            this.repository = repository;
        }

        // GET /orders/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            var order = await repository.GetOrderAsync(id);
            if (order is null)
            {
                return NotFound();
            }
            return order.AsDto();
        }

        private User GetUserFromToken()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var userClaims = identity.Claims;

                return new User 
                {
                    Id = new Guid(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value),
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Contact = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.MobilePhone)?.Value,
                };
            }
            return null;
        }

        // requires authorization to perform this action
        // POST /orders
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto dto)
        {
            var user = GetUserFromToken();
            if (user is null) 
            {
                return Forbid("Unauthorized users cannot perform this action");
            }
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                OrderDate = DateTimeOffset.UtcNow,
                Total = dto.Total
            };
            await repository.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.AsDto());
        }

        // requires authorization to perform this task
        // GET /user/orders
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders()
        {
            var user = GetUserFromToken();
            if (user is null)
            {
                return Forbid("Unauthorized users cannot perform this action");
            }
            var orders = (await repository.GetOrdersAsync()).Where(
                order => order.UserId == user.Id).Select(user => user.AsDto());
            return Ok(orders);
        }
    }
}