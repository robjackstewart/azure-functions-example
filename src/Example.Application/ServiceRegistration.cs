using Microsoft.Extensions.DependencyInjection;

namespace Example.Functions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}