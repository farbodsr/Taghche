using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.ApplicationCore.Ports;

namespace TaghcheCC.TaghcheServiceAdaptor;
public static class DISetup
{
    public static IServiceCollection AddTaghcheService(this IServiceCollection services)
    {
        services.AddSingleton<ITaghcheService, TaghcheService>();
        return new ServiceCollection();
    }
}
