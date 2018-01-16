using Envoice.MongoIdentityServer.Configuration;
using Envoice.MongoIdentityServer.Entities;
using Envoice.MongoIdentityServer.Interfaces;
using Envoice.MongoRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Envoice.MongoIdentityServer.DbContexts
{
    public class PersistedGrantDbContext : MongoDBContextBase, IPersistedGrantDbContext
    {
        private IRepository<PersistedGrant> _persistedGrants;

        public PersistedGrantDbContext(IOptions<MongoDBConfiguration> settings)
            : base(settings)
        {
            _persistedGrants = new MongoRepository<PersistedGrant>(Config);
        }

        public IRepository<PersistedGrant> PersistedGrants
        {
            get { return _persistedGrants; }
        }

        public async Task Update(Expression<Func<PersistedGrant, bool>> filter, PersistedGrant entity)
        {
            //await _persistedGrants.UpdateAsync(filter, entity);
            await _persistedGrants.Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task Add(PersistedGrant entity)
        {
            await _persistedGrants.AddAsync(entity);
        }

        public async Task Remove(Expression<Func<PersistedGrant, bool>> filter)
        {
            await _persistedGrants.DeleteAsync(filter);
        }

        public async Task RemoveExpired()
        {
            await Remove(x => x.Expiration < DateTime.UtcNow);
        }
    }
}
