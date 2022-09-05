using System.Data;
using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Infrastructure.Database
{
    public class BankDbContext : DbContext, IBankDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountHolder> AccountHolders { get; set; }

        public BankDbContext()
        {

        }

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {

        }

        public Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
            => Database.BeginTransactionAsync(isolationLevel, cancellationToken);
    }
}