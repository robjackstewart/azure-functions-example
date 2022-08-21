using Microsoft.Extensions.DependencyInjection;

namespace Example.Functions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}