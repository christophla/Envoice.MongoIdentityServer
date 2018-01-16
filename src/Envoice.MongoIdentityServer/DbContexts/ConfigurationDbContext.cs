using Envoice.MongoIdentityServer.Configuration;
using Envoice.MongoIdentityServer.Entities;
using Envoice.MongoIdentityServer.Interfaces;
using Envoice.MongoRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Envoice.MongoIdentityServer.DbContexts
{
    public class ConfigurationDbContext : MongoDBContextBase, IConfigurationDbContext
    {
        private IRepository<Client> _clients;
        private IRepository<IdentityResource> _identityResources;
        private IRepository<ApiResource> _apiResources;

        public ConfigurationDbContext(IOptions<MongoDBConfiguration> settings)
            : base(settings)
        {
            _clients = new MongoRepository<Client>(Config);
            _identityResources = new MongoRepository<IdentityResource>(Config);
            _apiResources = new MongoRepository<ApiResource>(Config);
        }

        public IRepository<Client> Clients
        {
            get { return _clients; }
        }
        public IRepository<IdentityResource> IdentityResources
        {
            get { return _identityResources; }
        }

        public IRepository<ApiResource> ApiResources
        {
            get { return _apiResources;}
        }

        public async Task AddClient(Client entity)
        {
            await _clients.AddAsync(entity);
        }

        public async Task AddIdentityResource(IdentityResource entity)
        {
            await _identityResources.AddAsync(entity);
        }

        public async Task AddApiResource(ApiResource entity)
        {
            await _apiResources.AddAsync(entity);
        }

    }
}
