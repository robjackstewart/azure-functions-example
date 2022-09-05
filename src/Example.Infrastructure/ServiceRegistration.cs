using Azure.Storage.Queues;
using Example.Application.Common.Interfaces;
using Example.Infrastructure;
using Example.Infrastructure.Database;
using Example.Infrastructure.Schedulers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Functions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        => services.AddDatabase(configuration)
            .AddQueueClients(configuration);

    private static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        return services.AddDbContext<BankDbContext>(
            options =>
                options.UseNpgsql(connectionString))
            .AddScoped<IBankDataRepository, BankDbContext>();
    }

    private static IServiceCollection AddQueueClients(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["AzureWebJobsStorage"];

        var onDemandCreateAccoumtHoldersQueueName = configuration["Queues:CreateAccountHolders"];

        var onDemandCreateAccoumtHoldersQueueClient = new QueueClient(connectionString, onDemandCreateAccoumtHoldersQueueName);
        onDemandCreateAccoumtHoldersQueueClient.CreateIfNotExists();

        return services.AddScoped<IAccountHolderCreationScheduler>(p => new AccountHolderCreationScheduler(onDemandCreateAccoumtHoldersQueueClient));
    }
}