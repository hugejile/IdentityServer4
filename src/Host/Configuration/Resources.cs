// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Host.Configuration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),

                // custom identity resource with some consolidated claims
                new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, "location" })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                // simple version with ctor
                new ApiResource("verifycode", "房源核验")
                {
                    // this is needed for introspection when using reference tokens
                    ApiSecrets = { new Secret("secret".Sha256()) },

                    Scopes =
                    {
                        new Scope
                        {
                            Name = "verifycode.check",
                            DisplayName = "房源核验确定"
                        }
                    }
                },
                
                // expanded version if more control is needed
                new ApiResource
                {
                    Name = "contract",
                    DisplayName = "合同查询",

                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    },

                    Scopes =
                    {
                        new Scope
                        {
                            Name = "contract.check",
                            DisplayName = "合同查询"
                        },
                        new Scope
                        {
                            Name = "contract.bind",
                            DisplayName = "合同绑定"
                        },
                        new Scope
                        {
                            Name = "contract.send",
                            ShowInDiscoveryDocument = false,
                            UserClaims =
                            {
                                "contract_no"
                            }
                        }
                    }
                }
            };
        }
    }
}