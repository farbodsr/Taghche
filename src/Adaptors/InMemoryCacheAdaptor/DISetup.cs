﻿using ApplicationCore.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryCacheAdaptor
{
    public static class DISetup
    {
        public static IServiceCollection AddInMemoryCacheService(this IServiceCollection services)
        {
            services.AddSingleton<IInMemoryCache, CacheManager>();
            return new ServiceCollection();
        }
    }
}