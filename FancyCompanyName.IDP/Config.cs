// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace FancyCompanyName.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("rmdbapi", "RMDB Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            { 

                // MVC client using hybrid flow
                new Client
                {
                    ClientId = "rmdbwebclient",
                    ClientName = "RMDB Web Client",

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("2E51842C-56EF-481A-938C-A0C4BF648215".Sha256()) },

                    RedirectUris = { "https://localhost:44321/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44321/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44321/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "rmdbapi" }
                } 
            };
        }
    }
}