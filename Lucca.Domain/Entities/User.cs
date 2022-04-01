using System;
using System.Collections.Generic;

namespace Lucca.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Currency_ISO { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public string GetFullName() => $"{Name} {LastName}";
    }
}