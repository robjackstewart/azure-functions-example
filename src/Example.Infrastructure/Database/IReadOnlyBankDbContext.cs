using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Common.Interfaces;

namespace Example.Infrastructure.Database
{
    public interface IReadOnlyBankDbContext : IReadOnlyBankDataRepository
    {

    }
}