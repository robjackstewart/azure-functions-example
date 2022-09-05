using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Database
{
    public class ReadOnlyBankDbContext : IReadOnlyBankDbContext
    {
        private readonly IBankDbContext _context;

        public ReadOnlyBankDbContext(IBankDbContext context)
            => _context = context;

        public IQueryable<Account> Accounts => _context.Accounts.AsNoTracking().AsQueryable();

        public IQueryable<AccountHolder> AccountHolders => _context.AccountHolders.AsNoTracking().AsQueryable();
    }
}