using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application.Common.Interfaces
{
    public interface IAccountHolderCreationScheduler
    {
        public Task ScheduleAsync(string firstName, string lastName, DateTime createAtUtc, CancellationToken cancellationToken = default);
    }
}