using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class ExpenseNotFoundException : Exception
    {
        public ExpenseNotFoundException()
        {
        }

        public ExpenseNotFoundException(Guid expenseId) : base($"The expense with the id {expenseId} was not found.")
        {
        }

        private ExpenseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExpenseNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}