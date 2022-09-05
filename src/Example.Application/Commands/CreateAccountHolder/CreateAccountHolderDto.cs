using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application.Commands.CreateAccountHolder
{
    public class CreateAccountHolderDto
    {
        public readonly string FirstName;
        public readonly string LastName;

        public readonly DateTime? CreateAtUtc;

        public CreateAccountHolderDto(string firstName, string lastName, DateTime? createAtUtc)
            => (FirstName, LastName, CreateAtUtc) = (firstName, lastName, createAtUtc);
    }
}