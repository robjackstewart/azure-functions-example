using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Common.Models
{
    public class CreateAccountHoldersQueueMessage
    {
        public ICollection<CreateAccountHolderQueueMessage> AccountHolders { get; set; } = new CreateAccountHolderQueueMessage[] { };
    }

    public class CreateAccountHolderQueueMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreateAtUtc { get; set; }
    }
}