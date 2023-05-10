

using ApplicationCore.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace TaghcheServiceAdaptor
{
    public static class DISetup
    {
        public static IServiceCollection AddTaghcheService(this IServiceCollection services)
        {
            services.AddSingleton<ITaghcheService, TaghcheService>();
            return new ServiceCollection();
        }
    }
}
