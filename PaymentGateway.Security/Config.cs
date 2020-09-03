using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Security
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
           return new ApiResource[]
            {
                new ApiResource("payment-gateway", "Payment Gateway API")
            };
        }

        public static IEnumerable<IdentityResource> Ids =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId()
           };

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "merchant",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = {"payment-gateway"}
                }
            };
        }
    }
}
