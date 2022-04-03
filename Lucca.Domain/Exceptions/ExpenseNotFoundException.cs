using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class ExpenseNotFoundException : NotFoundException
    {
        public ExpenseNotFoundException(Guid expenseId) : base($"The expense with the id {expenseId} was not found.")
        {
        }

        private ExpenseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}