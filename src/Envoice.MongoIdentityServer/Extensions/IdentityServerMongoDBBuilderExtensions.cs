﻿using Envoice.MongoIdentityServer.Configuration;
using Envoice.MongoIdentityServer.DbContexts;
using Envoice.MongoIdentityServer.Interfaces;
using Envoice.MongoIdentityServer.Options;
using Envoice.MongoIdentityServer.Services;
using Envoice.MongoIdentityServer.Stores;
using Envoice.MongoIdentityServer;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerMongoDBBuilderExtensions
    {
        public static IIdentityServerBuilder AddConfigurationStore(
           this IIdentityServerBuilder builder, Action<MongoDBConfiguration> setupAction)
        {
            builder.Services.Configure(setupAction);

            return builder.AddConfigurationStore();
        }

        public static IIdentityServerBuilder AddConfigurationStore(
            this IIdentityServerBuilder builder, IConfiguration configuration)
        {
            builder.Services.Configure<MongoDBConfiguration>(configuration);

            return builder.AddConfigurationStore();
        }

        public static IIdentityServerBuilder AddOperationalStore(
           this IIdentityServerBuilder builder,
           Action<MongoDBConfiguration> setupAction,
           Action<TokenCleanupOptions> tokenCleanUpOptions = null)
        {
            builder.Services.Configure(setupAction);

            return builder.AddOperationalStore(tokenCleanUpOptions);
        }

        public static IIdentityServerBuilder AddOperationalStore(
            this IIdentityServerBuilder builder,
            IConfiguration configuration,
            Action<TokenCleanupOptions> tokenCleanUpOptions = null)
        {
            builder.Services.Configure<MongoDBConfiguration>(configuration);

            return builder.AddOperationalStore(tokenCleanUpOptions);
        }

        private static IIdentityServerBuilder AddConfigurationStore(
            this IIdentityServerBuilder builder)
        {
            builder.Services.AddScoped<IConfigurationDbContext, ConfigurationDbContext>();

            builder.Services.AddTransient<IClientStore, ClientStore>();
            builder.Services.AddTransient<IResourceStore, ResourceStore>();
            builder.Services.AddTransient<ICorsPolicyService, CorsPolicyService>();

            return builder;
        }

        private static IIdentityServerBuilder AddOperationalStore(
            this IIdentityServerBuilder builder,
            Action<TokenCleanupOptions> tokenCleanUpOptions = null)
        {
            builder.Services.AddScoped<IPersistedGrantDbContext, PersistedGrantDbContext>();

            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            var tokenCleanupOptions = new TokenCleanupOptions();
            tokenCleanUpOptions?.Invoke(tokenCleanupOptions);
            builder.Services.AddSingleton(tokenCleanupOptions);
            builder.Services.AddSingleton<TokenCleanup>();

            return builder;
        }

        public static IApplicationBuilder UseIdentityServerMongoDBTokenCleanup(this IApplicationBuilder app, IApplicationLifetime applicationLifetime)
        {
            var tokenCleanup = app.ApplicationServices.GetService<TokenCleanup>();
            if (tokenCleanup == null)
            {
                throw new InvalidOperationException("AddOperationalStore must be called on the service collection.");
            }
            applicationLifetime.ApplicationStarted.Register(tokenCleanup.Start);
            applicationLifetime.ApplicationStopping.Register(tokenCleanup.Stop);

            return app;
        }
    }
}
