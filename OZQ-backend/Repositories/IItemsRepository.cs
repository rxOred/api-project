using ozq_backend.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ozq_backend.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        System.Threading.Tasks.Task UpdateItemAsync(Item item);
    }
}