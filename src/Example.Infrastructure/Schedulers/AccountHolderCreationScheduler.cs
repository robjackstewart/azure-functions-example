using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Example.Application.Common.Interfaces;
using Example.Common.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Example.Infrastructure.Schedulers
{
    public class AccountHolderCreationScheduler : IAccountHolderCreationScheduler
    {
        private readonly QueueClient _queueClient;

        public AccountHolderCreationScheduler(QueueClient queueClient)
            => _queueClient = queueClient;

        public async Task ScheduleAsync(string firstName, string lastName, DateTime createAtUtc, CancellationToken cancellationToken = default)
        {
            await _queueClient.CreateIfNotExistsAsync();
            var message = new CreateAccountHolderQueueMessage
            {
                FirstName = firstName,
                LastName = lastName
            };
            var messageString = JsonSerializer.Serialize(message);
            var visibilityTimeout = createAtUtc > DateTime.UtcNow ? createAtUtc - DateTime.UtcNow
                : null as TimeSpan?;
            await _queueClient.SendMessageAsync(messageString, visibilityTimeout, null, cancellationToken);
        }
    }
}