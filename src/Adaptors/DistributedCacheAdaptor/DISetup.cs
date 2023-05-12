using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.DistributedCacheAdaptor;

public static class DISetup
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services)
    {
        services.AddSingleton<IDistributedCache, DistributedCacheAdaptor>();
        return new ServiceCollection();
    }
}