using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ozq_backend.Entities;

namespace ozq_backend.Repositories
{
    public interface IOrderRespository {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid id);
        System.Threading.Tasks.Task CreateOrder(Order order);
    }
}