using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Entities;

namespace Example.Application.Common.Interfaces
{
    public interface IReadOnlyBankDataRepository
    {
        public IQueryable<Account> Accounts { get; }
        public IQueryable<AccountHolder> AccountHolders { get; }
    }
}