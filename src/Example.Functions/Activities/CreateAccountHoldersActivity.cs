using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Commands.CreateAccountHolder;
using MediatR;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace Example.Functions.Activities
{
    public sealed class CreateAccountHoldersActivity
    {
        private ISender _sender;

        public CreateAccountHoldersActivity(ISender sender)
            => _sender = sender;

        public async Task RunAsync([ActivityTrigger] IDurableActivityContext context)
        {
            var input = context.GetInput<Input>();
            var request = new CreateAccountHoldersCommand(input.CreateAccountHolderDtos);
            await _sender.Send(request);
        }

        public class Input
        {
            public readonly IEnumerable<CreateAccountHolderDto> CreateAccountHolderDtos;

            public Input(IEnumerable<CreateAccountHolderDto> createAccountHolderDtos)
                => CreateAccountHolderDtos = createAccountHolderDtos;
        }
    }
}