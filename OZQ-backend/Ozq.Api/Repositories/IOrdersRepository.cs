using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ozq.Api.Entities;

namespace Ozq.Api.Repositories
{
    public interface IOrderRespository {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid id);
        System.Threading.Tasks.Task CreateOrderAsync(Order order);
    }
}