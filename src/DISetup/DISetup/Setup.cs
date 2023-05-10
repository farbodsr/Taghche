using ApplicationCore.DISetup;
using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.InMemoryCacheAdaptor;
using TaghcheCC.TaghcheServiceAdaptor;

namespace TaghcheCC.DISetup;
public static class Setup
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddInMemoryCacheService();
        services.AddTaghcheService();
        services.AddQuersyService();

        return new ServiceCollection();
    }
}
