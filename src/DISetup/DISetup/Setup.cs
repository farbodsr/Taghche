using TaghcheCC.ApplicationCore.DISetup;
using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.InMemoryCacheAdaptor;
using TaghcheCC.TaghcheServiceAdaptor;
using TaghcheCC.DistributedCacheAdaptor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TaghcheCC.DISetup;
public static class Setup
{
    public static IServiceCollection AddDependencies(this IServiceCollection services,DistributedCacheSettings distributedCacheSettings)
    {
        services.AddInMemoryCacheService();
        services.AddTaghcheService();
        services.AddQuersyService();
        services.AddDistributedCache(distributedCacheSettings);

        return new ServiceCollection();
    }
}
