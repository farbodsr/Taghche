using Host.Middlewares;
using TaghcheCC.ApplicationCore.Exceptions;
using TaghcheCC.DISetup;
using TaghcheCC.DistributedCacheAdaptor;
using TaghcheServiceAdaptor;

namespace TaghcheCC.Host;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        AddConfigurations(builder);
        builder.Services.AddDependencies();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseExceptionHandlerMiddleware();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

        #region LocalMethods
        void AddConfigurations(WebApplicationBuilder builder)
        {
            builder.Services.Configure<TaghcheSettings>(builder.Configuration.GetSection(nameof(TaghcheSettings)));
            builder.Services.Configure<DistributedCacheSettings>(builder.Configuration.GetSection(nameof(DistributedCacheSettings)));
        }
        #endregion
    }

}
