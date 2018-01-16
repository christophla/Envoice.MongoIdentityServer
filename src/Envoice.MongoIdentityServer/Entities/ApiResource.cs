using Envoice.MongoRepository;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Envoice.MongoIdentityServer.Entities
{
    public class ApiResource : Entity
    {
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<ApiSecret> Secrets { get; set; }
        public List<ApiScope> Scopes { get; set; }
        public List<ApiResourceClaim> UserClaims { get; set; }
    }
}
