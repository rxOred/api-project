using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Ozq.Api.Repositories;
using Ozq.Api.Entities;
using Ozq.Api.Dtos;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Ozq.Api.Controllers
{
    //[EnableCors]
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRespository repository;

        public OrdersController(IOrderRespository repository)
        {
            this.repository = repository;
        }

        // GET /orders
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = (await repository.GetOrdersAsync()).Select(order => order.AsDto());
            return orders;
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
            return Ok(order.AsDto());
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

        // POST /orders
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto dto)
        {
            var user = GetUserFromToken();
            if (user is null) 
            {
                return Unauthorized("Unauthorized users cannot perform this action");
            }
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                OrderDate = DateTimeOffset.UtcNow,
                Total = dto.Total
            };
            await repository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.AsDto());
        }

        // GET /orders/user
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders()
        {
            var user = GetUserFromToken();
            if (user is null)
            {
                return Unauthorized("Unauthorized users cannot perform this action");
            }
            var orders = (await repository.GetOrdersAsync()).Where(
                order => order.UserId == user.Id).Select(user => user.AsDto());
            return Ok(orders);
        }
    }
}