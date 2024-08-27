// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace EShopper.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]  
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                   };

        //kimlere hangi yetkiyi vereceğimiz, resourselar ile belirlenir
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission", "catalog_readpermission"}}, // resource_catalog resource'una sahip olan Catalog servisi catalog_fullpermission ve catalog_readpermission yetkilerine yani scoplerına sahip. her mikroservisin belli yetkileri vardır. burası gidip discounta işlem yapamaz mesela bunu sağlayan sistem ıdentityserverdır. 
            new ApiResource("resource_discount"){Scopes={"discount_fullpermission"}},
            new ApiResource("resource_order"){Scopes={"order_fullpermission"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
            new ApiResource( IdentityServerConstants.LocalApi.ScopeName),
           
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Full Permission for catalog operations"),  //katalog operasyonları için tam yetki scope'u
                new ApiScope("catalog_readpermission","Reading Permission for catalog service"),  //katalog servisleri için sadece okuma yetki scope'u
                new ApiScope("discount_fullpermission","Full Permission for discount operations"),
                new ApiScope("order_fullpermission","Full Permission for order operations"),
                new ApiScope("basket_fullpermission","Full Permission for basket operations"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
               
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
               new Client
               {
                   ClientId="EShopperAdminClient",  //admin
                   ClientName="EShopper Admin User",
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,  //admin kullanıcısının grand type'ı
                   AllowedScopes={ "catalog_fullpermission", "basket_fullpermission", "discount_fullpermission", "order_fullpermission", 
                       IdentityServerConstants.LocalApi.ScopeName,
                       IdentityServerConstants.StandardScopes.Email,
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                   },
                   AccessTokenLifetime=600
                   //admin kullanısının erişebileceği scopelar, her bir yeni mikroserviste scopları buraya eklemeliyiz.
               },

               new Client
               {
                    ClientId="EShopperVisitorClient",  //ziyaretçi
                    ClientName="EShopper Visitor User",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,  //herhangi bir kullanıcı adı şifresi olmayan ziyaretçiler için 
                    AllowedScopes={ "catalog_readpermission", IdentityServerConstants.LocalApi.ScopeName }  //Sadece anasayfadaki catalog içindeki değerleri görebilir.
               }
            };
    }
}