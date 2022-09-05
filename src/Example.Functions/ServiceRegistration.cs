using Azure.Storage.Queues;
using Example.Functions.Triggers.CreateAccountHolders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Functions;

public static class ServiceRegistration
{
    public static IServiceCollection AddFunctions(this IServiceCollection services, IConfiguration configuration)
        => services.AddLogging();
}