using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.InMemoryCacheAdaptor;
public static class DISetup
{
    public static IServiceCollection AddInMemoryCacheService(this IServiceCollection services)
    {
        services.AddSingleton<IInMemoryCache, CacheManager>();
        return new ServiceCollection();
    }
}
