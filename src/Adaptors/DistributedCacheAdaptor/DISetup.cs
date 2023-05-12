using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Runtime.CompilerServices;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.DistributedCacheAdaptor;

public static class DISetup
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services,
        DistributedCacheSettings distributedCacheSettings)
    {
        var connection = ConnectionMultiplexer.Connect(distributedCacheSettings.ConnectionString);
        var _database = connection.GetDatabase();

        services.AddSingleton<IDistributedCache, DistributedCacheAdaptor>();
        services.AddSingleton<IDatabase>(_database);
        return new ServiceCollection();
    }
}