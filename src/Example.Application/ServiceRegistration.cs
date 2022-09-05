using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Example.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}