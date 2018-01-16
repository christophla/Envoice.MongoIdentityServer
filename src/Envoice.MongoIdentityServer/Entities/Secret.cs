﻿using System;
using static IdentityServer4.IdentityServerConstants;

namespace Envoice.MongoIdentityServer.Entities
{
    public abstract class Secret
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } = SecretTypes.SharedSecret;
    }
}
