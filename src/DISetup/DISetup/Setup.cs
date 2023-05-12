using TaghcheCC.ApplicationCore.DISetup;
using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.InMemoryCacheAdaptor;
using TaghcheCC.TaghcheServiceAdaptor;
using TaghcheCC.DistributedCacheAdaptor;

namespace TaghcheCC.DISetup;
public static class Setup
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddInMemoryCacheService();
        services.AddTaghcheService();
        services.AddQuersyService();
        services.AddDistributedCache();

        return new ServiceCollection();
    }
}
