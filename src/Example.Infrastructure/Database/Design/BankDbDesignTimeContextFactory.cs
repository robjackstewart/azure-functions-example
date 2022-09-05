using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Example.Infrastructure.Database.Design
{
    internal class BankDbDesignTimeContextFactory : IDesignTimeDbContextFactory<BankDbContext>
    {
        public BankDbContext CreateDbContext(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"arg: {arg}");
            }
            var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>();
            optionsBuilder.UseNpgsql("Host=database;Database=AccountsExample;Username=postgres;Password=Password123+");
            var dbContext = new BankDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}