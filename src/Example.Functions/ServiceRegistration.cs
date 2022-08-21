using Microsoft.Extensions.DependencyInjection;

namespace Example.Functions;

public static class ServiceRegistration
{
    public static IServiceCollection AddFunctions(this IServiceCollection services)
    {
        return services;
    }
}