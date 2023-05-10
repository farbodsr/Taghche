using Microsoft.Extensions.DependencyInjection;
using InMemoryCacheAdaptor;
using TaghcheServiceAdaptor;

namespace DISetup
{
    public static class Setup
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddInMemoryCacheService();
            services.AddTaghcheService();
            return new ServiceCollection();
        }
    }
}
