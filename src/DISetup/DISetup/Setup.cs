using Microsoft.Extensions.DependencyInjection;
using InMemoryCacheAdaptor.DISetup;

namespace DISetup
{
    public static class Setup
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddInMemoryCacheService();
            return new ServiceCollection();
        }
    }
}
