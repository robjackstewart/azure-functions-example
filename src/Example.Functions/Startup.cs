using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Example.Application;
using Example.Infrastructure;

[assembly: FunctionsStartup(typeof(Example.Functions.Startup))]
namespace Example.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;
        builder.Services.AddFunctions(configuration)
            .AddApplication()
            .AddInfrastructure(configuration);
    }
}