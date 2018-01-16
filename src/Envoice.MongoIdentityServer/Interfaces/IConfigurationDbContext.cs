using Envoice.MongoIdentityServer.Entities;
using Envoice.MongoRepository;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Envoice.MongoIdentityServer.Interfaces
{
    public interface IConfigurationDbContext : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<IdentityResource> IdentityResources { get; }
        IRepository<ApiResource> ApiResources { get; }

        Task AddClient(Client entity);

        Task AddIdentityResource(IdentityResource entity);

        Task AddApiResource(ApiResource entity);
    }
}
