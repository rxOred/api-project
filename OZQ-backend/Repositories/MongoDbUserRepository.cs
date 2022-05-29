using MongoDB.Driver;
using ozq_backend.Entities;
using System;
using System.Threading.Tasks;

namespace ozq_backend.Repositories
{
    public class MongoDbUserRepository : IUserRepository
    {
        private const string databaseName = "ozq";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> userCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        public MongoDbUserRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);
            this.userCollection = database.GetCollection<User>(collectionName);
        }
        public async Task CreateUserAsync(User user)
        {
            await userCollection.InsertOneAsync(user);
        }

        public async Task<User> GetUserAsync(string username)
        {
            var filter = filterBuilder.Eq(user => user.Username, username);
            return await userCollection.Find<User>(filter).SingleOrDefaultAsync();
        }
    }
}