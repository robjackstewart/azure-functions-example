using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Domain.Entities
{
    public sealed class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AccountHolderId { get; set; }

        public AccountHolder AccountHolder { get; set; }
    }
}