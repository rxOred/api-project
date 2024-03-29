﻿using Ozq.Api.Dtos;
using Ozq.Api.Entities;

namespace Ozq.Api
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Count = item.Count,
                Price = item.Price,
                Image = item.Image,
                Description = item.Description
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static OrderDto AsDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Total = order.Total
            };
        }
    }
}