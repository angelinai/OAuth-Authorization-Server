using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace BB.DigitalMirror.OAuth.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        /// <summary>
        /// Set up Api Resources
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("luxgoods", "Luxury Goods"),
                new ApiResource
                {
                    Name = "customAPI",
                    DisplayName = "Custom API",
                    Description = "Custom API Access",
                    UserClaims = new List<string> {"role"},
                    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                    Scopes = new List<Scope>
                    {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }

        /// <summary>
        /// Set up clients
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> Clients()
        {
            //TODO: replace this area with value from a Key/Secret Vault
            //var clientSecret = "secret";
            return new[]
            {
                    new Client {
                        ClientId = "oauthClient",
                        ClientName = "Example Client Credentials Client Application",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = new List<Secret> {
                            new Secret("superSecretPassword".Sha256())},
                        AllowedScopes = new List<string> {"customAPI.read"}
                    },
                    new Client
                        {
                            ClientId = "luxgoods",
                            ClientSecrets = new List<Secret>
                            {
                                new Secret("superSecretPassword".Sha256())
                            },
                            // Select a grant flow - client credentials, hybrid, resource owner password, token
                            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                            AllowedScopes = new List<string>()
                            {
                                "luxgoods"
                            }
                        }
            };
        }

        /// <summary>
        /// Setup users
        /// </summary>
        /// <returns></returns>
        public static IList<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                  new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "angelina",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email,
                            "tester1@mailinator.com"),
                        new Claim(JwtClaimTypes.Role,
                            "admin")
                    }
                }
            };
        }
    }
}