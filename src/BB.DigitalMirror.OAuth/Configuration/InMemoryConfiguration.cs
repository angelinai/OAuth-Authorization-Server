using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace BB.DigitalMirror.OAuth.Configuration
{
    public class InMemoryConfiguration
    { 
        /// <summary>
        /// Setup users
        /// </summary>
        /// <returns></returns>
        public static IList<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                  new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "Claire",
                    Password = "password",

                    Claims = new List<Claim> {
                        //  claire underwood
                        new Claim(JwtClaimTypes.Email, "cUnderwood@wtehouse.gov"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim("given_name", "Claire"),
                        new Claim("family_name", "Underwood")
                    }
                },
                    new TestUser {
                    SubjectId = "7BC22B93-8591-41F5-9F42-56187FE15A2A",
                    Username = "Frank",
                    Password = "password",

                    Claims = new List<Claim> {
                        //  claire underwood
                        new Claim(JwtClaimTypes.Email, "fUnderwood@wtehouse.gov"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Underwood")
                    }
                }
            };
        }

       /// <summary>
       /// Define which identity related scopes we'll be supported
       /// </summary>
       /// <returns>
       ///  Returns supported identity related scopes
       /// </returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var identityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(), // required for OpenID Connect, returns subject   
                new IdentityResources.Profile(), // includes given name, family names
                new IdentityResources.Email() 
            };

            return identityResources;
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>();
        }
    }
}