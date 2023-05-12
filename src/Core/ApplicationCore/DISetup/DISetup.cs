using TaghcheCC.ApplicationCore.QueryService;
using Microsoft.Extensions.DependencyInjection;
using TaghcheCC.ApplicationCore.FetchPolicy;

namespace TaghcheCC.ApplicationCore.DISetup;

public static class DISetup
{
    public static IServiceCollection AddQuersyService(this IServiceCollection services)
    {
        services.AddTransient<BookFetchService>();
        services.AddTransient<IBookQueryService,BookQueryService>();
        services.AddHttpClient();

        return services;
    }
}

