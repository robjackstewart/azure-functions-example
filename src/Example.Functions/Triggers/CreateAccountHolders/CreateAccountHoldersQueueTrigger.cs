using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Commands.CreateAccountHolder;
using Example.Common.Models;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Example.Functions.Triggers.CreateAccountHolders
{
    public class CreateAccountHoldersQueueTrigger
    {
        private readonly ISender _sender;

        public CreateAccountHoldersQueueTrigger(ISender sender)
            => _sender = sender;

        [FunctionName(nameof(CreateAccountHoldersQueueTrigger))]
        public async Task RunAsync([QueueTrigger("%Queues:CreateAccountHolders%")] CreateAccountHoldersQueueMessage queueMessage)
        {
            var dtos = queueMessage.AccountHolders.Select(c => new CreateAccountHolderDto(c.FirstName, c.LastName, c.CreateAtUtc));
            if (dtos.Any())
            {
                var command = new CreateAccountHoldersCommand(dtos);
                await _sender.Send(command);
            }
        }
    }
}