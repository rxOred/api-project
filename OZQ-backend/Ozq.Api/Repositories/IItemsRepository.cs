using Ozq.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Ozq.Api.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        System.Threading.Tasks.Task UpdateItemAsync(Item item);
        System.Threading.Tasks.Task CreateItemAsync(Item item);
    }
}