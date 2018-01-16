using Envoice.MongoIdentityServer.Configuration;
using Envoice.MongoRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Envoice.MongoIdentityServer.DbContexts
{
    public class MongoDBContextBase : IDisposable
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;
        private readonly MongoRepositoryConfig _config;

        public MongoDBContextBase(IOptions<MongoDBConfiguration> settings)
        {
            if (settings.Value == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration cannot be null.");

            if (settings.Value.ConnectionString == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration.ConnectionString cannot be null.");

            if (settings.Value.Database == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration.Database cannot be null.");

            _client = new MongoClient(settings.Value.ConnectionString);
            _config = new MongoRepositoryConfig(settings.Value.ConnectionString);
            _database = _client.GetDatabase(settings.Value.Database);
        }

        protected IMongoDatabase Database { get { return _database; } }

        protected MongoRepositoryConfig Config {get{return _config;}}

        public void Dispose()
        {
            // TODO
        }
    }
}
