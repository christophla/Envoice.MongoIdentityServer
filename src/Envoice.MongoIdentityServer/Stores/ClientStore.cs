using Envoice.MongoIdentityServer.Interfaces;
using Envoice.MongoIdentityServer.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Envoice.MongoIdentityServer.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IConfigurationDbContext _context;
        private readonly ILogger<ClientStore> _logger;

        public ClientStore(IConfigurationDbContext context, ILogger<ClientStore> logger)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _logger = logger;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _context.Clients.FirstOrDefault(x => x.ClientId == clientId);
            // var client = await _context.Clients.GetByIdAsync(clientId);
            var model = client?.ToModel();

            _logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

            return Task.FromResult(model);
        }
    }
}


