namespace Envoice.MongoIdentityServer
{
    public class Constants
    {
        public class TableNames
        {
            // Configuration
            public const string IdentityClaim = "IdentityClaims";
            public const string IdentityResource = "IdentityResources";

            public const string ApiClaim = "ApiClaims";
            public const string ApiResource = "ApiResources";
            public const string ApiScope = "ApiScopes";
            public const string ApiScopeClaim = "ApiScopeClaims";
            public const string ApiSecret = "ApiSecrets";

            public const string Client = "Clients";
            public const string ClientClaim = "ClientClaims";
            public const string ClientCorsOrigin = "ClientCorsOrigins";
            public const string ClientGrantType = "ClientGrantTypes";
            public const string ClientIdPRestriction = "ClientIdPRestrictions";
            public const string ClientPostLogoutRedirectUri = "ClientPostLogoutRedirectUris";
            public const string ClientRedirectUri = "ClientRedirectUris";
            public const string ClientScopes = "ClientScopes";
            public const string ClientSecret = "ClientSecrets";

            // Operational
            public const string PersistedGrant = "PersistedGrants";
        }
    }
}
