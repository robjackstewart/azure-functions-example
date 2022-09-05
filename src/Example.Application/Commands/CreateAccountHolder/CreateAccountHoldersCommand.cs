using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Common.Interfaces;
using Example.Domain.Entities;
using MediatR;

namespace Example.Application.Commands.CreateAccountHolder
{
    public class CreateAccountHoldersCommand : IRequest
    {
        public IEnumerable<CreateAccountHolderDto> CreateAccountHolderDtos;

        public CreateAccountHoldersCommand(IEnumerable<CreateAccountHolderDto> createAccountHolderDtos)
            => CreateAccountHolderDtos = createAccountHolderDtos;
    }

    internal class CreateAccountHoldersCommandHandler : IRequestHandler<CreateAccountHoldersCommand>
    {
        private readonly IBankDataRepository _bankData;
        private readonly IAccountHolderCreationScheduler _accountHolderCreationScheduler;

        public CreateAccountHoldersCommandHandler(IBankDataRepository bankData, IAccountHolderCreationScheduler accountHolderCreationScheduler)
            => (_bankData, _accountHolderCreationScheduler) = (bankData, accountHolderCreationScheduler);

        public async Task<Unit> Handle(CreateAccountHoldersCommand request, CancellationToken cancellationToken)
        {
            var nonScheduledAccountHolders = request.CreateAccountHolderDtos
                .Where(c => c.CreateAtUtc is null)
                .Select(c => new AccountHolder { FirstName = c.FirstName, LastName = c.LastName })
                .ToArray();

            var scheduledAccountHolders = request.CreateAccountHolderDtos
                .Where(c => c.CreateAtUtc is not null)
                .Select(c => new { c.FirstName, c.LastName, CreateAtUtc = c.CreateAtUtc.Value })
                .ToArray();

            await using var transaction = await _bankData.BeginTransactionAsync(cancellationToken: cancellationToken);

            _bankData.AccountHolders.AddRange(nonScheduledAccountHolders);

            await _bankData.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(CancellationToken.None);

            var tasks = scheduledAccountHolders.Select(s => _accountHolderCreationScheduler.ScheduleAsync(s.FirstName, s.LastName, s.CreateAtUtc, cancellationToken));

            await Task.WhenAll(tasks);

            return Unit.Value;
        }
    }
}