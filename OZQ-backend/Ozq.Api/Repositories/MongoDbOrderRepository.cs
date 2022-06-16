using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Ozq.Api.Entities;

namespace Ozq.Api.Repositories
{
    public class MongoDbOrderRepository : IOrderRespository
    {
        private const string databaseName = "ozq";
        private const string collectionName = "orders";
        private readonly IMongoCollection<Order> ordersCollection;
        private readonly FilterDefinitionBuilder<Order> filterBuilder = Builders<Order>.Filter;

        public MongoDbOrderRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);
            this.ordersCollection = database.GetCollection<Order>(collectionName);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await ordersCollection.InsertOneAsync(order);
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            var filter = filterBuilder.Eq(order => order.Id, id);
            return await ordersCollection.Find<Order>(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await ordersCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}