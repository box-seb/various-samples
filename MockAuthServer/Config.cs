using Duende.IdentityServer.Models;

namespace MockNexusAuthServer;

public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
            {
                new ApiScope("payment:read"),
                new ApiScope("payment:manage"),
                new ApiScope("community:read"),
                new ApiScope("community:manage")
            };

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("https://publicapiadapter.localhost.rktsvc.com")
            {
                Scopes = ApiScopes.Select(x => x.Name).ToArray(),
            }
        };

    public static IEnumerable<Client> Clients => new Client[] 
            {
                new Client()
                {
                    ClientId = "nexus",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("K7gNU3sdo\u002BOL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=")
                    },
                    AllowedScopes = ApiScopes.Where(x => x.Name != "payment:manage").Select(x => x.Name).ToArray(),
                    AccessTokenLifetime = 3600 * 10, // 10 hours
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    Enabled = true,
                    AlwaysSendClientClaims = true,
                    ClientClaimsPrefix = "",
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim("azp", "public-api-client-id-spike"),
                        new ClientClaim("https://auth-server.com/claims/tokenAccessType", "public_api_client_access"),
                    }
                },
                new Client()
                {
                    ClientId = "caldera",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("K7gNU3sdo\u002BOL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=")
                    },
                    AllowedScopes = ApiScopes.Select(x => x.Name).ToArray(),
                    AccessTokenLifetime = 3600 * 10, // 10 hours
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    Enabled = true,
                }
            };
}