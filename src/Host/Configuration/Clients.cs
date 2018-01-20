// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Host.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "10001",
                    ClientName = "58同城",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "verifycode.check" },
                    RequireConsent = false,
                },
                new Client
                {
                    ClientId = "10002",
                    ClientName = "建行",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "verifycode.check" },
                    RequireConsent = false,
                },

                new Client
                {
                    ClientId = "10000",
                    ClientName = "后房时代",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:44077/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:44077/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "contract.check",
                        "contract.bind",
                        "contract.send",
                        "verifycode.check",
                    },
                    AllowOfflineAccess = true,
                    RequireConsent = false,
                }
            };
        }
    }
}