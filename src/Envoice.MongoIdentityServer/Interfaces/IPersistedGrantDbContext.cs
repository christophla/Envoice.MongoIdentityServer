using Envoice.MongoIdentityServer.Entities;
using Envoice.MongoRepository;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Envoice.MongoIdentityServer.Interfaces
{
    public interface IPersistedGrantDbContext : IDisposable
    {
        IRepository<PersistedGrant> PersistedGrants { get; }

        Task Add(PersistedGrant entity);

        Task Update(Expression<Func<PersistedGrant, bool>> filter, PersistedGrant entity);

        Task Remove(Expression<Func<PersistedGrant, bool>> filter);

        Task RemoveExpired();
    }
}
