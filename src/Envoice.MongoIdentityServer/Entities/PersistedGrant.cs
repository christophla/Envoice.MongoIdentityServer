using MongoDB.Bson;
using System;
using Envoice.MongoRepository;

namespace Envoice.MongoIdentityServer.Entities
{
    public class PersistedGrant : Entity
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string ClientId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public string Data { get; set; }
    }
}
