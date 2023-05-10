using ApplicationCore.QueryService;
using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.ApplicationCore.FetchPolicy;
using Microsoft.Extensions.Http;

namespace ApplicationCore.DISetup;

public static class DISetup
{
    public static IServiceCollection AddQuersyService(this IServiceCollection services)
    {
        services.AddTransient<FetchService>();
        services.AddTransient<BookQueryService>();
        services.AddHttpClient();

        return services;
    }
}

