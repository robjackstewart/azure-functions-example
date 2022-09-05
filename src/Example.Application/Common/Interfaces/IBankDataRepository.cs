using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Application.Common.Interfaces
{
    public interface IBankDataRepository
    {
        public DbSet<Account> Accounts { get; }
        public DbSet<AccountHolder> AccountHolders { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}