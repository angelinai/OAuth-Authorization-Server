using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace BB.DigitalMirror.OAuth.Configuration
{
    public class InMemoryConfiguration
    {
        /// <summary>
        /// Set up Api Resources
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("luxgoods", "Luxury Goods")
            };
        }

        /// <summary>
        /// Set up clients
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> Clients()
        {
            //TODO: replace this area with value from a Key/Secret Vault
            var clientSecret = "secret";
            return new[]
            {
                new Client
                {
                    ClientId = "luxgoods",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(clientSecret.Sha256())
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
        public static IEnumerable<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "tester@borsetta.io",
                    Password = "password"
                }
            };
        } 
    }
}
